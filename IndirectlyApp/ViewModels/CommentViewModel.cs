using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndirectlyApp.ViewModels
{
    public class CommentViewModel
    {
        public string Username { get; set; }
        public string Body { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public int MosaicId { get; set; }

    }
}