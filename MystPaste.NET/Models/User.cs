using Newtonsoft.Json;

namespace MystPaste.NET.Models
{
    /// <summary>
    /// Represents a Paste Myst User.
    /// </summary>
    public class User
    {
        /// <summary>
        /// The Id of the user.
        /// </summary>
        [JsonProperty("_id")]
        public string Id { get; set; }
        
        /// <summary>
        /// The user's username.
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }
        
        /// <summary>
        /// The user's Avatar URL.
        /// </summary>
        [JsonProperty("avatarUrl")]
        public string AvatarUrl { get; set; }
        
        /// <summary>
        /// The default language of the user.
        /// </summary>
        [JsonProperty("defaultLang")]
        public string DefaultLanguage { get; set; }
        
        /// <summary>
        /// Whether a user has a public profile or not.
        /// </summary>
        [JsonProperty("publicProfile")]
        public bool HasPublicProfile { get; set; }
        
        /// <summary>
        /// How long the user has been a supporter. 0 if not a supporter.
        /// </summary>
        [JsonProperty("supporterLength")]
        public int SupporterLength { get; set; }
        
        /// <summary>
        /// Whether a user has contributed to Paste Myst.
        /// </summary>
        [JsonProperty("contributor")]
        public bool IsContributor { get; set; }

        /// <summary>
        /// Whether the user is a supporter or not.
        /// </summary>
        [JsonIgnore] 
        public bool IsSupporter => SupporterLength > 0;
    }
}