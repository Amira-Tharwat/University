using Microsoft.EntityFrameworkCore;
using University.Models;

namespace University.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)  {  }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Professor> Professors { get; set;}
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Department>().HasData(
                new Models.Department { Id = 1, Name = "Natural Sciences" },
                new Models.Department { Id = 2, Name = "Math" }
                );
            modelBuilder.Entity<Models.Professor>().HasData(
                new Models.Professor { Id=1 , DId=1,Name="ali"},
                new Models.Professor { Id = 2, DId = 2, Name = "amira" }
                );
        }
    }
}
