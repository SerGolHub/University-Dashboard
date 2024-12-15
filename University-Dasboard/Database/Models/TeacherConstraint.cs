using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Dasboard.Database.Models
{
	public class TeacherConstraint
	{
		public Guid Id { get; set; }

		public Guid TeacherId { get; set; }

		public Teacher Teacher { get; set; } = null!;

		// Ограничение по дням недели
		public ICollection<DayConstraint> DayConstraints { get; set; } = new List<DayConstraint>();

		// Комментарий или пожелание, если нужно уточнить ограничение
		public string Note { get; set; } = string.Empty; // Опциональное поле для пояснения
	}
}
