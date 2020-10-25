using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Models
{
    [Table("Notes")]
    public class Note
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string NoteBody { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime EditedAt { get; set; }
    }
}
