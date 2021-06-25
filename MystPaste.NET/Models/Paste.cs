using System.Collections.Generic;
using Newtonsoft.Json;

namespace MystPaste.NET.Models
{
    /// <summary>
    /// Represents a Paste model.
    /// </summary>
    public class Paste
    {
        /// <summary>
        /// The Id of the paste.
        /// </summary>
        [JsonProperty("_id")]
        public string Id { get; set; }
        
        /// <summary>
        /// The id of the owner of this paste.
        /// </summary>
        [JsonProperty("ownerId")]
        public string OwnerId { get; set; }
        
        /// <summary>
        /// The title of the paste.
        /// </summary>
        /// <remarks>
        /// This will return an empty string ("") if there is no title.
        /// </remarks>
        [JsonProperty("title")]
        public string Title { get; set; }
        
        /// <summary>
        /// A unix timestamp representing the date this
        /// paste was created at.
        /// </summary>
        [JsonProperty("createdAt")]
        public ulong CreatedAt { get; set; }
        
        /// <summary>
        /// A string representing when the paste expires.
        /// See <see cref="MystPaste.NET.Helpers.Expiry.ExpiresIn"/> for possible values.
        /// </summary>
        [JsonProperty("expiresIn")]
        public string ExpiresIn { get; set; }
        
        /// <summary>
        /// A unix timestamp when this paste will delete.
        /// 0 if it it expires 'never'.
        /// </summary>
        [JsonProperty("deletesAt")]
        public ulong DeletesAt { get; set; }
        
        /// <summary>
        /// The amount of stars this paste has.
        /// </summary>
        [JsonProperty("stars")]
        public ulong Stars { get; set; }
        
        /// <summary>
        /// Whether the paste is private.
        /// </summary>
        [JsonProperty("isPrivate")]
        public bool IsPrivate { get; set; }
        
        /// <summary>
        /// Whether the paste is public.
        /// </summary>
        [JsonProperty("isPublic")]
        public bool IsPublic { get; set; }
        
        /// <summary>
        /// Whether the paste is encrypted.
        /// </summary>
        [JsonProperty("encrypted")]
        public bool Encrypted { get; set; }
        
        /// <summary>
        /// A list of tags for the paste.
        /// </summary>
        /// <remarks>
        /// This list will be empty if there are no tags.
        /// </remarks>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
        
        /// <summary>
        /// A list of <see cref="Pasty"/> objects.
        /// </summary>
        [JsonProperty("pasties")]
        public List<Pasty> Pasties { get; set; }
        
        /// <summary>
        /// A list of <see cref="Edit"/> objects.
        /// </summary>
        /// <remarks>
        /// This list will be empty if the paste has no edits.
        /// </remarks>
        [JsonProperty("edits")]
        public List<Edit> Edits { get; set; }
    }
}