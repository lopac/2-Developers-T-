using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndirectlyApp.Models
{
    public class Comment
    {
        public string Body { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Mosaic Mosaic { get; set; }

    }
}