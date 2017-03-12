namespace UniversityPortalApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inital : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        Unit = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zipcode = c.Int(nullable: false),
                        Country = c.String(),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                        HeadOfDepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Instructors", t => t.HeadOfDepartmentId, cascadeDelete: true)
                .Index(t => t.HeadOfDepartmentId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                        Credits = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        InstructorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .ForeignKey("dbo.Instructors", t => t.InstructorId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId)
                .Index(t => t.InstructorId);
            
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Departments", "HeadOfDepartmentId", "dbo.Instructors");
            DropForeignKey("dbo.Enrollments", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Enrollments", "InstructorId", "dbo.Instructors");
            DropForeignKey("dbo.Instructors", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Instructors", new[] { "DepartmentId" });
            DropIndex("dbo.Enrollments", new[] { "InstructorId" });
            DropIndex("dbo.Enrollments", new[] { "CourseId" });
            DropIndex("dbo.Enrollments", new[] { "StudentId" });
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            DropIndex("dbo.Departments", new[] { "HeadOfDepartmentId" });
            DropIndex("dbo.Students", new[] { "DepartmentId" });
            DropIndex("dbo.Addresses", new[] { "StudentId" });
            DropTable("dbo.Instructors");
            DropTable("dbo.Enrollments");
            DropTable("dbo.Courses");
            DropTable("dbo.Departments");
            DropTable("dbo.Students");
            DropTable("dbo.Addresses");
        }
    }
}
