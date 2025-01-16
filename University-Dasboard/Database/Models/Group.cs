using University_Dasboard.Interfaces;

namespace University_Dasboard.Database.Models
{
    public class Group : IEntity
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public int CourseNumber { get; set; }

        public Guid DirectionId { get; set; }
        public Direction? Direction { get; set; }

        public ICollection<Student> Students { get; set; } = [];

        public ICollection<ScheduleDiscipline> ScheduleDisciplines { get; set; } = null!;
	}
}
