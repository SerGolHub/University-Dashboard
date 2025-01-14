using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficePackage.HelperModels
{
    // Модель параграфов, которые есть в тексте
    public class WordParagraph
    {
        // Набор текстов в абзаце (для случая, если в абзаце текст разных стилей)
        public List<(string, WordTextProperties)> Texts { get; set; } = new();

        // Стиль текста для всего набора
        public string TextStyle { get; set; } = string.Empty;

        public List<List<(string, WordTextProperties)>> RowTexts { get; set; } = new();
    }
}
