// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Specifies the peering configuration.
    /// </summary>
    public partial class ExpressRouteCircuitPeeringConfig
    {
        /// <summary>
        /// Initializes a new instance of the ExpressRouteCircuitPeeringConfig
        /// class.
        /// </summary>
        public ExpressRouteCircuitPeeringConfig()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ExpressRouteCircuitPeeringConfig
        /// class.
        /// </summary>
        /// <param name="advertisedPublicPrefixes">The reference of
        /// AdvertisedPublicPrefixes.</param>
        /// <param name="advertisedCommunities">The communities of bgp peering.
        /// Specified for microsoft peering.</param>
        /// <param name="advertisedPublicPrefixesState">The advertised public
        /// prefix state of the Peering resource. Possible values include:
        /// 'NotConfigured', 'Configuring', 'Configured',
        /// 'ValidationNeeded'</param>
        /// <param name="legacyMode">The legacy mode of the peering.</param>
        /// <param name="customerASN">The CustomerASN of the peering.</param>
        /// <param name="routingRegistryName">The RoutingRegistryName of the
        /// configuration.</param>
        public ExpressRouteCircuitPeeringConfig(IList<string> advertisedPublicPrefixes = default(IList<string>), IList<string> advertisedCommunities = default(IList<string>), ExpressRouteCircuitPeeringAdvertisedPublicPrefixState advertisedPublicPrefixesState = default(ExpressRouteCircuitPeeringAdvertisedPublicPrefixState), int? legacyMode = default(int?), int? customerASN = default(int?), string routingRegistryName = default(string))
        {
            AdvertisedPublicPrefixes = advertisedPublicPrefixes;
            AdvertisedCommunities = advertisedCommunities;
            AdvertisedPublicPrefixesState = advertisedPublicPrefixesState;
            LegacyMode = legacyMode;
            CustomerASN = customerASN;
            RoutingRegistryName = routingRegistryName;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the reference of AdvertisedPublicPrefixes.
        /// </summary>
        [JsonProperty(PropertyName = "advertisedPublicPrefixes")]
        public IList<string> AdvertisedPublicPrefixes { get; set; }

        /// <summary>
        /// Gets or sets the communities of bgp peering. Specified for
        /// microsoft peering.
        /// </summary>
        [JsonProperty(PropertyName = "advertisedCommunities")]
        public IList<string> AdvertisedCommunities { get; set; }

        /// <summary>
        /// Gets or sets the advertised public prefix state of the Peering
        /// resource. Possible values include: 'NotConfigured', 'Configuring',
        /// 'Configured', 'ValidationNeeded'
        /// </summary>
        [JsonProperty(PropertyName = "advertisedPublicPrefixesState")]
        public ExpressRouteCircuitPeeringAdvertisedPublicPrefixState AdvertisedPublicPrefixesState { get; set; }

        /// <summary>
        /// Gets or sets the legacy mode of the peering.
        /// </summary>
        [JsonProperty(PropertyName = "legacyMode")]
        public int? LegacyMode { get; set; }

        /// <summary>
        /// Gets or sets the CustomerASN of the peering.
        /// </summary>
        [JsonProperty(PropertyName = "customerASN")]
        public int? CustomerASN { get; set; }

        /// <summary>
        /// Gets or sets the RoutingRegistryName of the configuration.
        /// </summary>
        [JsonProperty(PropertyName = "routingRegistryName")]
        public string RoutingRegistryName { get; set; }

    }
}
