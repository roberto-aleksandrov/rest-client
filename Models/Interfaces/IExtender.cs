namespace Contracts.Interfaces
{
    public interface IExtender
    {
        void Preprocessing(IHttpContext requestContext);

        void Postprocessing(IHttpContext requestContext);
    }
}
