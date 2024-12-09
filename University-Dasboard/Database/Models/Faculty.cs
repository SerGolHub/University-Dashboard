using University_Dasboard.Interfaces;

namespace University_Dasboard.Database.Models
{
    public class Faculty: IEntity
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public ICollection<Department> Departments { get; set; } = [];
        public ICollection<Direction> Directions { get; set; } = [];
        public ICollection<Student> Students{ get; set; } = []; // ?
	}
}
