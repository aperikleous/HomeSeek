using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeSeek.Entities
{
    public class Address
    {
        public int AddressId { get; set; }
        [Display(Name = "Address Line")]
        public string AddressLine { get; set; }
        public string City { get; set; }
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        public CountiesOfGreece Counties { get; set; }
        public Countries Countries { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        //Navigation Properties
        public virtual ICollection<Place> Places { get; set; }
    }
}
