using Garage2._5.CustomValidation;
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
		//[Required]
		[StringLength(30)]
		[RegValidation, Required]
		[Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }

		[Required]
		[StringLength(30)]
		public string Color { get; set; }
		[Required]
		[StringLength(30)]
		public string Brand { get; set; }
		
		[Display(Name = "Check In")]
        public DateTime CheckIn { get; set; }

        public int TypeId { get; set; }
		[Required]
		public int MemberId { get; set; }
     
        //Navigational properties
        public virtual VehicleType Type { get; set; }
        public virtual Members Member { get; set; }

    }


}
