namespace Garage1._7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaa1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "OfficialApparmentNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "OfficialApparmentNumber", c => c.String());
        }
    }
}
