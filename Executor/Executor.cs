namespace Executor
{
    using Contracts.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class Executor : IExecutor
    {
        private IList<IExtender> _extenders;

        public Executor(IList<IExtender> extenders)
        {
            _extenders = extenders;
        }

        public void AddRequestExtender(IExtender extender)
        {
            _extenders.Add(extender);
        }
        
        public void RemoveRequestExtender(IExtender extender)
        {
            _extenders.Remove(extender);
        }

        public async Task Execute(Func<Task> action, IHttpContext requestContext)
        {
            foreach (var extender in _extenders) extender.Preprocessing(requestContext);

            await action();

            foreach (var extender in _extenders) extender.Postprocessing(requestContext);
        }
    }
}
