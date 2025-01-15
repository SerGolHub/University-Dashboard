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
            info.IsLandscape = true;

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
                    ($"Факультет: {info.FacultyName}       Направление {info.DirectionName},        Группа: {info.GroupName}",
                    new WordTextProperties { Size = "24", JustificationType = WordJustificationType.Center })
                },
            });


            // Заголовок
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)>
                {
                    ($"Дисциплина: {info.SubjectName}    {info.SemesterName} {info.DateCreate.Year}-{info.DateCreate.Year+1}гг.,      {info.TeacherName} ",
                        new WordTextProperties { Size = "24", JustificationType = WordJustificationType.Center })
                },
            });

            // Заголовки таблицы
            CreateTableHeader(new List<string> { "Форма занятий", "Недели", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "∑", "Отчётность" });

            // Заполнение таблицы
            CreateRow(new WordRowParameters
            {
                Texts = new List<string> { "1. Лекции", "аудит.", "2", "", "2", "", "2", "", "2", "", "2", "", "2", "", "2", "", "2", "", "", "", "", ""  },
                TextProperties = new WordTextProperties { JustificationType = WordJustificationType.Center }
            });

            // Данные таблицы
            CreateRow(new WordRowParameters
            {
                Texts = new List<string> { "", $"{info.ClassroomNumber}", $"{info.TeacherName}", "", "", "", "", "", "", "", $"{info.TeacherName}", "", "", "", "", "", "", "", "", "", "", "" },
                TextProperties = new WordTextProperties { JustificationType = WordJustificationType.Center },
                MergedCells = new List<Tuple<int, int>> // Указываем диапазоны для объединения
                {
                    new Tuple<int, int>(2, 9), // Объединение ячеек со второй по 8
                    new Tuple<int, int>(10, 20),
                }
            });

            // Данные таблицы
            CreateRow(new WordRowParameters
            {
                Texts = new List<string> { "2. Практические занятий", "аудит.", "", "2", "", "2", "", "2", "", "2", "", "2", "", "2", "", "2", "", "2", "", "", "", "" },
                TextProperties = new WordTextProperties { JustificationType = WordJustificationType.Center }
            });


            // Данные таблицы
            CreateRow(new WordRowParameters
            {
                Texts = new List<string> { "", $"{info.ClassroomNumber}", $"{info.TeacherName}", "", "", "", "", "", "", "", $"{info.TeacherName}", "", "", "", "", "", "", "", "", "", "", "" },
                TextProperties = new WordTextProperties { JustificationType = WordJustificationType.Center },
                MergedCells = new List<Tuple<int, int>> // Указываем диапазоны для объединения
                {
                    new Tuple<int, int>(2, 9), // Объединение ячеек со второй по 8
                    new Tuple<int, int>(10, 20),
                }
            });

            // Данные таблицы
            CreateRow(new WordRowParameters
            {
                Texts = new List<string> { "3. Лабораторные занятия", "аудит.", "2", "", "2", "", "2", "", "2", "", "2", "", "2", "", "2", "", "2", "", "", "", "", "" },
                TextProperties = new WordTextProperties { JustificationType = WordJustificationType.Center }
            });


            // Данные таблицы
            CreateRow(new WordRowParameters
            {
                Texts = new List<string> { "", $"{info.ClassroomNumber}", $"1-я подгруппа {info.TeacherName}, 2-ая подгруппа {info.TeacherName}", "", "", "", "", "", "", "", $"1-я подгруппа {info.TeacherName}, 2-ая подгруппа {info.TeacherName}", "", "", "", "", "", "", "", "", "", "", "" },
                TextProperties = new WordTextProperties { JustificationType = WordJustificationType.Center },
                MergedCells = new List<Tuple<int, int>> // Указываем диапазоны для объединения
                {
                    new Tuple<int, int>(2, 9), // Объединение ячеек со второй по 8
                    new Tuple<int, int>(10, 20),
                }
            });

            // Данные таблицы
            CreateRow(new WordRowParameters
            {
                Texts = new List<string> { "Всего", "аудит.", "4", "4", "4", "4", "4", "4", "4", "4", "4", "4", "4", "4", "4", "4", "4", "4", " ", " ", "64", " " },
                TextProperties = new WordTextProperties { JustificationType = WordJustificationType.Center },
            });

            // Данные таблицы
            CreateRow(new WordRowParameters
            {
                Texts = new List<string> { "Объединить с потоком", $"Лекции объединить с {info.GroupNameMerge}", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", " ", " ", "", "Зав. кафедрой" },
                TextProperties = new WordTextProperties { JustificationType = WordJustificationType.Center },
                MergedCells = new List<Tuple<int, int>> // Указываем диапазоны для объединения
                {
                    new Tuple<int, int>(1, 20), // Объединение ячеек со второй по 19
                }
            });

            // Данные таблицы
            CreateRow(new WordRowParameters
            {
                Texts = new List<string> { "Пожелания с потоком", $"{info.Note}.\r\nЛабораторные занятия ставить для подгруппы спаренные (две пары подряд)\r\n", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", " ", " ", "", " " },
                TextProperties = new WordTextProperties { JustificationType = WordJustificationType.Center },
                MergedCells = new List<Tuple<int, int>> // Указываем диапазоны для объединения
                {
                    new Tuple<int, int>(1, 20), // Объединение ячеек со второй по 19
                }
            });



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
