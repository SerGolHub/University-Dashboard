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
                    ($"Факультет: {info.FacultyName}",
                    new WordTextProperties { Size = "28", Bold = true, JustificationType = WordJustificationType.Center })
                },
            });


            // Заголовок
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)>
                {
                    ($"Протокол проверки учебных занятий в  семестре",
                        new WordTextProperties { Bold = true, Size = "32", JustificationType = WordJustificationType.Center })
                },
            });

            // Дата
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)>
                {
                    ($"на «{info.DateReport?.Day}»   {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(info.DateReport!.Value.Month)}   {info.DateReport?.Year} г.",
                    new WordTextProperties { Size = "28", Bold = true, JustificationType = WordJustificationType.Center })
                },
            });

            // Пропуск
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)>
                {
                    ("",
                    new WordTextProperties { Size = "28", Bold = true, JustificationType = WordJustificationType.Center })
                },
            });

            // Заголовки таблицы
            CreateTableHeader(new List<string> { "№ ауд", "Пара", "Группа", "Дисциплина", "Ф.И.О. Преподавателя", "Роспись преподавателя" });

            // Данные таблицы
            

            // Пропуск
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)>
                {
                    ("",
                    new WordTextProperties { Size = "28", Bold = true, JustificationType = WordJustificationType.Center })
                },
            });

            // Итоговые абзацы
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)>
                {
                    ("Итого проверено занятий:      _____  ; из них:", new WordTextProperties { Size = "28", JustificationType = WordJustificationType.Left })
                },
                TextStyle = "Arial"
            });


            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)>
                {
                    ("Количество присутствующих: _____", new WordTextProperties { Size = "28", JustificationType = WordJustificationType.Left })
                },
            });

            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)>
                {
                    ("Количество отсутствующих:    _____", new WordTextProperties { Size = "28", JustificationType = WordJustificationType.Left })
                },
            });

            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)>
                {
                    ("Лицо, проводящее проверку: ______________________________________",
                    new WordTextProperties { Size = "28", JustificationType = WordJustificationType.Left })
                },
            });

            // Разрыв страницы
            CreatePageBreak();

            // Добавление новой строки с "Декану"
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)>
                {
                    ("Декану________________________", new WordTextProperties { Size = "28", JustificationType = WordJustificationType.Right })
                },
            });

            // Пропуск
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)>
                {
                    ("",
                    new WordTextProperties { Size = "28", Bold = true, JustificationType = WordJustificationType.Center })
                },
            });

            // Заголовок для новой таблицы
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)>
                {
                    ($"Акт  проверки занятий в  семестре  {info.DateReport?.Year}-{info.DateReport?.Year+1} гг.", 
                    new WordTextProperties { Size = "28", JustificationType = WordJustificationType.Center, SpaceBetween = true })
                },
            });

            // Заголовки таблицы для новой таблицы
            CreateTableHeader(new List<string> { "Дата", "№ ауд.", "Время", "Группа", "Дисциплина", "Ф.И.О. преподавателя", "Примечание" });

            // Дополнительно можно заполнить таблицу с данными, если они имеются
            // Пример заполнения (данные могут быть добавлены в info)
            
                // Пропуск
                CreateParagraph(new WordParagraph
                {
                    Texts = new List<(string, WordTextProperties)>
                {
                    ("",
                    new WordTextProperties { Size = "28", Bold = true, JustificationType = WordJustificationType.Center })
                },
                });

                // Объяснительная записка преподавателей
                CreateParagraph(new WordParagraph
                {
                    Texts = new List<(string, WordTextProperties)>
                    {
                        ("Объяснительные записки преподавателей с резолюцией декана просьба предоставить в отдел ОУП до   «___» ______________  20___г.",
                        new WordTextProperties { Size = "28", JustificationType = WordJustificationType.Left, Indentation = true, SpaceBetween = true })
                    },
                    TextStyle = "Arial"
                });

                // Пропуск
                CreateParagraph(new WordParagraph
                {
                    Texts = new List<(string, WordTextProperties)>
                {
                    ("",
                    new WordTextProperties { Size = "28", Bold = true, JustificationType = WordJustificationType.Center })
                },
                });

                CreateParagraph(new WordParagraph
                {
                    Texts = new List<(string, WordTextProperties)>
                    {
                        ("Начальник отдела ОУП                         			_____________________",
                        new WordTextProperties { Size = "28", JustificationType = WordJustificationType.Right })
                    },
                    TextStyle = "Arial"
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
