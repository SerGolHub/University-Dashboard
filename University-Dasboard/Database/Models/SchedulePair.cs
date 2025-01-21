using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_Dasboard.Database.Enums;
using University_Dasboard.Interfaces;

namespace University_Dasboard.Database.Models
{
    public class SchedulePair
    {
        public Guid Id { get; set; }

        public int NumberPair { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public TimeSpan StartTime { get; set; } // Время начала пары
        public TimeSpan EndTime { get; set; } // Время окончания пары

        public string SubjectName { get; set; } = null!; // Предмет
        public string ClassroomName { get; set; } = null!; // Аудитория
        public string TeacherName { get; set; } = null!; // Преподаватель

        public Guid TeacherId { get; set; }
        public Teacher? Teacher { get; set; }

        public Guid ScheduleDisciplineId { get; set; }
        public ScheduleDiscipline? ScheduleDiscipline { get; set; }
    }
}
