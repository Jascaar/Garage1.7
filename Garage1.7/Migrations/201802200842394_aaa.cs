namespace Garage1._7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParkedVehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        ParkingSlot = c.Int(nullable: false),
                        TypeOfVehicle = c.Int(nullable: false),
                        VehicleRegistrationNumber = c.String(),
                        VehicleBrand = c.String(nullable: false),
                        VehicleModel = c.String(nullable: false),
                        Color = c.Int(nullable: false),
                        TiresOnVehicle = c.Int(nullable: false),
                        StartParking = c.DateTime(nullable: false),
                        VehicleType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleType_Id)
                .Index(t => t.MemberId)
                .Index(t => t.VehicleType_Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SSN = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        SignUpTime = c.DateTime(nullable: false),
                        Cellular = c.String(),
                        Email = c.String(nullable: false),
                        Street = c.String(),
                        StreetNumber = c.Int(nullable: false),
                        OfficialApparmentNumber = c.String(),
                        PostCode = c.Int(nullable: false),
                        City = c.String(),
                        Country = c.String(),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeOfVehicle = c.String(nullable: false),
                        SpacesNeededDividend = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SpacesNeededDivisor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SpacesNeeded = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParkedVehicles", "VehicleType_Id", "dbo.VehicleTypes");
            DropForeignKey("dbo.ParkedVehicles", "MemberId", "dbo.Members");
            DropIndex("dbo.ParkedVehicles", new[] { "VehicleType_Id" });
            DropIndex("dbo.ParkedVehicles", new[] { "MemberId" });
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.Members");
            DropTable("dbo.ParkedVehicles");
        }
    }
}
