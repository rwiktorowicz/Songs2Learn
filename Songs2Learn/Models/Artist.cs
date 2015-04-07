using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Songs2Learn.Models
{
    public class Artist
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
    }
}