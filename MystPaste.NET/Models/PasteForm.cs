using System.Collections.Generic;
using Newtonsoft.Json;

namespace MystPaste.NET
{
    public class PasteForm
    {
        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> Tags { get; set; }
        
        [JsonProperty("expiresIn")]
        public string ExpiresIn { get; set; }
        
        [JsonProperty("isPrivate")]
        public bool IsPrivate { get; set; }
        
        [JsonProperty("isPublic")]
        public bool IsPublic { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("pasties")]
        public IList<Pasty> Pasties { get; set; }
    }
}