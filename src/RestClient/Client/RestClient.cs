namespace RestClient.Client
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Client.Interfaces;
    using Builders.Interfaces;
    using Serializers.Interfaces;
    using Contracts.Interfaces;

    public class RestClient : IRestClient
    {
        private readonly HttpClient _client;
        private readonly IHttpRequestBuilder _httpRequestBuilder;
        private readonly ISerializer _serializer;

        public Task<TResponse> DeleteAsync<TRequest, TResponse>(Uri uri, TRequest request = null, IDictionary<string, string> headers = null, IRequestContext requestContext = null)
            where TRequest : class
            where TResponse : class
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> GetAsync<TResponse>(Uri uri, IDictionary<string, string> headers = null, IRequestContext requestContext = null) where TResponse : class
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> PostAsync<TRequest, TResponse>(Uri uri, TRequest request = null, IDictionary<string, string> headers = null, IRequestContext requestContext = null)
            where TRequest : class
            where TResponse : class
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> PutAsync<TRequest, TResponse>(Uri uri, TRequest request = null, IDictionary<string, string> headers = null, IRequestContext requestContext = null)
            where TRequest : class
            where TResponse : class
        {
            throw new NotImplementedException();
        }
    }
}
