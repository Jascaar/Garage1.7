namespace Garage1._7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class parkingSlot : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ParkedVehicles", "ParkingSlot", unique: true, name: "IX_FirstAndSecond");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ParkedVehicles", "IX_FirstAndSecond");
        }
    }
}
