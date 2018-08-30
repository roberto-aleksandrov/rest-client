namespace RestClient.Extensions
{
    using RestClient.Client.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public static class RestClientExtensions
    {
        public static async Task<TResponse> PostAsync<TResponse>(this IRestClient client, Uri uri, IDictionary<string, string> headers = null, CancellationToken cancellationToken = default(CancellationToken))
                where TResponse : class
        {
            return await client.PostAsync<object, TResponse>(uri, null, headers, cancellationToken);
        }

        public static async Task<TResponse> PutAsync<TResponse>(this IRestClient client, Uri uri, IDictionary<string, string> headers = null, CancellationToken cancellationToken = default(CancellationToken))
                where TResponse : class
        {
            return await client.PutAsync<object, TResponse>(uri, null, headers, cancellationToken);
        }

        public static async Task<TResponse> DeleteAsync<TResponse>(this IRestClient client, Uri uri, IDictionary<string, string> headers = null, CancellationToken cancellationToken = default(CancellationToken))
                where TResponse : class
        {
            return await client.DeleteAsync<object, TResponse>(uri, null, headers, cancellationToken);
        }
    }
}
