using University_Dasboard.Interfaces;

namespace University_Dasboard.Database.Models
{
    public class Department: IEntity
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public Guid FacultyId { get; set; }
        public Faculty? Faculty { get; set; }
        public ICollection<Direction> Directions { get; set; } = [];
        public ICollection<Discipline> Disciplines { get; set; } = [];
        public ICollection<Teacher> Teachers { get; set; } = [];
    }
}
