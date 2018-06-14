using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2._5.Models
{
    public class ParkedVehicles
    {
        public int Id { get; set; }
        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }
        
        
        public string Color { get; set; }
        public string Brand { get; set; }
        [Display(Name = "Check In")]
        public DateTime CheckIn { get; set; }

        public int TypeId { get; set; }
        public int MemberId { get; set; }
     
        //Navigational properties
        public virtual VehicleType Type { get; set; }
        public virtual Members Member { get; set; }

    }


}