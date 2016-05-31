using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndirectlyApp.Models
{
    public class Mosaic
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<ApplicationUser> LikedBy { get; set; }

    }
}