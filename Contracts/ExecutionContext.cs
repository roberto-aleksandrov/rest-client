namespace Contracts
{
    using Contracts.Interfaces;
    using System.Collections.Generic;
    using System.Net.Http;

    public class ExecutionContext : IExecutionContext<HttpRequestMessage, HttpResponseMessage>
    {
        private readonly IDictionary<string, object> _sharedVariables;
        
        public ExecutionContext(HttpRequestMessage preprocessingData)
        {
            _sharedVariables = new Dictionary<string, object>();
            PreproccessingData = preprocessingData;
        }

        public HttpRequestMessage PreproccessingData { get; set; }

        public HttpResponseMessage Postproccessingdata { get; set; }


        public void AddSharedVariable(string key, object value)
        {
            if (_sharedVariables.ContainsKey(key))
            {
                _sharedVariables[key] = value;
                return;
            }

            _sharedVariables.Add(key, value);
        }

        public T GetSharedVariable<T>(string key)
        {
            try
            {
                return (T)_sharedVariables[key];
            }
            catch
            {
                return default(T);
            }
        }
    }
}
