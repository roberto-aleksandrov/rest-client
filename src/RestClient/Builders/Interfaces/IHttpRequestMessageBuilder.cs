namespace RestClient.Builders.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;

    internal interface IHttpRequestMessageBuilder
    {
        IHttpRequestMessageBuilder ToUri(Uri uri);

        IHttpRequestMessageBuilder WithMethod(HttpMethod method);

        IHttpRequestMessageBuilder WithContent(object content);

        IHttpRequestMessageBuilder WithHeaders(IDictionary<string, string> headers);

        HttpRequestMessage Build();
    }
}
