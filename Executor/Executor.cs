namespace Executors
{
    using Contracts.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class Executor<Tin, Tout> : IExecutor<Tin, Tout>
    {
        protected readonly ICollection<IExtender<Tin, Tout>> Extenders;

        public Executor(ICollection<IExtender<Tin, Tout>> extenders)
        {
            Extenders = extenders;
        }

        public void AddRequestExtender(IExtender<Tin, Tout> extender)
        {
            Extenders.Add(extender);
        }
        
        public void RemoveRequestExtender(IExtender<Tin, Tout> extender)
        {
            Extenders.Remove(extender);
        }

        protected virtual async Task ExecutePreprocessing(IExecutionContext<Tin, Tout> requestContext)
        {
            foreach (var extender in Extenders) await extender.PreprocessAsync(requestContext);
        }

        protected virtual async Task ExecutePostprocessing(IExecutionContext<Tin, Tout> requestContext)
        {
            foreach (var extender in Extenders) await extender.PostprocessAsync(requestContext);
        }

        public async Task<Tout> ExecuteAsync(Func<Task<Tout>> action, IExecutionContext<Tin, Tout> actionContext)
        {
            await ExecutePreprocessing(actionContext);

            var result = await action();
            actionContext.Postproccessingdata = result;

            await ExecutePostprocessing(actionContext);

            return result;
        }
    }
}
