namespace Contracts
{
    using System.Collections.Generic;

    public class Response
    {
        public Response(object content, int statusCode)
            : this(content, statusCode, new Dictionary<string, string>()){ }

        public Response(object content, int statusCode, IDictionary<string, string> headers)
        {
            Content = content;
            StatusCode = statusCode;
            Headers = headers;
        }

        public object Content { get; }

        public int StatusCode { get; }

        public IDictionary<string, string> Headers { get; }

        public bool IsSuccessStatusCode => StatusCode >= 200 && StatusCode < 300;


    }
}
