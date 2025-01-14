using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficePackage.HelperModels
{
    public class PdfInfo
    {
        public string FileName { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public int SemesterNumber { get; set; }

        public DateTime DateReport { get; set; }

        public DateTime DateCreate { get; set; }

        public TimeSpan TimeReport { get; set; }

        public int ClassroomNumber { get; set; }

        public int JobStationNumber { get; set; }

        public string ClassroomName { get; set; } = string.Empty;

        public string HeadLaboratory { get; set; } = string.Empty;

        public string HeadDepartment { get; set; } = string.Empty;

        public string GroupName { get; set; } = string.Empty;

    }
}
