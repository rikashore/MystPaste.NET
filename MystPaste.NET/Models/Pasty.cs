using Newtonsoft.Json;

namespace MystPaste.NET
{
    /// <summary>
    /// Represents a Pasty.
    /// </summary>
    public class Pasty
    {
        /// <summary>
        /// The id of this pasty.
        /// </summary>
        [JsonProperty("_id")]
        public string Id { get; set; }
        
        /// <summary>
        /// The language of this pasty.
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; set; }
        
        /// <summary>
        /// The title of the pasty.
        /// </summary>
        /// <remarks>
        /// This will be an empty string ("") if there is no title.
        /// </remarks>
        [JsonProperty("title")]
        public string Title { get; set; }
        
        /// <summary>
        /// The code inside the pasty.
        /// </summary>
        /// <remarks>
        /// This will be an empty string ("") if there is no code in the pasty.
        /// </remarks>
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}