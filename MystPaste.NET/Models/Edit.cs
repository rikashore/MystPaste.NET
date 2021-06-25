using System.Collections.Generic;
using MystPaste.NET.Helpers.Pastes;
using Newtonsoft.Json;

namespace MystPaste.NET.Models
{
    public class Edit
    {
        
        /// <summary>
        /// Gets the id of this object.
        /// </summary>
        [JsonProperty("_id")]
        public string Id { get; set; }
        
        /// <summary>
        /// Gets the id of this edit.
        /// </summary>
        [JsonProperty("editId")]
        public string EditId { get; set; }

        /// <summary>
        /// Gets the <see cref="MystPaste.NET.Helpers.Pastes.EditType"/>
        /// </summary>
        [JsonProperty("editType")] 
        public EditType EditType { get; set; }
        
        /// <summary>
        /// A list of strings representing edit metadata.
        /// </summary>
        [JsonProperty("metadata")]
        public List<string> Metadata { get; set; }
        
        /// <summary>
        /// The previous and new content of the edit.
        /// </summary>
        [JsonProperty("edit")]
        public string EditContent { get; set; }
        
        /// <summary>
        /// A unix timestamp representing when the paste was edited.
        /// </summary>
        [JsonProperty("editedAt")]
        public ulong EditedAt { get; set; }
    }
}