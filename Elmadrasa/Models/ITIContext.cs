using Microsoft.EntityFrameworkCore;
namespace WebApplicationlab09.Models
{
    public class ITIContext:DbContext
    {
        public ITIContext() : base()
        {
        }
        public ITIContext(DbContextOptions<ITIContext> options)
           : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Users> users { get; set; }

        public DbSet<Students> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<DepartCourses> DeptCourses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=lab9;Integrated Security=True;encrypt=false;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartCourses>()
           .HasKey(dc => new { dc.DeptId, dc.CourseId });
            modelBuilder.Entity<Department>()
           .HasMany<Courses>(d => d.Courses);
            modelBuilder.Entity<Courses>()
          .HasMany<Department>(c => c.depts);



        }

    }
}
