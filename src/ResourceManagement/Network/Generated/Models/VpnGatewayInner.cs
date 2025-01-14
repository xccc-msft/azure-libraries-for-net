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
    /// VpnGateway Resource.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class VpnGatewayInner : Management.ResourceManager.Fluent.Resource
    {
        /// <summary>
        /// Initializes a new instance of the VpnGatewayInner class.
        /// </summary>
        public VpnGatewayInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the VpnGatewayInner class.
        /// </summary>
        /// <param name="virtualHub">The VirtualHub to which the gateway
        /// belongs.</param>
        /// <param name="connections">List of all vpn connections to the
        /// gateway.</param>
        /// <param name="bgpSettings">Local network gateway's BGP speaker
        /// settings.</param>
        /// <param name="provisioningState">The provisioning state of the
        /// resource. Possible values include: 'Succeeded', 'Updating',
        /// 'Deleting', 'Failed'</param>
        /// <param name="vpnGatewayScaleUnit">The scale unit for this vpn
        /// gateway.</param>
        /// <param name="etag">Gets a unique read-only string that changes
        /// whenever the resource is updated.</param>
        public VpnGatewayInner(string location = default(string), string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), Management.ResourceManager.Fluent.SubResource virtualHub = default(Management.ResourceManager.Fluent.SubResource), IList<VpnConnectionInner> connections = default(IList<VpnConnectionInner>), BgpSettings bgpSettings = default(BgpSettings), ProvisioningState provisioningState = default(ProvisioningState), int? vpnGatewayScaleUnit = default(int?), string etag = default(string))
            : base(location, id, name, type, tags)
        {
            VirtualHub = virtualHub;
            Connections = connections;
            BgpSettings = bgpSettings;
            ProvisioningState = provisioningState;
            VpnGatewayScaleUnit = vpnGatewayScaleUnit;
            Etag = etag;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the VirtualHub to which the gateway belongs.
        /// </summary>
        [JsonProperty(PropertyName = "properties.virtualHub")]
        public Management.ResourceManager.Fluent.SubResource VirtualHub { get; set; }

        /// <summary>
        /// Gets or sets list of all vpn connections to the gateway.
        /// </summary>
        [JsonProperty(PropertyName = "properties.connections")]
        public IList<VpnConnectionInner> Connections { get; set; }

        /// <summary>
        /// Gets or sets local network gateway's BGP speaker settings.
        /// </summary>
        [JsonProperty(PropertyName = "properties.bgpSettings")]
        public BgpSettings BgpSettings { get; set; }

        /// <summary>
        /// Gets or sets the provisioning state of the resource. Possible
        /// values include: 'Succeeded', 'Updating', 'Deleting', 'Failed'
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public ProvisioningState ProvisioningState { get; set; }

        /// <summary>
        /// Gets or sets the scale unit for this vpn gateway.
        /// </summary>
        [JsonProperty(PropertyName = "properties.vpnGatewayScaleUnit")]
        public int? VpnGatewayScaleUnit { get; set; }

        /// <summary>
        /// Gets a unique read-only string that changes whenever the resource
        /// is updated.
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; private set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
        }
    }
}
