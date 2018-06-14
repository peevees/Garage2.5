using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2._5.Models
{
    public class Members
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        //Navigational properties
        public virtual ICollection<ParkedVehicles> ParkedVehicle { get; set; }
    }
}