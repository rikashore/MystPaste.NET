using System.Collections.Generic;
using MystPaste.NET.Helpers.Pastes;
using Newtonsoft.Json;

namespace MystPaste.NET.Models
{
    public class Edit
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        
        [JsonProperty("editId")]
        public string EditId { get; set; }

        [JsonProperty("editType")] 
        public EditType EditType { get; set; }
        
        [JsonProperty("metadata")]
        public List<string> Metadata { get; set; }
        
        [JsonProperty("edit")]
        public string EditContent { get; set; }
        
        [JsonProperty("editedAt")]
        public ulong EditedAt { get; set; }

        // [JsonIgnore] 
        // public EditType EditType => (EditType) _editType;
    }
}