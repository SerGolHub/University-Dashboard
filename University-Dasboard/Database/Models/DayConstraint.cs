using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Dasboard.Database.Models
{
	public class DayConstraint
	{
		public Guid Id { get; set; }

		public Guid TeacherConstraintId { get; set; }
		public TeacherConstraint TeacherConstraint { get; set; } = null!;

		public DayOfWeek DayOfWeek { get; set; } // Хранит конкретный день недели
	}
}
