using System.Collections.Generic;
using MystPaste.NET.Models;
using Newtonsoft.Json;

namespace MystPaste.NET
{
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
        
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("isPrivate", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPrivate { get; set; }
        
        [JsonProperty("isPublic", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPublic { get; set; }

        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> Tags { get; set; } = new List<string>();

        [JsonProperty("pasties", NullValueHandling = NullValueHandling.Ignore)] 
        public IList<Pasty> Pasties { get; set; }
    }
}