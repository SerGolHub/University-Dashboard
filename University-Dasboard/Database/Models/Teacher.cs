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
        public ICollection<Discipline> Subjects { get; set; } = [];
        public Guid DeparatmentId { get; set; }
        public Department? Department { get; set; }

		// Для составления расписания
		public ICollection<ScheduleWeek> Schedules { get; set; }
	}
}
