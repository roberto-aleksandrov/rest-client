namespace RestClient.Builders
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using RestClient.Builders.Interfaces;
    using RestClient.Serializers.Interfaces;

    internal class HttpRequestMessageBuilder : IHttpRequestMessageBuilder
    {
        private readonly ISerializer _serializer;
        private readonly HttpRequestMessage _requestMessage;

        public HttpRequestMessageBuilder(ISerializer serializer)
        {
            _serializer = serializer;
            _requestMessage = new HttpRequestMessage();
        }

        public HttpRequestMessage Build()
        {
            return _requestMessage;
        }

        public IHttpRequestMessageBuilder ToUri(Uri uri)
        {
            _requestMessage.RequestUri = uri ?? throw new ArgumentException("Uri cannot be null.");
            return this;
        }

        public IHttpRequestMessageBuilder WithContent(object content)
        {
            if(content != null)
            {
                _requestMessage.Content = new StringContent(_serializer.Serialize(content));
            }

            return this;
        }

        public IHttpRequestMessageBuilder WithHeaders(IDictionary<string, string> headers)
        {
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    _requestMessage.Headers.Add(header.Key, header.Value);
                }
            }
                
            return this;
        }

        public IHttpRequestMessageBuilder WithMethod(HttpMethod method)
        {
            _requestMessage.Method = method ?? HttpMethod.Get;
            return this;
        }
    }
}
