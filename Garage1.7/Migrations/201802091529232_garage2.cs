namespace Garage1._7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class garage2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ParkedVehicles", "VehicleModel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ParkedVehicles", "VehicleModel", c => c.String());
        }
    }
}
