using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Dasboard.Reports.Models
{
    public class ReportShufflingViewModel
    {
        public Guid Id { get; set; }

        public Guid SubjectId { get; set; }
        public string SubjectName { get; set; } = string.Empty;

        public Guid FacultyId { get; set; }
        public string FacultyName { get; set; } = string.Empty;

        public Guid DirectionId { get; set; }
        public string DirectionName { get; set; } = string.Empty;

        public Guid GroupId { get; set; }
        public string GroupName { get; set; } = string.Empty;

        public Guid ScheduleWeekId { get; set; }

        public string ScheduleWeek { get; set; } = string.Empty;

        public int LectureHours { get; set; }

        public int PracticalHours { get; set; }

        public int LaboratoryHours { get; set; }

        public string TeacherName { get; set; } = string.Empty;

        public string EmptyColumn { get; set; } = string.Empty;

        public DateTime DateReport { get; set; }
    }
}
