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
        [Display(Name = "Όνομα Διεύθυνσης")]
        public string AddressName { get; set; }

        [Required(ErrorMessage = "Number is required")]
        [Display(Name = "Αριθμός")]
        public string No { get; set; }

        [Required(ErrorMessage = "Zip Code is required")]
        [Display(Name = "Ταχυδρομικός κώδικας")]
        public string ZipCode { get; set; }

        [Display(Name = "Γεωγραφικό μήκος 'Latitude'")]
        public string Latitude { get; set; } //geografiko mikos 
        [Display(Name = "Γεωγραφικό πλάτος 'Longitude'")]
        public string Longitude { get; set; } //geografiko platos
        [Required(ErrorMessage = "City is required")]
        [Display(Name = "Πόλη")]
        public string City { get; set; }

        [Required(ErrorMessage = "Area is required")]
        [Display(Name = "Περιοχή")]
        public string Area { get; set; }

        //Navigation Properties
        public virtual ICollection<Place> Places { get; set; }
    }
}
