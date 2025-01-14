// Copyright (c) Microsoft Corporation. All rights reserved. 
// Licensed under the MIT License. See License.txt in the project root for license information. 

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.CosmosDB.Fluent;
using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Fluent.Tests
{
    public class CosmosDB
    {
        [Fact]
        public void CosmosDBCRUD()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var dbName = TestUtilities.GenerateName("db");
                var saName = TestUtilities.GenerateName("dbsa");
                var rgName = TestUtilities.GenerateName("ddbRg");
                var manager = TestHelper.CreateCosmosDB();
                var resourceManager = TestHelper.CreateResourceManager();
                ICosmosDBAccount databaseAccount = null;

                try
                {
                    databaseAccount = manager.CosmosDBAccounts.Define(dbName)
                            .WithRegion(Region.USWest)
                            .WithNewResourceGroup(rgName)
                            .WithKind(DatabaseAccountKind.GlobalDocumentDB)
                            .WithSessionConsistency()
                            .WithWriteReplication(Region.USWest)
                            .WithReadReplication(Region.USCentral)
                            .WithIpRangeFilter("")
                            .WithMultipleWriteLocationsEnabled(true)
                            .Create();

                    Assert.Equal(databaseAccount.Name, dbName.ToLower());
                    Assert.Equal(DatabaseAccountKind.GlobalDocumentDB.Value, databaseAccount.Kind);
                    Assert.Equal(2, databaseAccount.WritableReplications.Count);
                    Assert.Equal(2, databaseAccount.ReadableReplications.Count);
                    Assert.Equal(DefaultConsistencyLevel.Session, databaseAccount.DefaultConsistencyLevel);
                    Assert.True(databaseAccount.MultipleWriteLocationsEnabled);

                    databaseAccount = databaseAccount.Update()
                            .WithReadReplication(Region.AsiaSouthEast)
                            .WithoutReadReplication(Region.USEast)
                            .WithoutReadReplication(Region.USCentral)
                            .Apply();

                    databaseAccount = databaseAccount.Update()
                            .WithEventualConsistency()
                            .WithTag("tag2", "value2")
                            .WithTag("tag3", "value3")
                            .WithoutTag("tag1")
                            .Apply();
                    Assert.Equal(DefaultConsistencyLevel.Eventual, databaseAccount.DefaultConsistencyLevel);
                    Assert.True(databaseAccount.Tags.ContainsKey("tag2"));
                    Assert.True(!databaseAccount.Tags.ContainsKey("tag1"));
                }
                finally
                {
                    try
                    {
                        resourceManager.ResourceGroups.BeginDeleteByName(rgName);
                    }
                    catch { }
                }

            }
        }


        [Fact]
        public void CosmosDBBugfix()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var dbName = TestUtilities.GenerateName("db");
                var saName = TestUtilities.GenerateName("dbsa");
                var rgName = TestUtilities.GenerateName("ddbRg");
                var manager = TestHelper.CreateCosmosDB();
                var resourceManager = TestHelper.CreateResourceManager();
                ICosmosDBAccount databaseAccount = null;
                var azure = TestHelper.CreateRollupClient();

                try
                {
                    databaseAccount = manager.CosmosDBAccounts.Define(dbName)
                            .WithRegion(Region.USWest)
                            .WithNewResourceGroup(rgName)
                            .WithKind(DatabaseAccountKind.GlobalDocumentDB)
                            .WithSessionConsistency()
                            .WithWriteReplication(Region.USWest)
                            .WithReadReplication(Region.USCentral)
                            .WithIpRangeFilter("")
                            .Create();

                    // BUGFIX
                    var vn = azure.Networks.Define(dbName)
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(rgName)
                        .WithAddressSpace("192.168.0.0/16")
                        .DefineSubnet("subnet1")
                            .WithAddressPrefix("192.168.1.0/24")
                            .WithAccessFromService(ServiceEndpointType.MicrosoftAzureCosmosDB)
                            .Attach()
                        .DefineSubnet("subnet2")
                            .WithAddressPrefix("192.168.2.0/24")
                            .WithAccessFromService(ServiceEndpointType.MicrosoftAzureCosmosDB)
                            .Attach()
                        .Create();


                    databaseAccount.Update().WithVirtualNetwork(vn.Id, "Subnet1").Apply();
                    databaseAccount.Update().WithVirtualNetwork(vn.Id, "Subnet1").Apply();
                    databaseAccount.Update().WithVirtualNetwork(vn.Id, "Subnet1").Apply();
                    // END of BUGFIX
                }
                finally
                {
                    try
                    {
                        resourceManager.ResourceGroups.BeginDeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }
    }
}
