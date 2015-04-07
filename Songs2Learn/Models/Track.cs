using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Songs2Learn.Models
{
    public class Track
    {
        public int ID { get; set; }
        public int ArtistID { get; set; }
        public string Name { get; set; }

        public virtual Artist Artist { get; set; }
    }
}