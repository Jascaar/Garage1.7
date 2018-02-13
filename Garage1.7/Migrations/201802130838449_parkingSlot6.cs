namespace Garage1._7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class parkingSlot6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ParkedVehicles", "VehicleRegistrationNumber", c => c.String(nullable: false));
            AlterColumn("dbo.ParkedVehicles", "VehicleBrand", c => c.String(nullable: false));
            AlterColumn("dbo.ParkedVehicles", "VehicleModel", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ParkedVehicles", "VehicleModel", c => c.String());
            AlterColumn("dbo.ParkedVehicles", "VehicleBrand", c => c.String());
            AlterColumn("dbo.ParkedVehicles", "VehicleRegistrationNumber", c => c.String());
        }
    }
}
