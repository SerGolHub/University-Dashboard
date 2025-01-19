using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_Dasboard.Reports.Models;

namespace OfficePackage.HelperModels
{
    public class WordInfo
    {
        public string FileName { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public bool IsLandscape { get; set; }

        public DateTime? DateReport { get; set; }

        public DateTime DateCreate { get; set; }

        public TimeSpan TimeReport { get; set; }

        public string FacultyName { get; set; } = string.Empty;

        public string DirectionName { get; set; } = string.Empty;

        public string GroupName { get; set; } = string.Empty;

        public string SubjectName { get; set; } = string.Empty;

        public string SemesterName { get; set;} = string.Empty;

        public string TeacherName { get; set; } = string.Empty;

        public string ClassroomNumber { get; set; } = string.Empty;

        public string GroupNameMerge { get; set; } = string.Empty;

        public string Note { get; set; } = string.Empty;

        public int SemesterNumber { get; set; }

        public int LectureHours { get; set; }

        public int PracticalHours { get; set; }

        public int LaboratoryHours { get; set; }

        public string EmptyColumn { get; set; } = string.Empty;
    }
}
