using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_Dasboard.Interfaces;

namespace University_Dasboard.Database.Models
{
	public class ScheduleWeek : IEntity
	{
		public Guid Id { get; set; }

		public required string Name { get; set; }	// Для Week

		public int LectureHours { get; set; }
		public int PracticalHours { get; set; }
		public int LaboratoryHours { get; set; }

		public ICollection<ScheduleDiscipline> ScheduleDisciplines { get; set; } = null!;
	}
}
