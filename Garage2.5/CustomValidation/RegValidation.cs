using Garage2._5.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Garage2._5.CustomValidation
{
	public class RegValidation : ValidationAttribute
	{
       private Garage2_5Context db = new Garage2_5Context();

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{

           
            List<ParkedVehicles> model;
			ParkedVehicles vehicle = (ParkedVehicles)validationContext.ObjectInstance;

			model = db.ParkedVehicles.Where(i => i.RegistrationNumber == value.ToString() && i.Id != vehicle.Id).ToList();

			if (model.Count != 0)
			{
				model.Clear();
				return new ValidationResult("the registration Number is in used ... try another");
			}
			else
			{
				model.Clear();
				return ValidationResult.Success;
			}


		}

	
    }
}