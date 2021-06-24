using System.Collections.Generic;
using Newtonsoft.Json;

namespace MystPaste.NET.Models
{
    /// <summary>
    /// Represents the currently logged in user.
    /// </summary>
    public class CurrentUser : User
    {
        /// <summary>
        /// A list of paste ids the user has starred.
        /// </summary>
        [JsonProperty("stars")]
        public List<string> Stars { get; }
        
        /// <summary>
        /// User ids of the service the user used to create an account.
        /// </summary>
        [JsonProperty("serviceIds")]
        public IDictionary<string, string> ServiceIds { get; }
    }
}