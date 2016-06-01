using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndirectlyApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int MosaicId { get; set; }
        public string AmazonUrl { get; set; }
        public virtual Mosaic Mosaic { get; set; }

    }
}