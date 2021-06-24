using System.Collections.Generic;
using Newtonsoft.Json;

namespace MystPaste.NET.Models
{
    public class Edit
    {
        [JsonProperty("_id")]
        public string Id { get; }
        
        [JsonProperty("editId")]
        public string EditId { get; }

        [JsonProperty("editType")] 
        public int EditType { get; }
        
        [JsonProperty("metadata")]
        public List<string> Metadata { get; }
        
        [JsonProperty("edit")]
        public string EditContent { get; }
        
        [JsonProperty("editedAt")]
        public ulong EditedAt { get; }

        // [JsonIgnore] 
        // public EditType EditType => (EditType) _editType;
    }
}