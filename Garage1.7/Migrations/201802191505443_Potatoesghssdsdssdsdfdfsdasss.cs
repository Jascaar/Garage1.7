namespace Garage1._7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Potatoesghssdsdssdsdfdfsdasss : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VehicleTypes", "SpacesNeededDividend", c => c.Int(nullable: false));
            AlterColumn("dbo.VehicleTypes", "SpacesNeededDivisor", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VehicleTypes", "SpacesNeededDivisor", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.VehicleTypes", "SpacesNeededDividend", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
