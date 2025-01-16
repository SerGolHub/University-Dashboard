using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_Dasboard.Database.Enums;

namespace University_Dasboard.Database.Models
{
    public class Schedule
    {
        public Guid Id { get; set; }

        public TimeSpan timeBegin { get; set; }

        public TimeSpan timeEnd { get; set; }

        public DayOfWeekEnum DayOfWeek { get; set; }

    }
}
