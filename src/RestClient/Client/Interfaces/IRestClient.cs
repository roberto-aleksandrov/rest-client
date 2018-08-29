namespace RestClient.Client.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Contracts.Interfaces;

    public interface IRestClient
    {
        Task<TResponse> GetAsync<TResponse>(Uri uri, IDictionary<string, string> headers = null, IRequestContext requestContext = null)
            where TResponse : class;

        Task<TResponse> PostAsync<TRequest, TResponse>(Uri uri, TRequest request = null, IDictionary<string, string> headers = null, IRequestContext requestContext = null)
            where TRequest : class
            where TResponse : class;

        Task<TResponse> PutAsync<TRequest, TResponse>(Uri uri, TRequest request = null, IDictionary<string, string> headers = null, IRequestContext requestContext = null)
            where TRequest : class
            where TResponse : class;

        Task<TResponse> DeleteAsync<TRequest, TResponse>(Uri uri, TRequest request = null, IDictionary<string, string> headers = null, IRequestContext requestContext = null)
            where TRequest : class
            where TResponse : class;
    }
}
