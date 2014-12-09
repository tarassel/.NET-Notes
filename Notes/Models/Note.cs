using System;
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
//        public ICollection<ApplicationUser> Users { get; set; }
    }
}