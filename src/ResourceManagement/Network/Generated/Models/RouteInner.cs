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
    using System.Linq;

    /// <summary>
    /// Route resource.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class RouteInner : Management.ResourceManager.Fluent.SubResource
    {
        /// <summary>
        /// Initializes a new instance of the RouteInner class.
        /// </summary>
        public RouteInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the RouteInner class.
        /// </summary>
        /// <param name="nextHopType">The type of Azure hop the packet should
        /// be sent to. Possible values include: 'VirtualNetworkGateway',
        /// 'VnetLocal', 'Internet', 'VirtualAppliance', 'None'</param>
        /// <param name="addressPrefix">The destination CIDR to which the route
        /// applies.</param>
        /// <param name="nextHopIpAddress">The IP address packets should be
        /// forwarded to. Next hop values are only allowed in routes where the
        /// next hop type is VirtualAppliance.</param>
        /// <param name="provisioningState">The provisioning state of the
        /// resource. Possible values are: 'Updating', 'Deleting', and
        /// 'Failed'.</param>
        /// <param name="name">The name of the resource that is unique within a
        /// resource group. This name can be used to access the
        /// resource.</param>
        /// <param name="etag">A unique read-only string that changes whenever
        /// the resource is updated.</param>
        public RouteInner(RouteNextHopType nextHopType, string id = default(string), string addressPrefix = default(string), string nextHopIpAddress = default(string), string provisioningState = default(string), string name = default(string), string etag = default(string))
            : base(id)
        {
            AddressPrefix = addressPrefix;
            NextHopType = nextHopType;
            NextHopIpAddress = nextHopIpAddress;
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
        /// Gets or sets the destination CIDR to which the route applies.
        /// </summary>
        [JsonProperty(PropertyName = "properties.addressPrefix")]
        public string AddressPrefix { get; set; }

        /// <summary>
        /// Gets or sets the type of Azure hop the packet should be sent to.
        /// Possible values include: 'VirtualNetworkGateway', 'VnetLocal',
        /// 'Internet', 'VirtualAppliance', 'None'
        /// </summary>
        [JsonProperty(PropertyName = "properties.nextHopType")]
        public RouteNextHopType NextHopType { get; set; }

        /// <summary>
        /// Gets or sets the IP address packets should be forwarded to. Next
        /// hop values are only allowed in routes where the next hop type is
        /// VirtualAppliance.
        /// </summary>
        [JsonProperty(PropertyName = "properties.nextHopIpAddress")]
        public string NextHopIpAddress { get; set; }

        /// <summary>
        /// Gets or sets the provisioning state of the resource. Possible
        /// values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState { get; set; }

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

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (NextHopType == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "NextHopType");
            }
        }
    }
}
