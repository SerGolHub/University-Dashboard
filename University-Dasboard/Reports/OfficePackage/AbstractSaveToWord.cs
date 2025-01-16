using Database;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.EntityFrameworkCore;
using OfficePackage.HelperEnums;
using OfficePackage.HelperModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_Dasboard.Reports.Models;

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

        public void CreateCheckLesson(WordInfo info)
        {
            CreateWord(info);

            // Заголовок
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)>
                {
                    ($"Протокол проверки учебных занятий в {info.SemesterNumber} семестре",
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
            CreateTableHeader(new List<string> { "Направление", "Группа", "Дисциплина", "Ф.И.О. Преподавателя", "Роспись преподавателя" });

            // Загружаем все расписания
            using var ctx = new DatabaseContext();
            var schedules = ctx.ScheduleDisciplines.Include(s => s.Subject)
                .Include(s => s.Group).ThenInclude(g => g.Direction).ThenInclude(d => d.Faculty)
                .Include(s => s.ScheduleWeek)
                .Select(s => new ReportShufflingViewModel
                {
                    Id = s.Id,
                    DirectionName = s.Direction!.Name,
                    SubjectName = s.Subject!.Name,
                    GroupName = s.Group!.Name,
                    FacultyName = s.Faculty!.Name,
                    ScheduleWeek = s.ScheduleWeek!.Name,
                    LectureHours = s.ScheduleWeek.LectureHours,
                    PracticalHours = s.ScheduleWeek.PracticalHours,
                    LaboratoryHours = s.ScheduleWeek.LaboratoryHours
                }).ToList();

            // Данные таблицы
            foreach (var report in schedules)
            {
                CreateRow(new WordRowParameters
                {
                    Texts = new List<string>
                    {
                        report.DirectionName.ToString(),
                        report.GroupName.ToString(),
                        report.SubjectName.ToString(),
                        report.TeacherName.ToString(),
                        report.EmptyColumn.ToString()
                    },

                    TextProperties = new WordTextProperties
                    {
                        JustificationType = WordJustificationType.Left
                    }
                });
            }

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
                    ($"Акт  проверки занятий в {info.SemesterNumber} семестре  {info.DateReport?.Year}-{info.DateReport?.Year+1} гг.",
                    new WordTextProperties { Size = "28", JustificationType = WordJustificationType.Center, SpaceBetween = true })
                },
            });

            // Заголовки таблицы для новой таблицы
            CreateTableHeader(new List<string> { "Дата", "Время", "Группа", "Дисциплина", "Ф.И.О. преподавателя", "Примечание" });

            // Дополнительно можно заполнить таблицу с данными, если они имеются
            // Пример заполнения (данные могут быть добавлены в info)
            foreach (var item in schedules)
            {
                CreateRow(new WordRowParameters
                {
                    Texts = new List<string>
                    {
                        item.DateReport.ToShortDateString(),
                        item.DateReport.ToShortTimeString(),
                        item.GroupName.ToString(),
                        item.SubjectName.ToString(),
                        item.TeacherName.ToString(),
                        item.EmptyColumn.ToString()
                    },
                    TextProperties = new WordTextProperties
                    {
                        JustificationType = WordJustificationType.Left
                    }
                });
            }


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
