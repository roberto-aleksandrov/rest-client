namespace Contracts.Interfaces
{
    public interface IRequestExtender
    {
        IRequestContext Preprocessing(IRequestContext requestContext);

        IRequestContext Postprocessing(IRequestContext requestContext);
    }
}
