using Newtonsoft.Json;

namespace MystPaste.NET.Models
{
    /// <summary>
    /// Represents a model for an API error response.
    /// </summary>
    public class Response
    {
        /// <summary>
        /// The status/error message returned by the server.
        /// </summary>
        [JsonProperty("statusMessage")]
        public string ErrorMessage { get; }
    }
}