namespace Executor
{
    using Contracts.Interfaces;
    using System.Collections.Generic;

    public class RequestExecutor : IRequestExecutor
    {
        private IList<IRequestExtender> _requestExtenders;
        private IRequestContext _requestContext;

        public RequestExecutor(IList<IRequestExtender> requestExtenders, IRequestContext requestContext)
        {
            _requestExtenders = requestExtenders;
            _requestContext = requestContext;
        }

        public void AddRequestExtender(IRequestExtender requestExtender)
        {
            _requestExtenders.Add(requestExtender);
        }
        
        public void RemoveRequestExtender(IRequestExtender requestExtender)
        {
            _requestExtenders.Remove(requestExtender);
        }

        public void Execute()
        {
            IRequestContext tempRequestContext = _requestContext;

            //Preprocessing
            foreach (var extender in _requestExtenders) tempRequestContext = extender.Preprocessing(tempRequestContext);

            //Action

            //Postprocessing
            foreach (var extender in _requestExtenders) tempRequestContext = extender.Postprocessing(tempRequestContext);
        }
    }
}
