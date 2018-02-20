namespace Garage1._7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppartmentNumber : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "PostCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "PostCode", c => c.Int(nullable: false));
        }
    }
}
