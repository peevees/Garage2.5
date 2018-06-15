namespace Garage2._5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validatiomformemeberandAndVehicle : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ParkedVehicles", "RegistrationNumber", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.ParkedVehicles", "Color", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.ParkedVehicles", "Brand", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ParkedVehicles", "Brand", c => c.String());
            AlterColumn("dbo.ParkedVehicles", "Color", c => c.String());
            AlterColumn("dbo.ParkedVehicles", "RegistrationNumber", c => c.String());
        }
    }
}
