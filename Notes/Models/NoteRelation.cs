using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Notes.Models
{
    public class NoteSharing
    {
        public int Id { get; set; }
        public int NoteId { get; set; }
		public string ApplicationUserId { get; set; }

//        public virtual ICollection<NoteRelation> Relations { get; set; }

        public virtual Note Note { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}