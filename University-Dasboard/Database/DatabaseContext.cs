using dotenv.net;
using Microsoft.EntityFrameworkCore;
using University_Dasboard.Database.Configs;
using University_Dasboard.Database.Models;

namespace Database
{
	public class DatabaseContext : DbContext
	{
		public DbSet<Department> Department { get; set; }
		public DbSet<Direction> Direction { get; set; }
		public DbSet<Faculty> Faculty { get; set; }
		public DbSet<Group> Group { get; set; }
		public DbSet<Marks> Marks { get; set; }
		public DbSet<Student> Student { get; set; }
		public DbSet<Subject> Subject { get; set; }
		public DbSet<Teacher> Teacher { get; set; }
		public DbSet<TeacherConstraint> TeacherConstraints { get; set; }
		public DbSet<User> User { get; set; }
		public DbSet<ScheduleWeek> ScheduleWeek { get; set; }
		public DbSet<ScheduleDiscipline> ScheduleDisciplines { get; set; }
        public DbSet<SchedulePair> SchedulePairs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new DepartmentCfg());
			modelBuilder.ApplyConfiguration(new DirectionCfg());
			modelBuilder.ApplyConfiguration(new FacultyCfg());
			modelBuilder.ApplyConfiguration(new GroupCfg());
			modelBuilder.ApplyConfiguration(new MarksCfg());
			modelBuilder.ApplyConfiguration(new StudentCfg());
			modelBuilder.ApplyConfiguration(new SubjectCfg());
			modelBuilder.ApplyConfiguration(new TeacherCfg());
			modelBuilder.ApplyConfiguration(new TeacherCfg());
			modelBuilder.ApplyConfiguration(new ScheduleWeekCfg());

			base.OnModelCreating(modelBuilder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			DotEnv.Load();
			optionsBuilder.UseNpgsql($"Host={Environment.GetEnvironmentVariable("HOST")};" +
				$"Database={Environment.GetEnvironmentVariable("DATABASE")};" +
				$"Username={Environment.GetEnvironmentVariable("USER")};" +
				$"Password={Environment.GetEnvironmentVariable("PASSWORD")}");
		}
	}
}
