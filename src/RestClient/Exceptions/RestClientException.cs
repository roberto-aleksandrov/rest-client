namespace RestClient.Exceptions
{
    using System;

    public class RestClientException : Exception
    {
        public RestClientException(string message, int statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }

        public int StatusCode { get; }
    }
}
