namespace Garage1._7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Potatoesghssdsds : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "FirstName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "FirstName", c => c.String(nullable: false));
        }
    }
}
