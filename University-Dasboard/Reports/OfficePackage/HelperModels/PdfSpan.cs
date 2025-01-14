using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomSchedulerBusinessLogic.OfficePackage.HelperModels
{
    public class PdfSpan
    {
        // Описание отдельного фрагмента текста (спана)
        public string Text { get; set; } = string.Empty;

        public string Font { get; set; } = "Times New Roman";

        public string FontWeight { get; set; } = "Normal";

        public bool Underline { get; set; } = false;
    }

}
