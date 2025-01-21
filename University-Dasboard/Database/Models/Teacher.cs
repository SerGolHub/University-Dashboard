using University_Dasboard.Interfaces;

namespace University_Dasboard.Database.Models
{
    public class Teacher : IEntity
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required string PhoneNumber {  get; set; }

        public required string Email {  get; set; }

        public DateTime HireDate {  get; set; }

        public required string Degree { get; set; }

        public required string Status { get; set; }

        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();

        public Guid DepartmentId { get; set; }
        public Department? Department { get; set; }

		// Для составления расписания
		public ICollection<ScheduleDiscipline> Schedules { get; set; } = null!;

        // Для составления расписания
        public ICollection<SchedulePair> SchedulePairs { get; set; } = null!;

        // Ограничения преподавателя
        public ICollection<TeacherConstraint> Constraints { get; set; } = new List<TeacherConstraint>();
	}
}
