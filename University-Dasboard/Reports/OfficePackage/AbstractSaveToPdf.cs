using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.ChartDrawing;
using OfficePackage.HelperEnums;
using OfficePackage.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficePackage
{
    public abstract class AbstractSaveToPdf
    {
        public void CreateDoc(PdfInfo info)
        {
            CreatePdf(info);

            // Заголовок
            CreateParagraph(new PdfParagraph
            {
                Text = $"Протокол проверки учебных занятий в {info.SemesterNumber} семестре",
                Style = "Title",
                Font = "Times New Roman",
                FontWeight = "Bold",
                ParagraphAlignment = PdfParagraphAlignmentType.Center
            });

            // Дата
            CreateParagraph(new PdfParagraph
            {
                Text = $"на «{info.DateReport.Day}»   {info.DateReport.ToString("MMMM", new System.Globalization.CultureInfo("ru-RU"))}   {info.DateReport.Year} г.\n\n\n",
                Style = "Title",
                Font = "Times New Roman",
                FontWeight="Bold",
                ParagraphAlignment = PdfParagraphAlignmentType.Center
            });

            // Заголовки таблицы
            CreateTable(new List<string> { "1,5cm", "2cm", "3cm", "3cm", "4cm", "3.5cm" });
            CreateRow(new PdfRowParameters
            {
                Texts = new List<string> { "№ ауд", "Пара", "Группа", "Дисциплина", "Ф.И.О. Преподавателя", "Роспись преподавателя" },
                Style = "TableHeader",
                Font = "Times New Roman",
                FontWeight = "Bold",
                ParagraphAlignment = PdfParagraphAlignmentType.Center
            });

            

            // Итоговые абзацы
            CreateParagraph(new PdfParagraph
            {
                Text = "\n\n\nИтого проверено занятий:      _____  ; из них:",
                Style = "Normal",
                Font = "Times New Roman",
                ParagraphAlignment = PdfParagraphAlignmentType.Left
            });

            CreateParagraph(new PdfParagraph
            {
                Text = "Количество присутствующих: _____",
                Style = "Normal",
                Font = "Times New Roman",
                ParagraphAlignment = PdfParagraphAlignmentType.Left
            });

            CreateParagraph(new PdfParagraph
            {
                Text = "Количество отсутствующих:    _____",
                Style = "Normal",
                Font = "Times New Roman",
                ParagraphAlignment = PdfParagraphAlignmentType.Left
            });

            CreateParagraph(new PdfParagraph
            {
                Text = "Лицо, проводящее проверку: _____________________________________",
                Style = "Normal",
                Font = "Times New Roman",
                ParagraphAlignment = PdfParagraphAlignmentType.Left
            });

            // Разрыв страницы
            CreatePageBreak();

            // Добавление новой строки с "Декану"
            CreateParagraph(new PdfParagraph
            {
                Text = "Декану________________________\n\n\n",
                Style = "Normal",
                Font = "Times New Roman",
                ParagraphAlignment = PdfParagraphAlignmentType.Right
            });

            // Заголовок для новой таблицы
            CreateParagraph(new PdfParagraph
            {
                Text = $"Акт  проверки занятий в {info.SemesterNumber} семестре {info.DateReport.Year}-{info.DateReport.Year + 1} гг.\n\n",
                Style = "Title",
                Font = "Times New Roman",
                FontWeight = "Bold",
                ParagraphAlignment = PdfParagraphAlignmentType.Center
            });

            // Текст рядом с таблицей
            CreateParagraph(new PdfParagraph
            {
                Text = "В указанное время в заявленных аудиториях отсутствовали:",
                Style = "Normal",
                Font = "Times New Roman",
                ParagraphAlignment = PdfParagraphAlignmentType.Center
            });
            

            // Заголовки таблицы для новой таблицы
            CreateTable(new List<string> { "2cm", "1.5cm", "2cm", "2cm", "3cm", "4cm", "3cm" });
            CreateRow(new PdfRowParameters
            {
                Texts = new List<string> { "Дата", "№ ауд.", "Время", "Группа", "Дисциплина", "Ф.И.О. преподавателя", "Примечание" },
                Style = "TableHeader",
                Font = "Times New Roman",
                FontWeight = "Bold",
                ParagraphAlignment = PdfParagraphAlignmentType.Center
            });

           

                // Объяснительная записка преподавателей
                CreateParagraph(new PdfParagraph
                {
                    Text = "\n\n    Объяснительные записки преподавателей с резолюцией декана просьба предоставить в отдел ОУП до   «___» ______________  20___г.\n\n\n",
                    Style = "Normal",
                    ParagraphAlignment = PdfParagraphAlignmentType.Left
                });

                CreateParagraph(new PdfParagraph
                {
                    Text = "Начальник отдела ОУП                          ___________________________",
                    Style = "Normal",
                    ParagraphAlignment = PdfParagraphAlignmentType.Left
                });

            SavePdf(info);
        }




        /// Создание pdf-файла
        protected abstract void CreatePdf(PdfInfo info);

        /// Создание параграфа с текстом
        protected abstract void CreateParagraph(PdfParagraph paragraph);

        /// Создание таблицы
        protected abstract void CreateTable(List<string> columns);

        /// Создание и заполнение строки
        protected abstract void CreateRow(PdfRowParameters rowParameters);

        /// Разрыв страницы
        protected abstract void CreatePageBreak();

        /// Реализация списка
        protected abstract void CreateBulletList(List<string> items);

        /// Сохранение файла
        protected abstract void SavePdf(PdfInfo info);
    }
}
