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

        public DateTime DateReport { get; set; }

        public DateTime DateCreate { get; set; }

        public TimeSpan TimeReport { get; set; }

        public string FacultyName { get; set; } = string.Empty;

        public string DirectionName { get; set; } = string.Empty;

        public string GroupName { get; set; } = string.Empty;

        public string SubjectName { get; set; } = string.Empty;

        public string SemesterName { get; set; } = string.Empty;

        public string TeacherName { get; set; } = string.Empty;
    }
}
