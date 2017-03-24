namespace UniversityPortalApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateErrorLogEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ErrorLogs", "Source", c => c.String());
            AddColumn("dbo.ErrorLogs", "HelpLink", c => c.String());
            AddColumn("dbo.ErrorLogs", "InnerException", c => c.String());
            AddColumn("dbo.ErrorLogs", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ErrorLogs", "CreatedDate");
            DropColumn("dbo.ErrorLogs", "InnerException");
            DropColumn("dbo.ErrorLogs", "HelpLink");
            DropColumn("dbo.ErrorLogs", "Source");
        }
    }
}
