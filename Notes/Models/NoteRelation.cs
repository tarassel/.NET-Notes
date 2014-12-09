using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notes.Models
{
    public class NoteRelation
    {
        public int Id { get; set; }
        public Note NoteId { get; set; }
        public ApplicationUser UserId { get; set; }
    }
}