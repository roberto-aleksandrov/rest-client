namespace Contracts.Interfaces
{
    using System;
    using System.Threading.Tasks;

    public interface IExecutor
    {
        void AddRequestExtender(IExtender extender);

        void RemoveRequestExtender(IExtender extender);

        Task Execute(Func<Task> action, IHttpContext requestContext);
    }
}
