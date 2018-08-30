namespace Contracts.Interfaces
{
    using System.Threading.Tasks;

    public interface IExtender<TPreproccessingData, TPostprocessingData>
    {
        Task PreprocessAsync(IExecutionContext<TPreproccessingData, TPostprocessingData> requestContext);

        Task PostprocessAsync(IExecutionContext<TPreproccessingData, TPostprocessingData> requestContext);
    }
}
