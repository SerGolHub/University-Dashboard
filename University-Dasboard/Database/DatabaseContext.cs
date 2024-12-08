using Microsoft.EntityFrameworkCore;
using University_Dasboard.Database.Configs;
using University_Dasboard.Database.Models;

namespace Database
{
    public class DatabaseContext: DbContext
    {
        public DbSet<Department> Department { get; set; }
        public DbSet<Direction> Direction{ get; set; }
        public DbSet<Faculty> Faculty{ get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Marks> Marks { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Discipline> Discipline { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepartmentCfg());
            modelBuilder.ApplyConfiguration(new DirectionCfg());
            modelBuilder.ApplyConfiguration(new FacultyCfg());
            modelBuilder.ApplyConfiguration(new GroupCfg());
            modelBuilder.ApplyConfiguration(new MarksCfg());
            modelBuilder.ApplyConfiguration(new StudentCfg());
            modelBuilder.ApplyConfiguration(new DisciplineCfg());
            modelBuilder.ApplyConfiguration(new TeacherCfg());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql($"Host=localhost;Database=uni;Username=zorg;Password=zorg");
        }
    }
}
