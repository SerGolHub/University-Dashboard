using ClassroomSchedulerContracts.ViewModels;
using ClassroomSchedulerContracts.ViewModels.ReportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomSchedulerBusinessLogic.OfficePackage.HelperModels
{
    public class WordInfo
    {
        public string FileName { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public int SemesterNumber { get; set; }

        public DateTime? DateReport { get; set; }

        public TimeSpan TimeReport { get; set; }

        public DateTime DateCreate { get; set; }

        public int ClassroomNumber { get; set; }

        public int JobStationNumber { get; set; }

        public string ClassroomName { get; set; } = string.Empty;

        public string HeadLaboratory { get; set; } = string.Empty;

        public string HeadDepartment { get; set; } = string.Empty;

        // Списки для отчёта
        public List<ScheduleTablePartViewModel> ReportCheckLesson { get; set; } = new();
    }
}
