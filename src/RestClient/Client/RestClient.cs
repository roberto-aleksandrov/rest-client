namespace RestClient.Client
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Client.Interfaces;
    using Builders.Interfaces;
    using Serializers.Interfaces;
    using Exceptions;
    using System.Threading;
    using Contracts.Interfaces;

    internal class RestClient : IRestClient
    {
        private readonly HttpClient _client;
        private readonly IHttpRequestBuilder _httpRequestBuilder;
        private readonly ISerializer _serializer;
        private readonly IExecutor<HttpRequestMessage, HttpResponseMessage> _executor;
        private readonly IDictionary<string, string> _defaultHeaders;

        public RestClient(
            HttpClient client, 
            IHttpRequestBuilder httpRequestBuilder,
            ISerializer serializer,
            IExecutor<HttpRequestMessage, HttpResponseMessage> executor,
            IDictionary<string, string> defaultHeaders)
        {
            _client = client;
            _httpRequestBuilder = httpRequestBuilder;
            _serializer = serializer;
            _executor = executor;
            _defaultHeaders = defaultHeaders;
        }

        private HttpRequestMessage BuildRequestMessage(HttpMethod method, Uri uri, IDictionary<string, string> headers, object request = null)
        {
            return _httpRequestBuilder.New()
                .ToUri(uri)
                .WithContent(request)
                .WithHeaders(_defaultHeaders)
                .WithHeaders(headers)
                .WithMethod(method)
                .Build();
        }

        private async Task<TResponse> ExecuteAsync<TResponse>(HttpRequestMessage requestMessage, CancellationToken cancellationToken = default(CancellationToken))
            where TResponse : class
        {
            var context = new Contracts.ExecutionContext(requestMessage);
            var response = await _executor.ExecuteAsync(async () => await _client.SendAsync(requestMessage, cancellationToken), context);
                        
            if (!response.IsSuccessStatusCode)
            {
                throw new RestClientException(await response.Content.ReadAsStringAsync(), (int)response.StatusCode);
            }

            return _serializer.Deserialize<TResponse>(await response.Content.ReadAsStringAsync());
        }
        
        public async Task<TResponse> GetAsync<TResponse>(Uri uri, IDictionary<string, string> headers = null, CancellationToken cancellationToken = default(CancellationToken))
            where TResponse : class
        {
            var requestMessage = BuildRequestMessage(HttpMethod.Get, uri, headers);
            return await ExecuteAsync<TResponse>(requestMessage, cancellationToken);
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(Uri uri, TRequest request = null, IDictionary<string, string> headers = null, CancellationToken cancellationToken = default(CancellationToken))
            where TRequest : class
            where TResponse : class
        {
            var requestMessage = BuildRequestMessage(HttpMethod.Post, uri, headers, request);
            return await ExecuteAsync<TResponse>(requestMessage, cancellationToken);
        }

        public async Task<TResponse> PutAsync<TRequest, TResponse>(Uri uri, TRequest request = null, IDictionary<string, string> headers = null, CancellationToken cancellationToken = default(CancellationToken))
            where TRequest : class
            where TResponse : class
        {
            var requestMessage = BuildRequestMessage(HttpMethod.Put, uri, headers, request);
            return await ExecuteAsync<TResponse>(requestMessage,  cancellationToken);
        }

        public async Task<TResponse> DeleteAsync<TRequest, TResponse>(Uri uri, TRequest request = null, IDictionary<string, string> headers = null, CancellationToken cancellationToken = default(CancellationToken))
            where TRequest : class
            where TResponse : class
        {
            var requestMessage = BuildRequestMessage(HttpMethod.Delete, uri, headers, request);
            return await ExecuteAsync<TResponse>(requestMessage, cancellationToken);
        }
    }
}
