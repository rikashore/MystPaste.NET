using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace MystPaste.NET.Models
{
    /// <summary>
    /// Represents a model to map the response for.
    /// the language data endpoints
    /// </summary>
    public class Language
    {
        /// <summary>
        /// An optional list of strings with the extensions used by the language.
        /// </summary>
        [JsonProperty("ext", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<string> Extensions { get; set; }

        /// <summary>
        /// An optional list of strings with the aliases of the language.
        /// </summary>
        [JsonProperty("alias", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<string> Aliases { get; set; }
        
        /// <summary>
        /// The name of the language.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The color used to represent the language. 
        /// </summary>
        /// <remarks>
        /// This is an optional property, meaning that if a language does not have a color,
        /// a default value of #ffffff is assigned. 
        /// </remarks>
        [JsonProperty("color", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("#ffffff")]
        public string HexColor { get; set; }

        /// <summary>
        /// The language mode to be used in the editor.
        /// </summary>
        [JsonProperty("mode")]
        public string Mode { get; set; }

        /// <summary>
        /// A list of mimes used by the language.
        /// </summary>
        [JsonProperty("mimes")]
        public List<string> Mimes { get; set; }

        // We do this because for some reason if aliases and/or extensions dont exist for a language they just aren't sent.
        public Language()
        {
            Aliases = new List<string>();
            Extensions = new List<string>();
        }
    }
}