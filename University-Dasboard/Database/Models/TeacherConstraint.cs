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

        // День недели, когда преподаватель может работать
        public DayOfWeek DayOfWeek { get; set; }

        // Диапазон времени
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        // Комментарий или пожелание, если нужно уточнить ограничение
        public string Note { get; set; } = string.Empty;
	}
}
