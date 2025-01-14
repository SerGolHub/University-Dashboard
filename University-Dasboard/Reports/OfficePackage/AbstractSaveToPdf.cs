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
                FontWeight="Bold",
                ParagraphAlignment = PdfParagraphAlignmentType.Center
            });

            // Предтабличная информация о группе, преподавателе и тд.
            CreateParagraph(new PdfParagraph
            {
                Text = $"Факультет: {info.FacultyName}                                      Направление {info.DirectionName},                                     Группа: {info.GroupName}\n\n\n",
                Style = "Normal",
                Font = "Times New Roman",
                ParagraphAlignment = PdfParagraphAlignmentType.Justify
            });

            CreateParagraph(new PdfParagraph
            {
                Text = $"Дисциплина: {info.SubjectName}                                   {info.SemesterName}                                                     {info.TeacherName}\n\n",
                Style = "Normal",
                Font = "Times New Roman",
                ParagraphAlignment = PdfParagraphAlignmentType.Justify
            });

            // Заголовки таблицы
            CreateTable(new List<string> { "2cm", "2cm", "1cm", "1cm", "1cm", "1cm", "1cm", "1cm", "1cm", "1cm", "1cm", "1cm", "1cm", "1cm", "1cm", "1cm", "1cm", "2cm" });
            CreateRow(new PdfRowParameters
            {
                Texts = new List<string> { "Форма занятий", "Недели", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "", "Отчётность" },
                Style = "TableHeader",
                Font = "Times New Roman",
                FontWeight = "Bold",
                ParagraphAlignment = PdfParagraphAlignmentType.Center
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
