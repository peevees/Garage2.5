namespace Garage2._5.Migrations
{
    using Garage2._5.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Garage2._5.Models.Garage2_5Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Garage2._5.Models.Garage2_5Context context)
        {
            #region EXPLANATION
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            #endregion

            var member = new[]
            {
                new Members { Name = "Andrew Peters" ,PhoneNumber="21434343",Address="FGSFGSGSG",Email="DFDSFSDS@FSDRFD"}
            };

            context.Members.AddOrUpdate(
                  p => new {p.Name, p.PhoneNumber, p.Address, p.Email }, member);
            var types = new[] {
                new VehicleType { TypeName = "Bus" },
                new VehicleType { TypeName = "MotorCycle" },
                new VehicleType { TypeName = "Car" },
                new VehicleType { TypeName = "Boat" },
                new VehicleType { TypeName = "Airplane" }
            };
            context.VehicleTypes.AddOrUpdate(s => new { s.TypeName }, types);

            context.SaveChanges();

            context.ParkedVehicles.AddOrUpdate(
               e => new { e.TypeId, e.Member },
               new ParkedVehicles { TypeId = types[0].Id, MemberId = member[0].Id, Brand = "Volvo", Color="Blue", RegistrationNumber="ABC123",CheckIn= DateTime.Now}
              
           );
        }
    }
}
