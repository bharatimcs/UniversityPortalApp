namespace UniversityPortalApp.Data
{
    using System;
    using Core;
    using System.Data.Entity;
    using System.Linq;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UniversityContext : DbContext
    {
        // Your context has been configured to use a 'University' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'UniversityPortalApp.Data.University' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'University' 
        // connection string in the application configuration file.
        public UniversityContext()
            : base("name=UniversityConnection")
        {
            
        }


        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }

        public virtual DbSet<Enrollment> Enrollments { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //student has many addresses
            modelBuilder.Entity<Student>()
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Course>()
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Address>()
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Department>()
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Instructor>()
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Enrollment>()
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Address>()
                .HasRequired<Student>(s => s.Student)
                .WithMany(ad => ad.Addresses)
                .HasForeignKey(x=>x.StudentId)
                .WillCascadeOnDelete(false);

            //Department has many Instructors
            modelBuilder.Entity<Instructor>()
                .HasRequired<Department>(i => i.Department)
                .WithMany(d => d.Instructors)
                .HasForeignKey(x=>x.DepartmentId)
                .WillCascadeOnDelete(false);

            //Course has many students
            modelBuilder.Entity<Enrollment>()
                .HasRequired<Course>(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(x=>x.CourseId)
                .WillCascadeOnDelete(false);

            //Students has enrolled many courses
            modelBuilder.Entity<Enrollment>()
                .HasOptional<Student>(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(x=>x.StudentId)
                .WillCascadeOnDelete(false);

            //Instructor can teach many courses
            modelBuilder.Entity<Enrollment>()
                .HasRequired<Instructor>(e => e.Instructor)
                .WithMany(i => i.Enrollments)
                .HasForeignKey(x=>x.InstructorId)
                .WillCascadeOnDelete(false);

        }
    }
    
}