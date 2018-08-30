namespace RestClient.Builders
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using Contracts.Interfaces;
    using Executors;
    using RestClient.Client.Interfaces;
    using RestClient.Serializers;
    using RestClient.Serializers.Interfaces;

    public class RestClientBuilder 
    {
        private ISerializer _serializer;
        private IDictionary<string, string> _defaultHeaders;
        private IExecutor<HttpRequestMessage, HttpResponseMessage> _executor;
        private ICollection<IExtender<HttpRequestMessage, HttpResponseMessage>> _extenders;

        public RestClientBuilder()
        {
            _extenders = new List<IExtender<HttpRequestMessage, HttpResponseMessage>>();
        }

        public IRestClient Build()
        {
            _executor = _executor ?? new Executor<HttpRequestMessage, HttpResponseMessage>(_extenders);
            _defaultHeaders = _defaultHeaders ?? new Dictionary<string, string>();
            _serializer = _serializer ?? new JsonSerializer();

            return new Client.RestClient(new HttpClient(), new HttpRequestBuilder(_serializer), _serializer, _executor, _defaultHeaders);
        }

        public RestClientBuilder WithDefaultHeaders(IDictionary<string, string> defaultHeaders)
        {
            _defaultHeaders = defaultHeaders;
            return this;
        }

        public RestClientBuilder WithExecutor(IExecutor<HttpRequestMessage, HttpResponseMessage> executor)
        {
            _executor = executor;
            _extenders.ToList().ForEach(n => executor.AddRequestExtender(n));

            return this;
        }

        public RestClientBuilder WithExtender(IExtender<HttpRequestMessage, HttpResponseMessage> extender)
        {
            _extenders.Add(extender);
            return this;
        }

        public RestClientBuilder WithExtenders(ICollection<IExtender<HttpRequestMessage, HttpResponseMessage>> extenders)
        {
            extenders.ToList().ForEach(n => _extenders.Add(n));
            return this;
        }

        public RestClientBuilder WithSerializer(ISerializer serializer)
        {
            _serializer = serializer;
            return this;
        }
    }
}
