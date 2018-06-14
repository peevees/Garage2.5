namespace Garage2._5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ParkedVehicles", "CheckIn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ParkedVehicles", "CheckIn");
        }
    }
}
