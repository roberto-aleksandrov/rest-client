namespace Contracts
{
    using Interfaces;
    using System.Collections.Generic;

    public class HttpContext : IHttpContext
    {
        private IDictionary<string, object> _sharedVariables;

        public Request Request { get; set; }

        public Response Response { get; set; }

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
