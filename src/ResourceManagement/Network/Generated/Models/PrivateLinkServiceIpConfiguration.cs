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
    /// The private link service ip configuration.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class PrivateLinkServiceIpConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the PrivateLinkServiceIpConfiguration
        /// class.
        /// </summary>
        public PrivateLinkServiceIpConfiguration()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the PrivateLinkServiceIpConfiguration
        /// class.
        /// </summary>
        /// <param name="privateIPAddress">The private IP address of the IP
        /// configuration.</param>
        /// <param name="privateIPAllocationMethod">The private IP address
        /// allocation method. Possible values include: 'Static',
        /// 'Dynamic'</param>
        /// <param name="subnet">The reference of the subnet resource.</param>
        /// <param name="publicIPAddress">The reference of the public IP
        /// resource.</param>
        /// <param name="provisioningState">Gets the provisioning state of the
        /// public IP resource. Possible values are: 'Updating', 'Deleting',
        /// and 'Failed'.</param>
        /// <param name="privateIPAddressVersion">Available from Api-Version
        /// 2016-03-30 onwards, it represents whether the specific
        /// ipconfiguration is IPv4 or IPv6. Default is taken as IPv4. Possible
        /// values include: 'IPv4', 'IPv6'</param>
        /// <param name="name">The name of private link service ip
        /// configuration.</param>
        public PrivateLinkServiceIpConfiguration(string privateIPAddress = default(string), IPAllocationMethod privateIPAllocationMethod = default(IPAllocationMethod), Management.ResourceManager.Fluent.SubResource subnet = default(Management.ResourceManager.Fluent.SubResource), Management.ResourceManager.Fluent.SubResource publicIPAddress = default(Management.ResourceManager.Fluent.SubResource), string provisioningState = default(string), IPVersion privateIPAddressVersion = default(IPVersion), string name = default(string))
        {
            PrivateIPAddress = privateIPAddress;
            PrivateIPAllocationMethod = privateIPAllocationMethod;
            Subnet = subnet;
            PublicIPAddress = publicIPAddress;
            ProvisioningState = provisioningState;
            PrivateIPAddressVersion = privateIPAddressVersion;
            Name = name;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the private IP address of the IP configuration.
        /// </summary>
        [JsonProperty(PropertyName = "properties.privateIPAddress")]
        public string PrivateIPAddress { get; set; }

        /// <summary>
        /// Gets or sets the private IP address allocation method. Possible
        /// values include: 'Static', 'Dynamic'
        /// </summary>
        [JsonProperty(PropertyName = "properties.privateIPAllocationMethod")]
        public IPAllocationMethod PrivateIPAllocationMethod { get; set; }

        /// <summary>
        /// Gets or sets the reference of the subnet resource.
        /// </summary>
        [JsonProperty(PropertyName = "properties.subnet")]
        public Management.ResourceManager.Fluent.SubResource Subnet { get; set; }

        /// <summary>
        /// Gets or sets the reference of the public IP resource.
        /// </summary>
        [JsonProperty(PropertyName = "properties.publicIPAddress")]
        public Management.ResourceManager.Fluent.SubResource PublicIPAddress { get; set; }

        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible
        /// values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets or sets available from Api-Version 2016-03-30 onwards, it
        /// represents whether the specific ipconfiguration is IPv4 or IPv6.
        /// Default is taken as IPv4. Possible values include: 'IPv4', 'IPv6'
        /// </summary>
        [JsonProperty(PropertyName = "properties.privateIPAddressVersion")]
        public IPVersion PrivateIPAddressVersion { get; set; }

        /// <summary>
        /// Gets or sets the name of private link service ip configuration.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

    }
}
