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
                Text = $"Дисциплина: {info.SubjectName},            {info.SemesterName},            Преподаватель: {info.TeacherName}\n\n",
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
                Texts = new List<string> { "1. Практические занятий", "аудит.", "", "2", "", "2", "", "2", "", "2", "", "2", "", "2", "", "2", "", "2", "", "", "", "Отчётность" },
                Style = "TableHeader",
                Font = "Times New Roman",
                FontWeight = "Bold",
                ParagraphAlignment = PdfParagraphAlignmentType.Left
            });

            // Данные таблицы
            CreateRow(new PdfRowParameters
            {
                Texts = new List<string> { "", $"{info.ClassroomNumber}", $"{info.TeacherName}", "", "", "", "", "", "", "", $"{info.TeacherName}", "", "", "", "", "", "", "", "", "", "", "Отчётность" },
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
                Texts = new List<string> { "1. Практические занятий", "аудит.", "2", "2", "2", "2", "2", "2", "2", "2", "2", "2", "2", "2", "2", "2", "2", "2", "", "", "", "Отчётность" },
                Style = "TableHeader",
                Font = "Times New Roman",
                FontWeight = "Bold",
                ParagraphAlignment = PdfParagraphAlignmentType.Left
            });

            // Данные таблицы
            CreateRow(new PdfRowParameters
            {
                Texts = new List<string> { "", $"{info.ClassroomNumber}", $"1-я подгруппа {info.TeacherName}, 2-ая подгруппа {info.TeacherName}", "", "", "", "", "", "", "", $"1-я подгруппа {info.TeacherName}, 2-ая подгруппа {info.TeacherName}", "", "", "", "", "", "", "", "", "", "", "Отчётность" },
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
                Texts = new List<string> { "Объединить с потоком", $"Лекции объединить с {info.GroupName}", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", " ", " ", "", "Зав. кафедрой" },
                Style = "TableFooter",
                Font = "Times New Roman",
                MergeColumns1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, // Объединение первой ячейки с соседними
                FontWeight = "Bold",
                ParagraphAlignment = PdfParagraphAlignmentType.Left
            });

            // Подвал таблицы
            CreateRow(new PdfRowParameters
            {
                Texts = new List<string> { "Пожелания с потоком", "Занятия планировать по пнд, вт, чтв, 2-5 пары.\r\nЛабораторные занятия ставить для подгруппы спаренные (две пары подряд)\r\n", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", " ", " ", "", " " },
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
