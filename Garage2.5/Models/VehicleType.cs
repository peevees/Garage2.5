using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2._5.Models
{
    public class VehicleType
    {
        public int Id { get; set; }
        [Display(Name = "Type")]
        public string TypeName { get; set; }

        //Navigational properties
        public virtual ICollection<ParkedVehicles> ParkedVehicle { get; set; }
    }
}