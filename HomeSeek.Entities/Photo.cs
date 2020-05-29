using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeSeek.Entities
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public string PhotoUrl { get; set; } //Εδώ μπορεί να είναι και κάποιο file.
        public bool PrimaryPhoto { get; set; }

        public string PhotoName { get; set; }

        //Navigation Properties
        public virtual ICollection<Place> Places { get; set; }
    }
}
