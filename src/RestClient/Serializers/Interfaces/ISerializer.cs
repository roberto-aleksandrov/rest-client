using System.Net.Http;

namespace RestClient.Serializers.Interfaces
{
    public interface ISerializer
    {
        T Deserialize<T>(string content);

        string Serialize(object content);
    }
}
