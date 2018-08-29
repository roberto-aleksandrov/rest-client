namespace Contracts.Interfaces
{
    public interface IHttpContext
    {
        Request Request { get; set; }

        Response Response { get; set; }

        void AddSharedVariable(string key, object value);

        T GetSharedVariable<T>(string key);
    }
}
