// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Ssh.Helpers.HybridConnectivity
{
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// Extension methods for EndpointsOperations
    /// </summary>
    public static partial class EndpointsOperationsExtensions
    {
        /// <summary>
        /// Create or update the endpoint to the target resource.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceUri'>
        /// The fully qualified Azure Resource manager identifier of the resource to be
        /// connected.
        /// </param>
        /// <param name='endpointName'>
        /// The endpoint name.
        /// </param>
        public static EndpointResource CreateOrUpdate(this IEndpointsOperations operations, string resourceUri, string endpointName, EndpointResource endpointResource)
        {
                return ((IEndpointsOperations)operations).CreateOrUpdateAsync(resourceUri, endpointName, endpointResource).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create or update the endpoint to the target resource.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceUri'>
        /// The fully qualified Azure Resource manager identifier of the resource to be
        /// connected.
        /// </param>
        /// <param name='endpointName'>
        /// The endpoint name.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<EndpointResource> CreateOrUpdateAsync(this IEndpointsOperations operations, string resourceUri, string endpointName, EndpointResource endpointResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceUri, endpointName, endpointResource, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        /// <summary>
        /// Gets the endpoint access credentials to the resource.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceUri'>
        /// The fully qualified Azure Resource manager identifier of the resource to be
        /// connected.
        /// </param>
        /// <param name='endpointName'>
        /// The endpoint name.
        /// </param>
        /// <param name='expiresin'>
        /// The is how long the endpoint access token is valid (in seconds).
        /// </param>
        public static EndpointAccessResource ListCredentials(this IEndpointsOperations operations, string resourceUri, string endpointName, long? expiresin = default(long?), ListCredentialsRequest listCredentialsRequest = default(ListCredentialsRequest))
        {
                return ((IEndpointsOperations)operations).ListCredentialsAsync(resourceUri, endpointName, expiresin, listCredentialsRequest).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets the endpoint access credentials to the resource.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceUri'>
        /// The fully qualified Azure Resource manager identifier of the resource to be
        /// connected.
        /// </param>
        /// <param name='endpointName'>
        /// The endpoint name.
        /// </param>
        /// <param name='expiresin'>
        /// The is how long the endpoint access token is valid (in seconds).
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<EndpointAccessResource> ListCredentialsAsync(this IEndpointsOperations operations, string resourceUri, string endpointName, long? expiresin = default(long?), ListCredentialsRequest listCredentialsRequest = default(ListCredentialsRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.ListCredentialsWithHttpMessagesAsync(resourceUri, endpointName, expiresin, listCredentialsRequest, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
    }
}
