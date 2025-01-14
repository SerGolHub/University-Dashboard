using OfficePackage.HelperEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficePackage.HelperModels
{
    // Модель свойств текста, которые нам нужны в word документе
    public class WordTextProperties
    {
        // Размере текста
        public string Size { get; set; } = string.Empty;

        // Надо ли делать его жирным
        public bool Bold { get; set; }

        public bool Underline { get; set; } = false;

        public bool Indentation { get; set; } = false;

        public bool SpaceBetween { get; set; } = false;

        // Выравнивание
        public WordJustificationType JustificationType { get; set; }
    }
}
