using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using Garage2._5.CustomValidation;
using Garage2._5.Models;

namespace Garage2._5.Models
{
	public class CreateViewmodel
	{
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

		public int TypeId { get; set; }
		[Required]
		public int MemberId { get; set; }
		
		public IEnumerable<VehicleType> Types { get; set; }
		public IEnumerable<Members> Members { get; set; }
	}
}