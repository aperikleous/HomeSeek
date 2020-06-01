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


        [Required(ErrorMessage = "Address Name is required")]
        [Display(Name = "Address Name")]
        public string AddressName { get; set; }

        [Required(ErrorMessage = "Number is required")]
        [Display(Name = "Number")]
        public string No { get; set; }

        [Required(ErrorMessage = "Zip Code is required")]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Display(Name = "Latitude")]
        public string Latitude { get; set; } //geografiko mikos 
        [Display(Name = "Longitude")]
        public string Longitude { get; set; } //geografiko platos
        [Required(ErrorMessage = "City is required")]
        [Display(Name = "City ")]
        public string City { get; set; }

        [Required(ErrorMessage = "Area is required")]
        [Display(Name = "Area")]
        public string Area { get; set; }

        //Navigation Properties
        public virtual ICollection<Place> Places { get; set; }
    }
}
