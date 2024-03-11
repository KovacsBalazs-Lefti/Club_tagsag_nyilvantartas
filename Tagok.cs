using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club_tagsag_nyilvantartas
{
    internal class Tagok
    {
        public Tagok(string id, DateTime entry, int rating, string fullname, string interest)
        {
            Id = id;
            Entry = entry;
            Rating = rating;
            Fullname = fullname;
            Interest = interest;
        }

        public string Id { get; set; }
        public DateTime Entry { get; set; }
        public int Rating { get; set; }
        public string Fullname { get; set; }
        public string Interest { get; set; }
    }
}
