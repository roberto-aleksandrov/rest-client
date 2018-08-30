namespace Extenders
{
    using Contracts.Interfaces;
    using Serilog;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class LoggingExtender : IExtender<HttpRequestMessage, HttpResponseMessage>
    {
        private readonly ILogger _logger;

        public LoggingExtender(ILogger logger)
        {
            _logger = logger;
        }

        public async Task PreprocessAsync(IExecutionContext<HttpRequestMessage, HttpResponseMessage> requestContext)
        {
        }

        public async Task PostprocessAsync(IExecutionContext<HttpRequestMessage, HttpResponseMessage> requestContext)
        {
            if (!requestContext.Postproccessingdata.IsSuccessStatusCode)
            {
                _logger.Error(await requestContext.Postproccessingdata.Content.ReadAsStringAsync());
            }
        }
    }
}
