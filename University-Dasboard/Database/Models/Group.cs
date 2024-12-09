﻿using University_Dasboard.Interfaces;

namespace University_Dasboard.Database.Models
{
    public class Group : IEntity
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public int MaxCourse { get; set; }
        public Guid DirectionId { get; set; }
        public Direction? Direction { get; set; }
        public Guid DeparatmentId { get; set; }
        public Department? Department { get; set; }
        public ICollection<Student> Students { get; set; } = [];
        public ICollection<Discipline> Disciplines { get; set; } = [];

		public ICollection<ScheduleDiscipline> ScheduleDisciplines { get; set; }
	}
}
