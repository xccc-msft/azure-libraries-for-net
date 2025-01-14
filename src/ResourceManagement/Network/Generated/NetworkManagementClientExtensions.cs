// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for NetworkManagementClient.
    /// </summary>
    public static partial class NetworkManagementClientExtensions
    {
            /// <summary>
            /// Checks whether a domain name in the cloudapp.azure.com zone is available
            /// for use.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='location'>
            /// The location of the domain name.
            /// </param>
            /// <param name='domainNameLabel'>
            /// The domain name to be verified. It must conform to the following regular
            /// expression: ^[a-z][a-z0-9-]{1,61}[a-z0-9]$.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<DnsNameAvailabilityResultInner> CheckDnsNameAvailabilityAsync(this INetworkManagementClient operations, string location, string domainNameLabel, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CheckDnsNameAvailabilityWithHttpMessagesAsync(location, domainNameLabel, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gives the supported security providers for the virtual wan.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name.
            /// </param>
            /// <param name='virtualWANName'>
            /// The name of the VirtualWAN for which supported security providers are
            /// needed.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<VirtualWanSecurityProvidersInner> SupportedSecurityProvidersAsync(this INetworkManagementClient operations, string resourceGroupName, string virtualWANName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.SupportedSecurityProvidersWithHttpMessagesAsync(resourceGroupName, virtualWANName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
