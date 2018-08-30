namespace RestClient.Client.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IRestClient
    {
        Task<TResponse> GetAsync<TResponse>(Uri uri, IDictionary<string, string> headers = null, CancellationToken cancellationToken = default(CancellationToken))
            where TResponse : class;

        Task<TResponse> PostAsync<TRequest, TResponse>(Uri uri, TRequest request = null, IDictionary<string, string> headers = null, CancellationToken cancellationToken = default(CancellationToken))
            where TRequest : class
            where TResponse : class;

        Task<TResponse> PutAsync<TRequest, TResponse>(Uri uri, TRequest request = null, IDictionary<string, string> headers = null, CancellationToken cancellationToken = default(CancellationToken))
            where TRequest : class
            where TResponse : class;

        Task<TResponse> DeleteAsync<TRequest, TResponse>(Uri uri, TRequest request = null, IDictionary<string, string> headers = null, CancellationToken cancellationToken = default(CancellationToken))
            where TRequest : class
            where TResponse : class;
    }
}
