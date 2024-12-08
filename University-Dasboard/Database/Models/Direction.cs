using University_Dasboard.Interfaces;

namespace University_Dasboard.Database.Models
{
    public class Direction: IEntity
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Code { get; set; }
        public int MaxCourse { get; set; }
        public Guid FacultyId { get; set; }
        public Faculty? Faculty { get; set; }
        public Guid DepartmentId { get; set; }
        public Department? Department { get; set; }
        public ICollection<Group> Groups { get; set; } = [];
    }
}
