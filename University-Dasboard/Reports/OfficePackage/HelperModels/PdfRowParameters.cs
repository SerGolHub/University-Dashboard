﻿using OfficePackage.HelperEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficePackage.HelperModels
{
    // Информация по параметрам строк таблицы
    public class PdfRowParameters
    {
        // Набор текстов
        public List<string> Texts { get; set; } = new();

        // Стиль к текстам
        public string Style { get; set; } = string.Empty;

        public string Font { get; set; } = string.Empty;

        public string FontWeight { get; set; } = string.Empty;

        // Количество ячеек для объединения по горизонтали
        public List<int> MergeColumns1 { get; set; } = null!;

        public List<int> MergeColumns2 { get; set; } = null!;

        // Количество ячеек для объединения по вертикали
        public List<int> MergeRows { get; set; } = null!;

        // Новый список для задания поворота текста в каждой ячейке
        public List<int> Rotations { get; set; } = new List<int>();

        // Как выравниваем
        public PdfParagraphAlignmentType ParagraphAlignment { get; set; }
    }
}
