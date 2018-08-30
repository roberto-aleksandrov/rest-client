namespace Contracts.Interfaces
{
    public interface IExecutionContext<TPreproccessingData, TPostprocessingData>
    {
        TPreproccessingData PreproccessingData { get; set; }

        TPostprocessingData Postproccessingdata { get; set; }
        
        void AddSharedVariable(string key, object value);

        T GetSharedVariable<T>(string key);
    }
}
