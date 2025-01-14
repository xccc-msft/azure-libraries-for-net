// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update
{
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewaySslCertificate.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayAuthenticationCertificate.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.UpdateDefinition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.HasSubnet.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayFrontend.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayFrontend.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayIPConfiguration.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayIPConfiguration.UpdateDefinition;

    /// <summary>
    /// The stage of an application gateway update allowing to modify frontend listeners.
    /// </summary>
    public interface IWithListener
    {
        /// <summary>
        /// Begins the definition of a new application gateway listener to be attached to the gateway.
        /// </summary>
        /// <param name="name">A unique name for the listener.</param>
        /// <return>The first stage of the listener definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate> DefineListener(string name);

        /// <summary>
        /// Begins the update of a listener.
        /// </summary>
        /// <param name="name">The name of an existing listener to update.</param>
        /// <return>The next stage of the definition or null if the requested listener does not exist.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayListener.Update.IUpdate UpdateListener(string name);

        /// <summary>
        /// Removes a frontend listener from the application gateway.
        /// Note that removing a listener referenced by other settings may break the application gateway.
        /// </summary>
        /// <param name="name">The name of the listener to remove.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutListener(string name);
    }

    /// <summary>
    /// The stage of an application gateway update allowing to modify front end ports.
    /// </summary>
    public interface IWithFrontendPort
    {
        /// <summary>
        /// Creates a front end port with an auto-generated name and the specified port number, unless one already exists.
        /// </summary>
        /// <param name="portNumber">A port number.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithFrontendPort(int portNumber);

        /// <summary>
        /// Creates a front end port with the specified name and port number, unless a port matching this name and/or number already exists.
        /// </summary>
        /// <param name="portNumber">A port number.</param>
        /// <param name="name">The name to assign to the port.</param>
        /// <return>The next stage of the definition, or null if a port matching either the name or the number, but not both, already exists.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithFrontendPort(int portNumber, string name);

        /// <summary>
        /// Removes the specified frontend port.
        /// Note that removing a frontend port referenced by other settings may break the application gateway.
        /// </summary>
        /// <param name="name">The name of the frontend port to remove.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutFrontendPort(string name);

        /// <summary>
        /// Removes the specified frontend port.
        /// Note that removing a frontend port referenced by other settings may break the application gateway.
        /// </summary>
        /// <param name="portNumber">The port number of the frontend port to remove.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutFrontendPort(int portNumber);
    }

    /// <summary>
    /// The stage of an application gateway update allowing to modify SSL certificates.
    /// </summary>
    public interface IWithSslCert
    {
        /// <summary>
        /// Removes the specified SSL certificate from the application gateway.
        /// Note that removing a certificate referenced by other settings may break the application gateway.
        /// </summary>
        /// <param name="name">The name of the certificate to remove.</param>
        /// <return>The next stage of the update.</return>
        /// <deprecated>Use  .withoutSslCertificate instead.</deprecated>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutCertificate(string name);

        /// <summary>
        /// Removes the specified SSL certificate from the application gateway.
        /// Note that removing a certificate referenced by other settings may break the application gateway.
        /// </summary>
        /// <param name="name">The name of the certificate to remove.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutSslCertificate(string name);

        /// <summary>
        /// Begins the definition of a new application gateway SSL certificate to be attached to the gateway for use in frontend HTTPS listeners.
        /// </summary>
        /// <param name="name">A unique name for the certificate.</param>
        /// <return>The first stage of the certificate definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewaySslCertificate.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate> DefineSslCertificate(string name);
    }

    /// <summary>
    /// The stage of an application gateway update allowing to modify probes.
    /// </summary>
    public interface IWithProbe
    {
        /// <summary>
        /// Begins the definition of a new probe.
        /// </summary>
        /// <param name="name">A unique name for the probe.</param>
        /// <return>The first stage of a probe definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate> DefineProbe(string name);

        /// <summary>
        /// Removes a probe from the application gateway.
        /// Any references to this probe from backend HTTP configurations will be automatically removed.
        /// </summary>
        /// <param name="name">The name of an existing probe.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutProbe(string name);

        /// <summary>
        /// Begins the update of an existing probe.
        /// </summary>
        /// <param name="name">The name of an existing probe.</param>
        /// <return>The first stage of a probe update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.Update.IUpdate UpdateProbe(string name);
    }

    /// <summary>
    /// The template for an application gateway update operation, containing all the settings that
    /// can be modified.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IWithSku,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IWithInstanceCount,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IWithWebApplicationFirewall,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IWithBackend,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IWithBackendHttpConfig,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IWithIPConfig,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IWithFrontend,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IWithPublicIPAddress,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IWithFrontendPort,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IWithSslCert,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IWithListener,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IWithRequestRoutingRule,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IWithExistingSubnet,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IWithProbe,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IWithDisabledSslProtocol,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IWithAuthenticationCertificate,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IWithRedirectConfiguration
    {
        /// <summary>
        /// Enables HTTP2 traffic on the Application Gateway.
        /// </summary>
        /// <returns>The next stage of the definition.</returns>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithEnableHttp2();

        /// <summary>
        /// Disables HTTP2 traffic on the Application Gateway.
        /// </summary>
        /// <returns>The next stage of the definition.</returns>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutEnableHttp2();
    }

    /// <summary>
    /// The stage of an application gateway update allowing to specify a public IP address for the public frontend.
    /// </summary>
    public interface IWithPublicIPAddress :
        Microsoft.Azure.Management.Network.Fluent.HasPublicIPAddress.Update.IWithPublicIPAddressNoDnsLabel<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate>
    {
    }

    /// <summary>
    /// The stage of an internal application gateway update allowing to make the application gateway accessible to its
    /// virtual network.
    /// </summary>
    public interface IWithPrivateFrontend
    {
        /// <summary>
        /// Enables a private (internal) default front end in the subnet containing the application gateway.
        /// A front end with an automatically generated name will be created if none exists.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithPrivateFrontend();

        /// <summary>
        /// Specifies that no private, or internal, front end should be enabled.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutPrivateFrontend();
    }

    /// <summary>
    /// The stage of an application gateway update allowing to modify backends.
    /// </summary>
    public interface IWithBackend
    {
        /// <summary>
        /// Begins the definition of a new application gateway backend to be attached to the gateway.
        /// </summary>
        /// <param name="name">A unique name for the backend.</param>
        /// <return>The first stage of the backend definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate> DefineBackend(string name);

        /// <summary>
        /// Removes the specified backend.
        /// Note that removing a backend referenced by other settings may break the application gateway.
        /// </summary>
        /// <param name="backendName">The name of an existing backend on this application gateway.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutBackend(string backendName);

        /// <summary>
        /// Begins the update of an existing backend on this application gateway.
        /// </summary>
        /// <param name="name">The name of the backend.</param>
        /// <return>The first stage of an update of the backend.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackend.Update.IUpdate UpdateBackend(string name);

        /// <summary>
        /// Ensures the specified IP address is not associated with any backend.
        /// </summary>
        /// <param name="ipAddress">An IP address.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutBackendIPAddress(string ipAddress);

        /// <summary>
        /// Ensures the specified fully qualified domain name (FQDN) is not associated with any backend.
        /// </summary>
        /// <param name="fqdn">A fully qualified domain name (FQDN).</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutBackendFqdn(string fqdn);
    }

    /// <summary>
    /// The stage of an application gateway update allowing to manage authentication certificates for the backends to use.
    /// </summary>
    public interface IWithAuthenticationCertificate :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IWithAuthenticationCertificateBeta
    {
    }

    /// <summary>
    /// The stage of an application gateway update allowing to modify backend HTTP configurations.
    /// </summary>
    public interface IWithBackendHttpConfig
    {
        /// <summary>
        /// Removes the specified backend HTTP configuration from this application gateway.
        /// Note that removing a backend HTTP configuration referenced by other settings may break the application gateway.
        /// </summary>
        /// <param name="name">The name of an existing backend HTTP configuration on this application gateway.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutBackendHttpConfiguration(string name);

        /// <summary>
        /// Begins the update of a backend HTTP configuration.
        /// </summary>
        /// <param name="name">The name of an existing backend HTTP configuration on this application gateway.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.Update.IUpdate UpdateBackendHttpConfiguration(string name);

        /// <summary>
        /// Begins the definition of a new application gateway backend HTTP configuration to be attached to the gateway.
        /// </summary>
        /// <param name="name">A unique name for the backend HTTP configuration.</param>
        /// <return>The first stage of the backend HTTP configuration definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayBackendHttpConfiguration.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate> DefineBackendHttpConfiguration(string name);
    }

    /// <summary>
    /// The stage of an application gateway update allowing to specify the capacity (number of instances) of
    /// the application gateway.
    /// </summary>
    public interface IWithInstanceCount
    {
        /// <summary>
        /// Specifies the capacity (number of instances) for the application gateway.
        /// </summary>
        /// <param name="instanceCount">The capacity as a number between 1 and 10 but also based on the limits imposed by the selected applicatiob gateway size.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithInstanceCount(int instanceCount);


        /// <summary>
        /// Specifies the min and max auto scale bound.
        /// </summary>
        /// <param name="minCapacity">Lower bound on number of Application Gateway capacity.</param>
        /// <param name="maxCapacity">Upper bound on number of Application Gateway capacity.</param>
        /// <returns>The next stage of the update.</returns>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithAutoscale(int minCapacity, int maxCapacity);
    }

    /// <summary>
    /// The stage of an application gateway update allowing to specify the sku.
    /// </summary>
    public interface IWithSku
    {

        /// <summary>
        /// Set tier of an application gateway. Possible values include: 'Standard', 'WAF', 'Standard_v2', 'WAF_v2'.
        /// </summary>
        /// <param name="tier">The tier value to set</param>
        /// <returns>The next stage of the update</returns>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithTier(ApplicationGatewayTier tier);

        /// <summary>
        /// Specifies the size of the application gateway to use within the context of the selected tier.
        /// </summary>
        /// <param name="size">An application gateway size name.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithSize(ApplicationGatewaySkuName size);
    }


    /// <summary>
    /// The stage of the applicationgateway update allowing to specify WebApplicationFirewallConfiguration.
    /// </summary>
    public interface IWithWebApplicationFirewall
    {
        /// <summary>
        /// Specifies webApplicationFirewallConfiguration
        /// </summary>
        /// <param name="config">Web application firewall configuration</param>
        /// <returns>The next stage of the definition</returns>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithWebApplicationFirewall(ApplicationGatewayWebApplicationFirewallConfiguration config);
    }


    /// <summary>
    /// The stage of an application gateway definition allowing to add a redirect configuration.
    /// </summary>
    public interface IWithRedirectConfiguration :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IWithRedirectConfigurationBeta
    {
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to specify the SSL protocols to disable.
    /// </summary>
    public interface IWithDisabledSslProtocol :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IWithDisabledSslProtocolBeta
    {
    }

    /// <summary>
    /// The stage of an application gateway update allowing to specify the subnet the app gateway is getting
    /// its private IP address from.
    /// </summary>
    public interface IWithExistingSubnet :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.HasSubnet.Update.IWithSubnet<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate>
    {
        /// <summary>
        /// Specifies the subnet the application gateway gets its private IP address from.
        /// This will create a new IP configuration, if it does not already exist.
        /// Private (internal) frontends, if any have been enabled, will be configured to use this subnet as well.
        /// </summary>
        /// <param name="subnet">An existing subnet.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithExistingSubnet(ISubnet subnet);

        /// <summary>
        /// Specifies the subnet the application gateway gets its private IP address from.
        /// This will create a new IP configuration, if it does not already exist.
        /// Private (internal) front ends, if any have been enabled, will be configured to use this subnet as well.
        /// </summary>
        /// <param name="network">The virtual network the subnet is part of.</param>
        /// <param name="subnetName">The name of a subnet within the selected network.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithExistingSubnet(INetwork network, string subnetName);
    }

    /// <summary>
    /// The stage of an application gateway update allowing to modify frontend IP configurations.
    /// </summary>
    public interface IWithFrontend
    {
        /// <summary>
        /// Begins the update of an existing front end IP configuration.
        /// </summary>
        /// <param name="frontendName">The name of an existing front end IP configuration.</param>
        /// <return>The first stage of the front end IP configuration update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayFrontend.Update.IUpdate UpdateFrontend(string frontendName);

        /// <summary>
        /// Begins the definition of the default public front end IP configuration, creating one if it does not already exist.
        /// </summary>
        /// <return>The first stage of a front end definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayFrontend.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate> DefinePublicFrontend();

        /// <summary>
        /// Specifies that the application gateway should not be private, i.e. its endpoints should not be internally accessible
        /// from within the virtual network.
        /// Note that if there are any other settings referencing the private front end, removing it may break the application gateway.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutPrivateFrontend();

        /// <summary>
        /// Specifies that the application gateway should not be Internet-facing.
        /// Note that if there are any other settings referencing the public front end, removing it may break the application gateway.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutPublicFrontend();

        /// <summary>
        /// Removes the specified front end IP configuration.
        /// Note that removing a front end referenced by other settings may break the application gateway.
        /// </summary>
        /// <param name="frontendName">The name of the front end IP configuration to remove.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutFrontend(string frontendName);

        /// <summary>
        /// Begins the update of the public front end IP configuration, if it exists.
        /// </summary>
        /// <return>The first stage of a front end update or null if no public front end exists.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayFrontend.Update.IUpdate UpdatePublicFrontend();

        /// <summary>
        /// Begins the definition of the default private front end IP configuration, creating one if it does not already exist.
        /// </summary>
        /// <return>The first stage of a front end definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayFrontend.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate> DefinePrivateFrontend();
    }

    /// <summary>
    /// The stage of an application gateway update allowing to modify request routing rules.
    /// </summary>
    public interface IWithRequestRoutingRule
    {
        /// <summary>
        /// Begins the update of a request routing rule.
        /// </summary>
        /// <param name="name">The name of an existing request routing rule.</param>
        /// <return>The first stage of a request routing rule update or null if the requested rule does not exist.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.Update.IUpdate UpdateRequestRoutingRule(string name);

        /// <summary>
        /// Begins the definition of a request routing rule for this application gateway.
        /// </summary>
        /// <param name="name">A unique name for the request routing rule.</param>
        /// <return>The first stage of the request routing rule.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRequestRoutingRule.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate> DefineRequestRoutingRule(string name);

        /// <summary>
        /// Removes a request routing rule from the application gateway.
        /// </summary>
        /// <param name="name">The name of the request routing rule to remove.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutRequestRoutingRule(string name);
    }

    /// <summary>
    /// The stage of an application gateway update allowing to modify IP configurations.
    /// </summary>
    public interface IWithIPConfig
    {
        /// <summary>
        /// Begins the update of an existing IP configuration.
        /// </summary>
        /// <param name="ipConfigurationName">The name of an existing IP configuration.</param>
        /// <return>The first stage of an IP configuration update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayIPConfiguration.Update.IUpdate UpdateIPConfiguration(string ipConfigurationName);

        /// <summary>
        /// Removes the specified IP configuration.
        /// Note that removing an IP configuration referenced by other settings may break the application gateway.
        /// Also, there must be at least one IP configuration for the application gateway to function.
        /// </summary>
        /// <param name="ipConfigurationName">The name of the IP configuration to remove.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutIPConfiguration(string ipConfigurationName);

        /// <summary>
        /// Begins the update of the default IP configuration i.e. the only one IP configuration that exists, assuming only one exists.
        /// </summary>
        /// <return>The first stage of an IP configuration update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayIPConfiguration.Update.IUpdate UpdateDefaultIPConfiguration();

        /// <summary>
        /// Begins the definition of the default IP configuration.
        /// If a default IP configuration already exists, it will be this is equivalent to <code>updateDefaultIPConfiguration()</code>.
        /// </summary>
        /// <return>The first stage of an IP configuration update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayIPConfiguration.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate> DefineDefaultIPConfiguration();
    }

    /// <summary>
    /// The stage of an application gateway update allowing to manage authentication certificates for the backends to use.
    /// </summary>
    public interface IWithAuthenticationCertificateBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Begins the definition of a new application gateway authentication certificate to be attached to the gateway for use by the backends.
        /// </summary>
        /// <param name="name">A unique name for the certificate.</param>
        /// <return>The first stage of the certificate definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayAuthenticationCertificate.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate> DefineAuthenticationCertificate(string name);

        /// <summary>
        /// Removes an existing application gateway authentication certificate.
        /// </summary>
        /// <param name="name">The name of an existing certificate.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutAuthenticationCertificate(string name);
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to add a redirect configuration.
    /// </summary>
    public interface IWithRedirectConfigurationBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Begins the definition of a new application gateway redirect configuration to be attached to the gateway.
        /// </summary>
        /// <param name="name">A unique name for the redirect configuration.</param>
        /// <return>The first stage of the redirect configuration definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.UpdateDefinition.IBlank<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate> DefineRedirectConfiguration(string name);

        /// <summary>
        /// Begins the update of a redirect configuration.
        /// </summary>
        /// <param name="name">The name of an existing redirect configuration to update.</param>
        /// <return>The next stage of the definition or null if the requested redirect configuration does not exist.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Update.IUpdate UpdateRedirectConfiguration(string name);

        /// <summary>
        /// Removes a redirect configuration from the application gateway.
        /// Note that removing a redirect configuration referenced by other settings may break the application gateway.
        /// </summary>
        /// <param name="name">The name of the redirect configuration to remove.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutRedirectConfiguration(string name);
    }

    /// <summary>
    /// The stage of an application gateway definition allowing to specify the SSL protocols to disable.
    /// </summary>
    public interface IWithDisabledSslProtocolBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Disables the specified SSL protocols.
        /// </summary>
        /// <param name="protocols">SSL protocols.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithDisabledSslProtocols(params ApplicationGatewaySslProtocol[] protocols);

        /// <summary>
        /// Enables the specified SSL protocol, if previously disabled.
        /// </summary>
        /// <param name="protocol">An SSL protocol.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutDisabledSslProtocol(ApplicationGatewaySslProtocol protocol);

        /// <summary>
        /// Enables the specified SSL protocols, if previously disabled.
        /// </summary>
        /// <param name="protocols">SSL protocols.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutDisabledSslProtocols(params ApplicationGatewaySslProtocol[] protocols);

        /// <summary>
        /// Disables the specified SSL protocol.
        /// </summary>
        /// <param name="protocol">An SSL protocol.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithDisabledSslProtocol(ApplicationGatewaySslProtocol protocol);

        /// <summary>
        /// Enables all SSL protocols, if previously disabled.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate WithoutAnyDisabledSslProtocols();
    }
}