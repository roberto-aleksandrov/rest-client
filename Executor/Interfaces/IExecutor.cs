namespace Contracts.Interfaces
{
    using System;
    using System.Threading.Tasks;

    public interface IExecutor<Tin, Tout>
    {
        void AddRequestExtender(IExtender<Tin, Tout> extender);

        void RemoveRequestExtender(IExtender<Tin, Tout> extender);

        Task<Tout> ExecuteAsync(Func<Task<Tout>> action, IExecutionContext<Tin, Tout> actionContext);
    }
}
