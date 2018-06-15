namespace Garage2._5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validatiomformemeberand : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "Email", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
