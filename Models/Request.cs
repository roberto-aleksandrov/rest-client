namespace Contracts
{
    using System;
    using System.Collections.Generic;

    public class Request
    {
        public Request(Uri uri, string httpMethod)
        : this(uri, httpMethod, null) { }

        public Request(Uri uri, string httpMethod, object content)
        : this(uri, httpMethod, content, new Dictionary<string, string>()) { }

        public Request(Uri uri, string httpMethod, object content, IDictionary<string, string> headers)
        {
            Uri = uri;
            Content = content;
            Headers = headers;
            HttpMethod = httpMethod;
        }

        public Uri Uri { get; }

        public string HttpMethod { get; }

        public object Content { get; }

        public IDictionary<string, string> Headers { get; }

    }
}
