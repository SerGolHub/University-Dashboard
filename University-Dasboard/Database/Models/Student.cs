using University_Dasboard.Interfaces;

namespace University_Dasboard.Database.Models
{
    public class Student : IEntity
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public required string EnrollmentNumber { get; set; }
        public bool IsExcellentStudent { get; set; } = false;

        public Guid GroupId { get; set; }
        public Group? Group { get; set; }

        public ICollection<Marks> Marks { get; set; } = [];
    }
}
