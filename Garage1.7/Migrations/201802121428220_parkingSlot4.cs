namespace Garage1._7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class parkingSlot4 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ParkedVehicles", "ParkingSlot", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.ParkedVehicles", new[] { "ParkingSlot" });
        }
    }
}
