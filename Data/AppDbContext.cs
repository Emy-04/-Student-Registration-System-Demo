using Microsoft.EntityFrameworkCore;
using UniWebApp.Models;

namespace UniWebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Course>()
                .HasMany(c => c.Prerequisites)
                .WithMany(c => c.RequiredBy)
                .UsingEntity<Dictionary<string, object>>(
                    "CoursePrerequisite",
                    j => j.HasOne<Course>().WithMany().HasForeignKey("PrerequisiteCourseId"),
                    j => j.HasOne<Course>().WithMany().HasForeignKey("CourseId"),
                    j =>
                    {
                        j.HasKey("CourseId", "PrerequisiteCourseId");
                    });

        //    modelBuilder.Entity<User>()
        //.HasOne(u => u.Department)
        //.WithMany(d => d.Students)
        //.HasForeignKey(u => u.DepartmentId)
        //.OnDelete(DeleteBehavior.NoAction);

       //     modelBuilder.Entity<Course>()
       //.HasOne(c => c.Department)
       //.WithMany(d => d.Courses)
       //.HasForeignKey(c => c.DepartmentId)
       //.OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Enrollment>()
       .HasOne(e => e.User)
       .WithMany()
       .HasForeignKey(e => e.UserId)
       .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany()
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
