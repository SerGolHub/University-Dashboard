using University_Dasboard.Interfaces;

namespace University_Dasboard.Database.Models
{
    public class Student : IEntity
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public required string EnrollmentNumber { get; set; }
        public bool IsExcellentStudent { get; set; }
        public int CourseNumber { get; set; }
        public Guid FacultyId { get; set; }
        public Faculty? Faculty { get; set; }
        public Guid GroupId { get; set; }
        public Group? Group { get; set; }
        public Guid DirectionId { get; set; }
        public Direction? Direction { get; set; }
        public ICollection<Marks> Marks { get; set; } = [];
    }
}
