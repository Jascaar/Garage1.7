namespace Garage1._7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class parkingSlot5 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ParkedVehicles", new[] { "ParkingSlot" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.ParkedVehicles", "ParkingSlot", unique: true);
        }
    }
}
