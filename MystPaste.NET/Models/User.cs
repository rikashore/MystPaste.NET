using Newtonsoft.Json;

namespace MystPaste.NET.Models
{
    public class User
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        
        [JsonProperty("username")]
        public string Username { get; set; }
        
        [JsonProperty("avatarUrl")]
        public string AvatarUrl { get; set; }
        
        [JsonProperty("defaultLang")]
        public string DefaultLanguage { get; set; }
        
        [JsonProperty("publicProfile")]
        public bool HasPublicProfile { get; set; }
        
        [JsonProperty("supporterLength")]
        public uint SupporterLength { get; set; }
        
        [JsonProperty("contributor")]
        public bool IsContributor { get; set; }
    }
}