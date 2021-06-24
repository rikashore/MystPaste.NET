using Newtonsoft.Json;

namespace MystPaste.NET.Models
{
    public class Pasty
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        
        [JsonProperty("language")]
        public string Language { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}