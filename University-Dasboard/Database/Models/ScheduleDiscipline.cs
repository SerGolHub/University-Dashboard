using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_Dasboard.Interfaces;

namespace University_Dasboard.Database.Models
{
	public class ScheduleDiscipline
	{
		public Guid Id { get; set; }

		public Guid SubjectId { get; set; }
		public Subject? Subject { get; set; }

		public Guid FacultyId { get; set; }
        public Faculty? Faculty { get; set; }

		public Guid DirectionId { get; set; }
		public Direction? Direction { get; set; }

		public Guid GroupId { get; set; }
		public Group? Group { get; set; }

		public Guid ScheduleWeekId { get; set; }
		public ScheduleWeek? ScheduleWeek { get; set; }
	}
}
