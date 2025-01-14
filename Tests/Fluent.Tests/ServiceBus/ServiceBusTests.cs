﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ServiceBus.Fluent;
using Microsoft.Azure.Management.ServiceBus.Fluent.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fluent.Tests
{
    public class ServiceBus
    {
        [Fact]
        public void CanCRUDOnSimpleNamespace()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("fluentnetsbmrg");
                try
                {
                    var resourceManager = TestHelper.CreateResourceManager();
                    var serviceBusManager = TestHelper.CreateServiceBusManager();
                    Region region = Region.USEast;

                    var rgCreatable = resourceManager.ResourceGroups
                        .Define(rgName)
                        .WithRegion(region);

                    var namespaceDNSLabel = TestUtilities.GenerateName("netsbns");
                    var nspace = serviceBusManager.Namespaces
                            .Define(namespaceDNSLabel)
                            .WithRegion(region)
                            .WithNewResourceGroup(rgCreatable)
                            .WithSku(NamespaceSku.Basic)
                            .Create();

                    var namespaces = serviceBusManager.Namespaces.ListByResourceGroup(rgName);
                    Assert.NotNull(namespaces);
                    Assert.True(namespaces.Count() > 0);
                    var found = namespaces.Any(n => n.Name.Equals(nspace.Name, StringComparison.OrdinalIgnoreCase));
                    Assert.True(found);

                    Assert.NotNull(nspace.DnsLabel);
                    Assert.Equal(nspace.DnsLabel, namespaceDNSLabel, ignoreCase: true);
                    Assert.NotNull(nspace.Fqdn);
                    Assert.Contains(namespaceDNSLabel, nspace.Fqdn);
                    Assert.NotNull(nspace.Sku);
                    Assert.True(nspace.Sku.Name.Equals(NamespaceSku.Basic.Name));
                    Assert.NotNull(nspace.Region);
                    Assert.True(nspace.Region.Equals(region));
                    Assert.NotNull(nspace.ResourceGroupName);
                    Assert.Equal(nspace.ResourceGroupName, rgName, ignoreCase: true);
                    Assert.NotNull(nspace.Queues);
                    Assert.Empty(nspace.Queues.List());
                    Assert.NotNull(nspace.Topics);
                    Assert.Empty(nspace.Topics.List());
                    Assert.NotNull(nspace.AuthorizationRules);
                    var defaultNsRules = nspace.AuthorizationRules.List();
                    Assert.Single(defaultNsRules);
                    var defaultNsRule = defaultNsRules.ElementAt(0);
                    Assert.Equal("RootManageSharedAccessKey", defaultNsRule.Name, ignoreCase: true);
                    Assert.NotNull(defaultNsRule.Rights);
                    Assert.NotNull(defaultNsRule.NamespaceName);
                    Assert.Equal(defaultNsRule.NamespaceName, namespaceDNSLabel, ignoreCase: true);
                    Assert.NotNull(defaultNsRule.ResourceGroupName);
                    Assert.Equal(defaultNsRule.ResourceGroupName, rgName, ignoreCase: true);
                    nspace.Update()
                        .WithSku(NamespaceSku.Standard)
                        .Apply();
                    Assert.True(nspace.Sku.Name.Equals(NamespaceSku.Standard.Name));
                    // TODO: There is a bug in LRO implementation of ServiceBusNamespace DELETE operation (Last poll returns 404, reported this to RP]
                    //
                    // serviceBusManager.Namespaces.DeleteByGroup(rgName, nspace.Name);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(rgName);
                    }
                    catch
                    {
                    }
                }
            }
        }

        [Fact]
        public void CanCreateNamespaceThenCRUDOnQueue()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("sluentnetsbmrg");
                try
                {
                    var resourceManager = TestHelper.CreateResourceManager();
                    var serviceBusManager = TestHelper.CreateServiceBusManager();
                    Region region = Region.USEast;

                    var rgCreatable = resourceManager.ResourceGroups
                        .Define(rgName)
                        .WithRegion(region);

                    var namespaceDNSLabel = TestUtilities.GenerateName("netsbns");
                    var nspace = serviceBusManager.Namespaces
                        .Define(namespaceDNSLabel)
                            .WithRegion(region)
                            .WithNewResourceGroup(rgCreatable)
                            .WithSku(NamespaceSku.Standard)
                        .Create();
                    Assert.NotNull(nspace);
                    Assert.NotNull(nspace.Inner);

                    String queueName = TestUtilities.GenerateName("queue14444444444444444444444444444444444444444444555555555555");
                    var queue = nspace.Queues
                            .Define(queueName)
                            .Create();

                    Assert.NotNull(queue);
                    Assert.NotNull(queue.Inner);
                    Assert.NotNull(queue.Name);
                    Assert.Equal(queue.Name, queueName, ignoreCase: true);

                    // Default lock duration is 1 minute, assert TimeSpan("00:01:00") parsing
                    //
                    Assert.Equal("00:01:00", queue.Inner.LockDuration);
                    Assert.Equal(60, queue.LockDurationInSeconds);

                    var dupDetectionDuration = queue.DuplicateMessageDetectionHistoryDuration;
                    Assert.Equal(10, dupDetectionDuration.TotalMinutes);
                    // Default message TTL is TimeSpan.Max, assert parsing
                    //
                    Assert.Equal("10675199.02:48:05.4775807", queue.Inner.DefaultMessageTimeToLive);
                    var msgTtlDuration = queue.DefaultMessageTtlDuration;
                    // Assert the default ttl TimeSpan("10675199.02:48:05.4775807") parsing
                    //
                    Assert.Equal(10675199, msgTtlDuration.Days);
                    Assert.Equal(2, msgTtlDuration.Hours);
                    Assert.Equal(48, msgTtlDuration.Minutes);
                    // Assert the default max size In MB
                    //
                    Assert.Equal(1024, queue.MaxSizeInMB);
                    var queuesInNamespace = nspace.Queues.List();
                    Assert.NotNull(queuesInNamespace);
                    Assert.True(queuesInNamespace.Count() > 0);
                    IQueue foundQueue = queuesInNamespace.FirstOrDefault(q => q.Name.Equals(queueName, StringComparison.OrdinalIgnoreCase));
                    Assert.NotNull(foundQueue);
                    // Dead lettering disabled by default
                    //
                    Assert.False(foundQueue.IsDeadLetteringEnabledForExpiredMessages);
                    foundQueue = foundQueue.Update()
                            .WithMessageLockDurationInSeconds(120)
                            .WithDefaultMessageTTL(new TimeSpan(0, 20, 0))
                            .WithExpiredMessageMovedToDeadLetterQueue()
                            .WithMessageMovedToDeadLetterQueueOnMaxDeliveryCount(25)
                            .Apply();
                    Assert.Equal(120, foundQueue.LockDurationInSeconds);
                    Assert.True(foundQueue.IsDeadLetteringEnabledForExpiredMessages);
                    Assert.Equal(25, foundQueue.MaxDeliveryCountBeforeDeadLetteringMessage);

                    queuesInNamespace = nspace.Queues.List();
                    Assert.NotNull(queuesInNamespace);
                    Assert.True(queuesInNamespace.Count() > 0);
                    foundQueue = queuesInNamespace.FirstOrDefault(q => q.Name.Equals(queueName, StringComparison.OrdinalIgnoreCase));
                    Assert.NotNull(foundQueue);
                    Assert.Equal(120, foundQueue.LockDurationInSeconds);
                    Assert.True(foundQueue.IsDeadLetteringEnabledForExpiredMessages);
                    Assert.Equal(25, foundQueue.MaxDeliveryCountBeforeDeadLetteringMessage);

                    nspace.Queues.DeleteByName(foundQueue.Name);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(rgName);
                    }
                    catch
                    {
                    }
                }
            }
        }

        [Fact]
        public void CanCreateDeleteQueueWithNamespace()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("fluentnetsbmrg");
                try
                {
                    var resourceManager = TestHelper.CreateResourceManager();
                    var serviceBusManager = TestHelper.CreateServiceBusManager();
                    Region region = Region.USEast;

                    var rgCreatable = resourceManager.ResourceGroups
                        .Define(rgName)
                        .WithRegion(region);

                    var namespaceDNSLabel = TestUtilities.GenerateName("netsbns");
                    var queueName = TestUtilities.GenerateName("queue1-");
                    // Create NS with Queue
                    //
                    var nspace = serviceBusManager.Namespaces
                            .Define(namespaceDNSLabel)
                            .WithRegion(region)
                            .WithNewResourceGroup(rgCreatable)
                            .WithSku(NamespaceSku.Standard)
                            .WithNewQueue(queueName, 1024)
                            .Create();

                    Assert.NotNull(nspace);
                    Assert.NotNull(nspace.Inner);
                    // Lookup queue
                    //
                    var queuesInNamespace = nspace.Queues.List();
                    Assert.NotNull(queuesInNamespace);
                    Assert.Single(queuesInNamespace);
                    IQueue foundQueue = queuesInNamespace.FirstOrDefault(q => q.Name.Equals(queueName, StringComparison.OrdinalIgnoreCase));
                    Assert.NotNull(foundQueue);
                    // Remove Queue
                    //
                    nspace.Update()
                        .WithoutQueue(queueName)
                        .Apply();
                    queuesInNamespace = nspace.Queues.List();
                    Assert.NotNull(queuesInNamespace);
                    Assert.Empty(queuesInNamespace);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(rgName);
                    }
                    catch
                    {
                    }
                }
            }
        }

        [Fact]
        public void CanCreateNamespaceThenCRUDOnTopic()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("fluentnetsbmrg");
                try
                {
                    var resourceManager = TestHelper.CreateResourceManager();
                    var serviceBusManager = TestHelper.CreateServiceBusManager();
                    Region region = Region.USEast;

                    var rgCreatable = resourceManager.ResourceGroups
                        .Define(rgName)
                        .WithRegion(region);

                    var namespaceDNSLabel = TestUtilities.GenerateName("netsbns");
                    var queueName = TestUtilities.GenerateName("queue1-");
                    // Create NS with Queue
                    //
                    var nspace = serviceBusManager.Namespaces
                            .Define(namespaceDNSLabel)
                            .WithRegion(region)
                            .WithNewResourceGroup(rgCreatable)
                            .WithSku(NamespaceSku.Standard)
                            .Create();

                    Assert.NotNull(nspace);
                    Assert.NotNull(nspace.Inner);

                    var topicName = TestUtilities.GenerateName("topic14444444444444444444444444444444444444444444555555555555");

                    var topic = nspace.Topics
                        .Define(topicName)
                        .Create();

                    Assert.NotNull(topic);
                    Assert.NotNull(topic.Inner);
                    Assert.NotNull(topic.Name);
                    Assert.Equal(topic.Name, topicName, ignoreCase: true);

                    var dupDetectionDuration = topic.DuplicateMessageDetectionHistoryDuration;
                    Assert.Equal(10, dupDetectionDuration.TotalMinutes);
                    // Default message TTL is TimeSpan.Max, assert parsing
                    //
                    Assert.Equal("10675199.02:48:05.4775807", topic.Inner.DefaultMessageTimeToLive);
                    var msgTtlDuration = topic.DefaultMessageTtlDuration;
                    // Assert the default ttl TimeSpan("10675199.02:48:05.4775807") parsing
                    //
                    Assert.Equal(10675199, msgTtlDuration.Days);
                    Assert.Equal(2, msgTtlDuration.Hours);
                    Assert.Equal(48, msgTtlDuration.Minutes);
                    // Assert the default max size In MB
                    //
                    Assert.Equal(1024, topic.MaxSizeInMB);

                    var topicsInNamespace = nspace.Topics.List();
                    Assert.NotNull(topicsInNamespace);
                    Assert.True(topicsInNamespace.Count() > 0);
                    ITopic foundTopic = topicsInNamespace.FirstOrDefault(t => t.Name.Equals(topic.Name, StringComparison.OrdinalIgnoreCase));
                    Assert.NotNull(foundTopic);
                    foundTopic = foundTopic.Update()
                            .WithDefaultMessageTTL(new TimeSpan(0, 20, 0))
                            .WithDuplicateMessageDetectionHistoryDuration(new TimeSpan(0, 15, 0))
                            .WithDeleteOnIdleDurationInMinutes(25)
                            .Apply();
                    var ttlDuration = foundTopic.DefaultMessageTtlDuration;
                    Assert.Equal(20, ttlDuration.Minutes);
                    var duplicateDetectDuration = foundTopic.DuplicateMessageDetectionHistoryDuration;
                    Assert.Equal(15, duplicateDetectDuration.Minutes);
                    Assert.Equal(25, foundTopic.DeleteOnIdleDurationInMinutes);
                    // Delete
                    nspace.Topics.DeleteByName(foundTopic.Name);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(rgName);
                    }
                    catch
                    {
                    }
                }
            }
        }

        [Fact]
        public void CanCreateDeleteTopicWithNamespace()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("fluentnetsbmrg");
                try
                {
                    var resourceManager = TestHelper.CreateResourceManager();
                    var serviceBusManager = TestHelper.CreateServiceBusManager();
                    Region region = Region.USEast;

                    var rgCreatable = resourceManager.ResourceGroups
                        .Define(rgName)
                        .WithRegion(region);

                    var namespaceDNSLabel = TestUtilities.GenerateName("netsbns");
                    var topicName = TestUtilities.GenerateName("topic1-");
                    // Create NS with Queue
                    //
                    var nspace = serviceBusManager.Namespaces
                            .Define(namespaceDNSLabel)
                            .WithRegion(region)
                            .WithNewResourceGroup(rgCreatable)
                            .WithSku(NamespaceSku.Standard)
                            .WithNewTopic(topicName, 1024)
                            .Create();

                    Assert.NotNull(nspace);
                    Assert.NotNull(nspace.Inner);
                    // Lookup topic
                    //
                    var topicsInNamespace = nspace.Topics.List();
                    Assert.NotNull(topicsInNamespace);
                    Assert.Single(topicsInNamespace);
                    ITopic foundTopic = topicsInNamespace.FirstOrDefault(t => t.Name.Equals(topicName, StringComparison.OrdinalIgnoreCase));
                    Assert.NotNull(foundTopic);
                    // Remove Topic
                    //
                    nspace.Update()
                            .WithoutTopic(topicName)
                            .Apply();
                    topicsInNamespace = nspace.Topics.List();
                    Assert.NotNull(topicsInNamespace);
                    Assert.Empty(topicsInNamespace);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(rgName);
                    }
                    catch
                    {
                    }
                }
            }
        }

        [Fact]
        public void CanOperateOnAuthorizationRules()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("fluentnetsbmrg");
                try
                {
                    var resourceManager = TestHelper.CreateResourceManager();
                    var serviceBusManager = TestHelper.CreateServiceBusManager();
                    Region region = Region.USEast;

                    var rgCreatable = resourceManager.ResourceGroups
                        .Define(rgName)
                        .WithRegion(region);

                    var namespaceDNSLabel = TestUtilities.GenerateName("netsbns");
                    var queueName = TestUtilities.GenerateName("queue1-");
                    var topicName = TestUtilities.GenerateName("topic1-");
                    var nsRuleName = TestUtilities.GenerateName("nsrule1-");
                    // Create NS with Queue, Topic and authorization rule
                    //
                    var nspace = serviceBusManager.Namespaces
                            .Define(namespaceDNSLabel)
                            .WithRegion(region)
                            .WithNewResourceGroup(rgCreatable)
                            .WithSku(NamespaceSku.Standard)
                            .WithNewQueue(queueName, 1024)
                            .WithNewTopic(topicName, 1024)
                            .WithNewManageRule(nsRuleName)
                            .Create();

                    // Lookup ns authorization rule
                    //
                    var rulesInNamespace = nspace.AuthorizationRules.List();
                    Assert.NotNull(rulesInNamespace);
                    Assert.Equal(2, rulesInNamespace.Count());    // Default + one explicit

                    INamespaceAuthorizationRule foundNsRule = rulesInNamespace.FirstOrDefault(r => r.Name.Equals(nsRuleName, StringComparison.OrdinalIgnoreCase));
                    Assert.NotNull(foundNsRule);
                    var nsRuleKeys = foundNsRule.GetKeys();
                    Assert.NotNull(nsRuleKeys);
                    Assert.NotNull(nsRuleKeys.Inner);
                    var primaryKey = nsRuleKeys.PrimaryKey;
                    Assert.NotNull(primaryKey);
                    Assert.NotNull(nsRuleKeys.SecondaryKey);
                    Assert.NotNull(nsRuleKeys.PrimaryConnectionString);
                    Assert.NotNull(nsRuleKeys.SecondaryConnectionString);
                    nsRuleKeys = foundNsRule.RegenerateKey(Policykey.PrimaryKey);
                    Assert.NotEqual(nsRuleKeys.PrimaryKey, primaryKey);
                    // Lookup queue & operate on auth rules
                    //
                    var queuesInNamespace = nspace.Queues.List();
                    Assert.NotNull(queuesInNamespace);
                    Assert.Single(queuesInNamespace);
                    var queue = queuesInNamespace.ElementAt(0);
                    Assert.NotNull(queue);
                    Assert.NotNull(queue.Inner);

                    var qRule = queue.AuthorizationRules
                            .Define("rule1")
                            .WithListeningEnabled()
                            .Create();
                    Assert.NotNull(qRule);
                    Assert.Contains(AccessRights.Listen, qRule.Rights);
                    qRule = qRule.Update()
                        .WithManagementEnabled()
                        .Apply();
                    Assert.Contains(AccessRights.Manage, qRule.Rights);
                    var rulesInQueue = queue.AuthorizationRules.List();
                    Assert.True(rulesInQueue.Count() > 0);
                    var foundQRule = false;
                    foreach (var r in rulesInQueue)
                    {
                        if (r.Name.Equals(qRule.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            foundQRule = true;
                            break;
                        }
                    }
                    Assert.True(foundQRule);
                    queue.AuthorizationRules.DeleteByName(qRule.Name);
                    // Lookup topic & operate on auth rules
                    //
                    var topicsInNamespace = nspace.Topics.List();
                    Assert.NotNull(topicsInNamespace);
                    Assert.Single(topicsInNamespace);
                    var topic = topicsInNamespace.ElementAt(0);
                    Assert.NotNull(topic);
                    Assert.NotNull(topic.Inner);
                    var tRule = topic.AuthorizationRules
                            .Define("rule2")
                            .WithSendingEnabled()
                            .Create();
                    Assert.NotNull(tRule);
                    Assert.Contains(AccessRights.Send, tRule.Rights);
                    tRule = tRule.Update()
                            .WithManagementEnabled()
                            .Apply();
                    Assert.Contains(AccessRights.Manage, tRule.Rights);
                    var rulesInTopic = topic.AuthorizationRules.List();
                    Assert.True(rulesInTopic.Count() > 0);
                    var foundTRule = false;
                    foreach (var r in rulesInTopic)
                    {
                        if (r.Name.Equals(tRule.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            foundTRule = true;
                            break;
                        }
                    }
                    Assert.True(foundTRule);
                    topic.AuthorizationRules.DeleteByName(tRule.Name);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(rgName);
                    }
                    catch
                    {
                    }
                }
            }
        }

        [Fact]
        public void CanPerformOnNamespaceActions()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var namespaceDNSLabel = TestUtilities.GenerateName("netsbns");
                var serviceBusManager = TestHelper.CreateServiceBusManager();
                var availabilityResult = serviceBusManager
                        .Namespaces
                        .CheckNameAvailability(namespaceDNSLabel);
                Assert.NotNull(availabilityResult);
                if (!availabilityResult.IsAvailable)
                {
                    Assert.NotNull(availabilityResult.UnavailabilityReason);
                    Assert.NotNull(availabilityResult.UnavailabilityMessage);
                }
            }
        }

        [Fact]
        public void CanPerformCRUDOnSubscriptions()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("fluentnetsbmrg");
                try
                {
                    var resourceManager = TestHelper.CreateResourceManager();
                    var serviceBusManager = TestHelper.CreateServiceBusManager();
                    Region region = Region.USEast;

                    var rgCreatable = resourceManager.ResourceGroups
                        .Define(rgName)
                        .WithRegion(region);

                    String namespaceDNSLabel = TestUtilities.GenerateName("netsbns");
                    String topicName = TestUtilities.GenerateName("topic1-");
                    String subscriptionName = TestUtilities.GenerateName("sub1-");
                    // Create NS with Topic
                    //
                    var nspace = serviceBusManager.Namespaces
                            .Define(namespaceDNSLabel)
                            .WithRegion(region)
                            .WithNewResourceGroup(rgCreatable)
                            .WithSku(NamespaceSku.Standard)
                            .WithNewTopic(topicName, 1024)
                            .Create();

                    Assert.NotNull(nspace);
                    Assert.NotNull(nspace.Inner);
                    // Create Topic subscriptions and list it
                    //
                    var topic = nspace.Topics.GetByName(topicName);
                     var subscription = topic.Subscriptions
                         .Define(subscriptionName)
                         .WithDefaultMessageTTL(new TimeSpan(0, 20, 0))
                         .Create();
                    Assert.NotNull(subscription);
                    Assert.NotNull(subscription.Inner);
                    Assert.Equal(20, subscription.DefaultMessageTtlDuration.Minutes);
                    subscription = topic.Subscriptions.GetByName(subscriptionName);
                    Assert.NotNull(subscription);
                    Assert.NotNull(subscription.Inner);
                    var subscriptionsInTopic = topic.Subscriptions.List();
                    Assert.True(subscriptionsInTopic.Count() > 0);
                    var foundSubscription = subscriptionsInTopic.Any(s => s.Name.Equals(subscription.Name, StringComparison.OrdinalIgnoreCase));
                    Assert.True(foundSubscription);
                    topic.Subscriptions.DeleteByName(subscriptionName);
                    subscriptionsInTopic = topic.Subscriptions.List();
                    Assert.True(subscriptionsInTopic.Count() == 0);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(rgName);
                    }
                    catch
                    {
                    }
                }
            }
        }


    }
}
