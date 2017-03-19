namespace UniversityPortalApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePropertyOfAddress : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "Zipcode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addresses", "Zipcode", c => c.Int(nullable: false));
        }
    }
}
