namespace Contracts.Interfaces
{
    public interface IRequestExecutor
    {
        void AddRequestExtender(IRequestExtender requestExtender);
        void RemoveRequestExtender(IRequestExtender requestExtender);
        void Execute();
    }
}
