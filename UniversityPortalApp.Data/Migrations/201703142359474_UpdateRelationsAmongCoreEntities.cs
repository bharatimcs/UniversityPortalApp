namespace UniversityPortalApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRelationsAmongCoreEntities : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Enrollments", "InstructorId", "dbo.Instructors");
            DropIndex("dbo.Students", new[] { "DepartmentId" });
            DropIndex("dbo.Instructors", new[] { "DepartmentId" });
            AlterColumn("dbo.Students", "DepartmentId", c => c.Int());
            AlterColumn("dbo.Instructors", "DepartmentId", c => c.Int());
            CreateIndex("dbo.Students", "DepartmentId");
            CreateIndex("dbo.Instructors", "DepartmentId");
            AddForeignKey("dbo.Addresses", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "DepartmentId", "dbo.Departments", "Id");
            AddForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Enrollments", "InstructorId", "dbo.Instructors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "InstructorId", "dbo.Instructors");
            DropForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Addresses", "StudentId", "dbo.Students");
            DropIndex("dbo.Instructors", new[] { "DepartmentId" });
            DropIndex("dbo.Students", new[] { "DepartmentId" });
            AlterColumn("dbo.Instructors", "DepartmentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Instructors", "DepartmentId");
            CreateIndex("dbo.Students", "DepartmentId");
            AddForeignKey("dbo.Enrollments", "InstructorId", "dbo.Instructors", "Id");
            AddForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses", "Id");
            AddForeignKey("dbo.Students", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Addresses", "StudentId", "dbo.Students", "Id");
        }
    }
}
