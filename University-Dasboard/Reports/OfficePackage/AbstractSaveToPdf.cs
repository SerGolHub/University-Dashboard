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
            info.IsLandscape = true;

            CreatePdf(info);          

            // Заголовок
            CreateParagraph(new PdfParagraph
            {
                Text = $"РАСЧАСОВКА НА КАЖДУЮ ГРУППУ",
                Style = "Title",
                Font = "Times New Roman",
                FontWeight = "Bold",
                ParagraphAlignment = PdfParagraphAlignmentType.Center
            });

            // Заголовок
            CreateParagraph(new PdfParagraph
            {
                Text = $"ГРАФИК УЧЕБНОГО ПРОЦЕССА\n\n",
                Style = "Title",
                Font = "Times New Roman",
                FontWeight = "Bold",
                ParagraphAlignment = PdfParagraphAlignmentType.Center
            });

            // Предтабличная информация о группе, преподавателе и тд.
            CreateParagraph(new PdfParagraph
            {
                Text = $"Факультет: {info.FacultyName},            Направление: {info.DirectionName},            Группа: {info.GroupName}\n\n",
                Style = "Normal",
                Font = "Times New Roman",
                ParagraphAlignment = PdfParagraphAlignmentType.Justify
            });

            CreateParagraph(new PdfParagraph
            {
                Text = $"Дисциплина: {info.SubjectName},            {info.SemesterName} {info.DateCreate.Year}-{info.DateCreate.Year+1}гг.,            Преподаватель: {info.TeacherName}\n\n",
                Style = "Normal",
                Font = "Times New Roman",
                ParagraphAlignment = PdfParagraphAlignmentType.Justify
            });

            // Заголовки таблицы
            CreateTable(new List<string> { "5cm", "2cm", "0.7cm", "0.7cm", "0.7cm", "0.7cm", "0.7cm", "0.7cm", "0.7cm", "0.7cm", "0.7cm", "1cm", "1cm", "1cm", "1cm", "1cm", "1cm", "1cm", "1cm", "1cm", "1cm", "3.3cm" });
            CreateRow(new PdfRowParameters
            {
                Texts = new List<string> { "Форма занятий", "Недели", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "∑", "Отчётность" },
                Style = "TableHeader",
                Font = "Times New Roman",
                FontWeight = "Bold",
                ParagraphAlignment = PdfParagraphAlignmentType.Center
            });

            // Данные таблицы
            CreateRow(new PdfRowParameters
            {
                Texts = new List<string> { "1. Лекции занятий", "аудит.", "2", "", "2", "", "2", "", "2", "", "2", "", "2", "", "2", "", "2", "", "", "", "", " " },
                Style = "TableHeader",
                Font = "Times New Roman",
                FontWeight = "Bold",
                ParagraphAlignment = PdfParagraphAlignmentType.Left
            });

            // Данные таблицы
            CreateRow(new PdfRowParameters
            {
                Texts = new List<string> { " ", $"{info.ClassroomNumber}", $"{info.TeacherName}", "", "", "", "", "", "", "", $"{info.TeacherName}", "", "", "", "", "", "", "", "", "", "", " " },
                Style = "TableHeader",
                Font = "Times New Roman",
                MergeColumns1 = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9 }, // Объединение первой ячейки с соседними
                MergeColumns2 = new List<int> { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 },
                FontWeight = "Bold",
                ParagraphAlignment = PdfParagraphAlignmentType.Left
            });

            // Данные таблицы
            CreateRow(new PdfRowParameters
            {
                Texts = new List<string> { "2. Практические занятий", "аудит.", "", "2", "", "2", "", "2", "", "2", "", "2", "", "2", "", "2", "", "2", "", "", "", "" },
                Style = "TableHeader",
                Font = "Times New Roman",
                FontWeight = "Bold",
                ParagraphAlignment = PdfParagraphAlignmentType.Left
            });

            // Данные таблицы
            CreateRow(new PdfRowParameters
            {
                Texts = new List<string> { "", $"{info.ClassroomNumber}", $"{info.TeacherName}", "", "", "", "", "", "", "", $"{info.TeacherName}", "", "", "", "", "", "", "", "", "", "", "" },
                Style = "TableHeader",
                Font = "Times New Roman",
                MergeColumns1 = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9 }, // Объединение первой ячейки с соседними
                MergeColumns2 = new List<int> { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 },
                FontWeight = "Bold",
                ParagraphAlignment = PdfParagraphAlignmentType.Left
            });

            // Данные таблицы
            CreateRow(new PdfRowParameters
            {
                Texts = new List<string> { "3. Лабораторные занятий", "аудит.", "2", "2", "2", "2", "2", "2", "2", "2", "2", "2", "2", "2", "2", "2", "2", "2", "", "", "", "" },
                Style = "TableHeader",
                Font = "Times New Roman",
                FontWeight = "Bold",
                ParagraphAlignment = PdfParagraphAlignmentType.Left
            });

            // Данные таблицы
            CreateRow(new PdfRowParameters
            {
                Texts = new List<string> { "", $"{info.ClassroomNumber}", $"1-я подгруппа {info.TeacherName}, 2-ая подгруппа {info.TeacherName}", "", "", "", "", "", "", "", $"1-я подгруппа {info.TeacherName}, 2-ая подгруппа {info.TeacherName}", "", "", "", "", "", "", "", "", "", "", "" },
                Style = "TableHeader",
                Font = "Times New Roman",
                MergeColumns1 = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9 }, // Объединение первой ячейки с соседними
                MergeColumns2 = new List<int> { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 },
                FontWeight = "Bold",
                ParagraphAlignment = PdfParagraphAlignmentType.Left
            });

            // Подвал таблицы
            CreateRow(new PdfRowParameters
            {
                Texts = new List<string> { "Всего", "аудит.", "4", "4", "4", "4", "4", "4", "4", "4", "4", "4", "4", "4", "4", "4", "4", "4", " ", " ", "64", " " },
                Style = "TableFooter",
                Font = "Times New Roman",
                FontWeight = "Bold",
                ParagraphAlignment = PdfParagraphAlignmentType.Center
            });

            // Подвал таблицы
            CreateRow(new PdfRowParameters
            {
                Texts = new List<string> { "Объединить с потоком", $"Лекции объединить с {info.GroupNameMerge}", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", " ", " ", "", "Зав. кафедрой" },
                Style = "TableFooter",
                Font = "Times New Roman",
                MergeColumns1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, // Объединение первой ячейки с соседними
                FontWeight = "Bold",
                ParagraphAlignment = PdfParagraphAlignmentType.Left
            });

            // Подвал таблицы
            CreateRow(new PdfRowParameters
            {
                Texts = new List<string> { "Пожелания с потоком", $"{info.Note}.\r\nЛабораторные занятия ставить для подгруппы спаренные (две пары подряд)\r\n", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", " ", " ", "", " " },
                Style = "TableFooter",
                Font = "Times New Roman",
                MergeColumns1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, // Объединение первой ячейки с соседними
                FontWeight = "Bold",
                ParagraphAlignment = PdfParagraphAlignmentType.Left
            });

            // Информация на следующей странице
            CreateParagraph(new PdfParagraph
            {
                Text = "Примечания:\n1. Пример примечания для расписания.\n2. Внесите сюда любые дополнительные данные.",
                Style = "Normal",
                Font = "Times New Roman",
                ParagraphAlignment = PdfParagraphAlignmentType.Left
            });

            SavePdf(info);
        }

        public void CreateCheckLesson(PdfInfo info)
        {
            CreatePdf(info);

            // Заголовок
            CreateParagraph(new PdfParagraph
            {
                Text = $"Протокол проверки учебных занятий в {info.SemesterName} семестре",
                Style = "Title",
                Font = "Times New Roman",
                FontWeight = "Bold",
                ParagraphAlignment = PdfParagraphAlignmentType.Center
            });

            // Дата
            CreateParagraph(new PdfParagraph
            {
                Text = $"на «{info.DateCreate.Day}»   {info.DateCreate.ToString("MMMM", new System.Globalization.CultureInfo("ru-RU"))}   {info.DateCreate.Year} г.\n\n\n",
                Style = "Title",
                Font = "Times New Roman",
                FontWeight = "Bold",
                ParagraphAlignment = PdfParagraphAlignmentType.Center
            });

            // Заголовки таблицы
            CreateTable(new List<string> { "2cm", "3cm", "3cm", "4cm", "3.5cm" });
            CreateRow(new PdfRowParameters
            {
                Texts = new List<string> { "Пара", "Группа", "Дисциплина", "Ф.И.О. Преподавателя", "Роспись преподавателя" },
                Style = "TableHeader",
                Font = "Times New Roman",
                FontWeight = "Bold",
                ParagraphAlignment = PdfParagraphAlignmentType.Center
            });

            // Данные таблицы
           /* foreach (var report in info.ReportCheckLesson)
            {
                CreateRow(new PdfRowParameters
                {
                    Texts = new List<string>
                {
                    report.GroupName.ToString()
                    report.SubjectNumber.ToString(),
                    report.TeacherName.ToString(),
                    report.EmptyColumn.ToString()
                },
                    Style = "Normal",
                    Font = "Times New Roman",
                    ParagraphAlignment = PdfParagraphAlignmentType.Left
                });
            }*/

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
                Text = $"Акт  проверки занятий в {info.SemesterName} семестре {info.DateCreate.Year}-{info.DateCreate.Year + 1} гг.\n\n",
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
            CreateTable(new List<string> { "2cm", "2cm", "2cm", "3cm", "4cm", "3cm" });
            CreateRow(new PdfRowParameters
            {
                Texts = new List<string> { "Дата", "Время", "Группа", "Дисциплина", "Ф.И.О. преподавателя", "Примечание" },
                Style = "TableHeader",
                Font = "Times New Roman",
                FontWeight = "Bold",
                ParagraphAlignment = PdfParagraphAlignmentType.Center
            });

            // Дополнительно можно заполнить таблицу с данными, если они имеются
           /* foreach (var item in info.ReportCheckLesson)
            {
                CreateRow(new PdfRowParameters
                {
                    Texts = new List<string>
                    {
                        {info.DateReport.ToShortDateString()},
                        info.DateReport.ToShortTimeString(),
                        info.GroupName.ToString()
                        info.SubjectName.ToString(),
                        info.TeacherName.ToString(),
                        info.EmptyColumn.ToString()

                    },
                    Font = "Times New Roman",
                    Style = "TableText",
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
            }*/

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
