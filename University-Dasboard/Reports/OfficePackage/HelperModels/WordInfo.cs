using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficePackage.HelperModels
{
    public class WordInfo
    {
        public string FileName { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public DateTime? DateReport { get; set; }

        public TimeSpan TimeReport { get; set; }

        public string FacultyName { get; set; } = string.Empty;
    }
}
