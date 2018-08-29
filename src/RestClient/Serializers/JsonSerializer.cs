namespace RestClient.Serializers
{
    using Newtonsoft.Json;
    using RestClient.Serializers.Interfaces;

    public class JsonSerializer : ISerializer
    {
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly Formatting _formatting;

        public JsonSerializer()
         : this(new JsonSerializerSettings()) { }

        public JsonSerializer(JsonSerializerSettings serializerSettings)
            : this(serializerSettings, Formatting.None) { }

        public JsonSerializer(JsonSerializerSettings serializerSettings, Formatting formatting)
        {
            _serializerSettings = serializerSettings;
            _formatting = formatting;
        }

        public T Deserialize<T>(string content)
        {
            return JsonConvert.DeserializeObject<T>(content, _serializerSettings);
        }

        public string Serialize(object content)
        {
            return JsonConvert.SerializeObject(content, _formatting);
        }
    }
}
