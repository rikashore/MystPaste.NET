using System.Collections.Generic;
using Newtonsoft.Json;

namespace MystPaste.NET.Models
{
    public class Paste
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        
        [JsonProperty("ownerId")]
        public string OwnerId { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("createdAt")]
        public ulong CreatedAt { get; set; }
        
        [JsonProperty("expiresIn")]
        public string ExpiresIn { get; set; }
        
        [JsonProperty("deletesAt")]
        public ulong DeletesAt { get; set; }
        
        [JsonProperty("stars")]
        public ulong Stars { get; set; }
        
        [JsonProperty("isPrivate")]
        public bool IsPrivate { get; set; }
        
        [JsonProperty("isPublic")]
        public bool IsPublic { get; set; }
        
        [JsonProperty("encrypted")]
        public bool Encrypted { get; set; }
        
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
        
        [JsonProperty("pasties")]
        public List<Pasty> Pasties { get; set; }
        
        [JsonProperty("edits")]
        public List<Edit> Edits { get; set; }
    }
}