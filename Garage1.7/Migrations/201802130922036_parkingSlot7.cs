namespace Garage1._7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class parkingSlot7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ParkedVehicles", "VehicleRegistrationNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ParkedVehicles", "VehicleRegistrationNumber", c => c.String(nullable: false));
        }
    }
}
