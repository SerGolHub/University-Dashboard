using ClassroomSchedulerBusinessLogic.OfficePackage.HelperEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomSchedulerBusinessLogic.OfficePackage.HelperModels
{
    public class WordRowParameters
    {
        // Набор строк, которые будут вставлены в документ
        public List<string> Texts { get; set; } = new List<string>();

        // Стиль текста для всего набора
        public string TextStyle { get; set; } = string.Empty;

        // Свойства параграфа, если они есть
        public WordTextProperties? TextProperties { get; set; }

        // Новый список для задания поворота текста в каждой ячейке
        public List<int> Rotations { get; set; } = new List<int>();

        // Параметры выравнивания для всего текста
        public WordJustificationType JustificationType { get; set; }
    }
}
