using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using OfficePackage.HelperEnums;
using OfficePackage.HelperModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficePackage
{
    public abstract class AbstractSaveToWord
    {
        public void CreateDoc(WordInfo info)
        {
            CreateWord(info);

            // Заголовок
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)>
                {
                    ("РАСЧАСОВКА НА КАЖДУЮ ГРУППУ",
                    new WordTextProperties { Size = "32", Bold = true, JustificationType = WordJustificationType.Center })
                },
            });

            // Заголовок
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)>
                {
                    ("ГРАФИК УЧЕБНОГО ПРОЦЕССА",
                    new WordTextProperties { Size = "28", Bold = true, JustificationType = WordJustificationType.Center })
                },
            });

            // Заголовок
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)>
                {
                    ($"Факультет: {info.FacultyName}             Направление {info.DirectionName},                Группа: {info.GroupName}",
                    new WordTextProperties { Size = "28", Bold = true, JustificationType = WordJustificationType.Center })
                },
            });


            // Заголовок
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)>
                {
                    ($"Дисциплина: {info.SubjectName}             {info.SemesterName}                            {info.TeacherName} ",
                        new WordTextProperties { Bold = true, Size = "32", JustificationType = WordJustificationType.Center })
                },
            });

            // Заголовки таблицы
            CreateTableHeader(new List<string> { "Форма занятий", "Недели", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "∑", "Отчётность" });

            // Заполнение таблицы
            CreateRow(new WordRowParameters
            {
                Texts = new List<string> { "1. Лекция", "аудит.", "2", "", "2", "", "2", "", "2", "", "2", "", "2", "", "2", "", "2", "", "2", "", "2", "", "2", "", "2", "" },
                TextProperties = new WordTextProperties { JustificationType = WordJustificationType.Center }
            });
            // Данные таблицы




            SaveWord(info);
        }


        /// Создание doc-файла
        protected abstract void CreateWord(WordInfo info);

        /// Создание абзаца с текстом
        protected abstract void CreateParagraph(WordParagraph paragraph);

        /// Создание таблицы
        protected abstract void CreateTableHeader(List<string> columnNames);

        /// Создание заголовков таблицы
        protected abstract void CreateRow(WordRowParameters parameters);

        /// Разрыв страницы
        protected abstract void CreatePageBreak();

        /// Создание списка
        protected abstract void CreateBulletList(List<string> items);

        /// Заголовки вертикальные
        protected abstract void CreateTableHeaderRotation(List<string> columnNames);

        /// Сохранение файла
        protected abstract void SaveWord(WordInfo info);
    }
}
