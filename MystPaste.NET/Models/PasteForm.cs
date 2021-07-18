using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MystPaste.NET
{
    /// <summary>
    /// Represents a model to be used to post a paste.
    /// </summary>
    public class PasteForm
    {
        /// <summary>
        /// The tags of the paste. Requires auth to set.
        /// </summary>
        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> Tags { get; set; }
        
        /// <summary>
        /// When the paste expires. Defaults to never.
        /// </summary>
        [JsonProperty("expiresIn")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ExpiresIn ExpiresIn { get; set; }
        
        /// <summary>
        /// Whether the paste is private. Requires auth.
        /// </summary>
        [JsonProperty("isPrivate")]
        public bool IsPrivate { get; set; }
        
        /// <summary>
        /// Whether the paste is public. Requires auth.
        /// </summary>
        [JsonProperty("isPublic")]
        public bool IsPublic { get; set; }
        
        /// <summary>
        /// The title of the paste.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
        
        /// <summary>
        /// A list of <see cref="Pasty"/> objects. At least one is necessary.
        /// </summary>
        [JsonProperty("pasties")]
        public IList<Pasty> Pasties { get; set; }
    }
}