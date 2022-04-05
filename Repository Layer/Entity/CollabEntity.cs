using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository_Layer.Entity
{
    public class CollabEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CollabId { get; set; }
        public string CollabEmailId { get; set; }
        [ForeignKey("User")]
        public long UserId { get; set; }
        public virtual UserEntity User { get; set; }
        [ForeignKey("Note")]
        public long NoteId { get; set; }
        public virtual NotesEntity Note { get; set; }
    }
}
