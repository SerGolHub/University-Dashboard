using OfficePackage.HelperEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficePackage.HelperModels
{
    // Информация по параграфу в Pdf документе
    public class PdfParagraph
    {
        public string Text { get; set; } = string.Empty;

        public string Style { get; set; } = string.Empty;

        public string Font { get; set; } = string.Empty;

        public string FontWeight { get; set; } = string.Empty;

        public bool Underline { get; set; } = false;

        // Коллекция для поддержания разного форматирования в одном параграфе
        public List<PdfSpan> Spans { get; set; } = new List<PdfSpan>();

        // Информация по выравниванию текста в параграфе
        public PdfParagraphAlignmentType ParagraphAlignment { get; set; }
    }
}
