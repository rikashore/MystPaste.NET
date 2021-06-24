using System.Collections.Generic;
using Newtonsoft.Json;

namespace MystPaste.NET.Models
{
    public class Paste
    {
        [JsonProperty("_id")]
        public string Id { get; }
        
        [JsonProperty("ownerId")]
        public string OwnerId { get; }
        
        [JsonProperty("title")]
        public string Title { get; }
        
        [JsonProperty("createdAt")]
        public ulong CreatedAt { get; }
        
        [JsonProperty("expiresIn")]
        public string ExpiresIn { get; }
        
        [JsonProperty("deletesAt")]
        public ulong DeletesAt { get; }
        
        [JsonProperty("stars")]
        public ulong Stars { get; }
        
        [JsonProperty("isPrivate")]
        public bool IsPrivate { get; }
        
        [JsonProperty("isPublic")]
        public bool IsPublic { get; }
        
        [JsonProperty("encrypted")]
        public bool Encrypted { get; }
        
        [JsonProperty("tags")]
        public List<string> Tags { get; }
        
        [JsonProperty("pasties")]
        public List<Pasty> Pasties { get; }
        
        [JsonProperty("edits")]
        public List<Edit> Edits { get; }
    }
}