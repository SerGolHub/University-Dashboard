using University_Dasboard.Interfaces;

namespace University_Dasboard.Database.Models
{
    public class Subject : IEntity
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }

        public Guid DepartmentId { get; set; }
        public Department? Department { get; set; }

        public Guid TeacherId { get; set; }
        public Teacher? Teacher { get; set; }

        public ICollection<Group> Groups { get; set; } = [];
        public ICollection<Marks> Marks { get; set; } = [];

		public ICollection<ScheduleDiscipline> ScheduleDisciplines { get; set; }
	}
}
