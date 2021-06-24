using Newtonsoft.Json;

namespace MystPaste.NET.Models
{
    public class Pasty
    {
        [JsonProperty("_id")]
        public string Id { get; }
        
        [JsonProperty("language")]
        public string Language { get; }
        
        [JsonProperty("title")]
        public string Title { get; }
        
        [JsonProperty("code")]
        public string Code { get; }
    }
}