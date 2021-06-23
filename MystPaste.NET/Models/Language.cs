using System.Collections.Generic;
using Newtonsoft.Json;

namespace MystPaste.NET.Models
{
    public class Language
    {
        [JsonProperty("ext")]
        public List<string> Extensions { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("mimes")]
        public List<string> Mimes { get; set; }
    }
}