using Newtonsoft.Json;

namespace MystPaste.NET
{
    /// <summary>
    /// A unix timestamp representing an expiration date for a paste.
    /// </summary>
    public class Timestamp
    {
        /// <summary>
        /// The integer representing the unix timestamp for expiration. 0 if expiration or paste is invalid.
        /// </summary>
        [JsonProperty("result")]
        public ulong ExpirationDate { get; }
    }
}