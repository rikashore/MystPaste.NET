using System.Collections.Generic;
using Newtonsoft.Json;

namespace MystPaste.NET
{
    /// <summary>
    /// Represents a class to make edits to a <see cref="Paste"/>
    /// </summary>
    public class PasteEditBuilder
    {
        internal PasteEditBuilder(Paste paste)
        {
            Title = paste.Title;
            IsPrivate = paste.IsPrivate;
            IsPublic = paste.IsPublic;
            Pasties = paste.Pasties;

            if (paste.Tags.Count > 0)
                Tags = paste.Tags;
        }
        
        /// <summary>
        /// The new title.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
        
        /// <summary>
        /// Whether the post is private
        /// </summary>
        [JsonProperty("isPrivate", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPrivate { get; set; }
        
        /// <summary>
        /// Whether the post is public.
        /// </summary>
        [JsonProperty("isPublic", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPublic { get; set; }

        /// <summary>
        /// A list of tags for the post.
        /// </summary>
        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> Tags { get; set; } = new List<string>();

        /// <summary>
        /// A list of pasties for the post. Requires at least one.
        /// </summary>
        [JsonProperty("pasties", NullValueHandling = NullValueHandling.Ignore)] 
        public IList<Pasty> Pasties { get; set; }
    }
}