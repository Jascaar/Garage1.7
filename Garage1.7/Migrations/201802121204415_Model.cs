namespace Garage1._7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ParkedVehicles", "VehicleModel", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ParkedVehicles", "VehicleModel");
        }
    }
}
