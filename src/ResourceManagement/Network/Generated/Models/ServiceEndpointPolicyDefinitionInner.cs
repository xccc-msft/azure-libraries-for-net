// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Service Endpoint policy definitions.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class ServiceEndpointPolicyDefinitionInner : Management.ResourceManager.Fluent.SubResource
    {
        /// <summary>
        /// Initializes a new instance of the
        /// ServiceEndpointPolicyDefinitionInner class.
        /// </summary>
        public ServiceEndpointPolicyDefinitionInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// ServiceEndpointPolicyDefinitionInner class.
        /// </summary>
        /// <param name="description">A description for this rule. Restricted
        /// to 140 chars.</param>
        /// <param name="service">Service endpoint name.</param>
        /// <param name="serviceResources">A list of service resources.</param>
        /// <param name="provisioningState">The provisioning state of the
        /// service end point policy definition. Possible values are:
        /// 'Updating', 'Deleting', and 'Failed'.</param>
        /// <param name="name">The name of the resource that is unique within a
        /// resource group. This name can be used to access the
        /// resource.</param>
        /// <param name="etag">A unique read-only string that changes whenever
        /// the resource is updated.</param>
        public ServiceEndpointPolicyDefinitionInner(string id = default(string), string description = default(string), string service = default(string), IList<string> serviceResources = default(IList<string>), string provisioningState = default(string), string name = default(string), string etag = default(string))
            : base(id)
        {
            Description = description;
            Service = service;
            ServiceResources = serviceResources;
            ProvisioningState = provisioningState;
            Name = name;
            Etag = etag;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets a description for this rule. Restricted to 140 chars.
        /// </summary>
        [JsonProperty(PropertyName = "properties.description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets service endpoint name.
        /// </summary>
        [JsonProperty(PropertyName = "properties.service")]
        public string Service { get; set; }

        /// <summary>
        /// Gets or sets a list of service resources.
        /// </summary>
        [JsonProperty(PropertyName = "properties.serviceResources")]
        public IList<string> ServiceResources { get; set; }

        /// <summary>
        /// Gets the provisioning state of the service end point policy
        /// definition. Possible values are: 'Updating', 'Deleting', and
        /// 'Failed'.
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState { get; private set; }

        /// <summary>
        /// Gets or sets the name of the resource that is unique within a
        /// resource group. This name can be used to access the resource.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a unique read-only string that changes whenever the
        /// resource is updated.
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; set; }

    }
}
