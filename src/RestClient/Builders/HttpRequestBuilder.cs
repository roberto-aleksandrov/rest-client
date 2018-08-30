namespace RestClient.Builders
{
    using RestClient.Builders.Interfaces;
    using RestClient.Serializers;
    using RestClient.Serializers.Interfaces;

    internal class HttpRequestBuilder : IHttpRequestBuilder
    {
        private readonly ISerializer _serializer;

        public HttpRequestBuilder()
         : this(new JsonSerializer()) { }

        public HttpRequestBuilder(ISerializer serializer)
        {
            _serializer = serializer;
        }

        public IHttpRequestMessageBuilder New()
        {
            return new HttpRequestMessageBuilder(_serializer);
        }
    }
}
