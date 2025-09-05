using Microsoft.EntityFrameworkCore;

namespace OneCToOneCD.Models
{
    public class AppDbContext : DbContext
    { 
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 
            modelBuilder.Entity<Course>()
                .HasOne(c => c.CourseDetails)
                .WithOne()
                .HasForeignKey<Course>(c => c.CourseCode)
                .OnDelete(DeleteBehavior.NoAction); 
                base.OnModelCreating(modelBuilder); 
                
        }

        DbSet<Course> Courses { get; set; }
        DbSet<CourseDetails> CoursesDetails { get; set; }
    }
}
