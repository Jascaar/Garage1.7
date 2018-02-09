namespace Garage1._7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Garage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParkedVehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParkingSlot = c.Int(nullable: false),
                        TypeOfVehicle = c.Int(nullable: false),
                        VehicleRegistrationNumber = c.String(),
                        VehicleBrand = c.String(),
                        Color = c.Int(nullable: false),
                        TiresOnVehicle = c.Int(nullable: false),
                        StartParking = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ParkedVehicles");
        }
    }
}
