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

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseDetails> CoursesDetails { get; set; }
    }
}
