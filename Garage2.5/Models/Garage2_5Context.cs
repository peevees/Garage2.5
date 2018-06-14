using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Garage2._5.Models
{
    public class Garage2_5Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Garage2_5Context() : base("name=Garage2_5Context")
        {
        }

        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Members> Members { get; set; }
        public DbSet<ParkedVehicles> ParkedVehicles { get; set; }
    }
}
