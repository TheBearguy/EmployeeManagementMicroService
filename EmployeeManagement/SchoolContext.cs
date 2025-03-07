using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base()
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }
    }
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {a
    //        //base.OnModelCreating(modelBuilder);
    //        modelBuilder.Entity<Student>()
    //            .HasOptional(s => s.Address)
    //            .WithRequired(ad => ad.Student);    
    //    }
    //}

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        //base.OnModelCreating(modelBuilder);
    //        modelBuilder.Entity<Student>()
    //            .HasMany<Course>(s => s.Courses)
    //            .WithMany(c => c.Students)
    //            .Map(
    //                cs =>
    //                {
    //                    cs.MapLeftKey("StudentRefId");
    //                    cs.MapRightKey("CourseRefId");
    //                    cs.ToTable("StudentCourse");
    //                }
    //            )
    //    }
    }
