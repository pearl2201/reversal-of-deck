using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace ReversalOfSpirit.Gameplay.Utils
{
    public static class JsonSerializer
    {
        private static JsonSerializerSettings serializaterSettings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.Auto,
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            ObjectCreationHandling = ObjectCreationHandling.Auto
        };

        public static string ToJson(object? obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented, serializaterSettings);
        }

        public static T? FromJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, serializaterSettings);
        }
    }
}
