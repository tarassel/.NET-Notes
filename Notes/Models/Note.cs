﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notes.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
		//public ApplicationUser ApplicationUserId { get; set; }
//		public string ApplicationUserId { get; set; }

        public virtual ICollection<NoteSharing> SharedUsers { get; set; }
		public virtual ApplicationUser Owner { get; set; }
    }
}