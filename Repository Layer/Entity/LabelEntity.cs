using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Repository_Layer.Entity
{
    public class LabelEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LabelId { get; set; }
        public string Label { get; set; }

        [JsonIgnore]
        [ForeignKey("User")]
        public long UserId { get; set; }
        public virtual UserEntity User { get; set; }

        [JsonIgnore]
        [ForeignKey("Note")]
        public long NoteId { get; set; }
        public virtual NotesEntity Note { get; set; }

        [JsonIgnore]
        [ForeignKey("Collab")]
        public long CollabId { get; set; }
        public virtual CollabEntity Collab { get; set; }
    }
}
