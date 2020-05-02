using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeSeek.Entities
{
    public class Amenities
    {
        [ForeignKey("Place")]
        public int AmenitiesId { get; set; }
        public int Count { get; set; }
        public bool Wifi { get; set; }
        public bool Heating { get; set; }
        public bool Tv { get; set; }
        [Display(Name ="Air conditioning")]
        public bool AirConditioning { get; set; }
        [Display(Name ="Hot water")]
        public bool HotWater { get; set; }
        [Display(Name = "First aid kit")]
        public bool FirstAidKit { get; set; }
        public bool Elevator { get; set; }
        [Display(Name = "Private entrance")]
        public bool PrivateΕntrance { get; set; }
        [Display(Name = "Free parking")]
        public bool FreeParking { get; set; }


        //Navigation Properties
        public virtual Place Place { get; set; }
    }
}
