namespace UniversityPortalApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePropertyofDepartmentStudent : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Enrollments", new[] { "StudentId" });
            AlterColumn("dbo.Enrollments", "StudentId", c => c.Int());
            CreateIndex("dbo.Enrollments", "StudentId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Enrollments", new[] { "StudentId" });
            AlterColumn("dbo.Enrollments", "StudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Enrollments", "StudentId");
        }
    }
}
