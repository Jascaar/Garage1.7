namespace Garage1._7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class parkingSlot2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ParkedVehicles", "IX_FirstAndSecond");
        }
        
        public override void Down()
        {
            CreateIndex("dbo.ParkedVehicles", "ParkingSlot", unique: true, name: "IX_FirstAndSecond");
        }
    }
}
