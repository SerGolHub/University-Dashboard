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

            // Данные таблицы
            int lectureHours = info.LectureHours; // Общее количество часов
            int hoursPerCell = 2; // Часы на каждую ячейку
            int totalCells = lectureHours / hoursPerCell; // Количество ячеек

            // Формируем список строк для лекций
            var hoursList = new List<string> { "1. Лекции занятий", "аудит." }; // Первые фиксированные элементы

            if (lectureHours < 19)
            {
                for (int i = 0; i < totalCells; i++)
                {
                    hoursList.Add(hoursPerCell.ToString()); // Часы в ячейке
                    hoursList.Add(""); // Пропуск
                }

                if (hoursList.Count > 21)
                {
                    hoursList = hoursList.Take(22).ToList(); // Ограничиваем до 22 элементов
                }
                else
                {
                    for (int i = hoursList.Count; i < 21; i++)
                    {
                        hoursList.Add(""); // Дополняем до нужного размера
                    }
                }
            }
            else
            {
                for (int i = 0; i < totalCells; i++)
                {
                    hoursList.Add(hoursPerCell.ToString());
                }
                for (int i = hoursList.Count; i < 21; i++)
                {
                    hoursList.Add(""); // Дополняем пустыми ячейками
                }
            }

            // Вставляем общее количество часов в 21-ю ячейку
            if (hoursList.Count >= 20)
            {
                hoursList.Insert(20, lectureHours.ToString());
            }

            // Убедимся, что список состоит ровно из 22 элементов
            for (int i = hoursList.Count; i < 22; i++)
            {
                hoursList.Add("");
            }

            // Заполнение таблицы
            CreateRow(new WordRowParameters
            {
                Texts = hoursList,
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

            // Данные таблицы для практических занятий
            int practicalHours = info.PracticalHours; // Общее количество часов
            var hoursList2 = new List<string> { "2. Практические занятия", "аудит." };

            if (practicalHours < 19)
            {
                for (int i = 0; i < practicalHours / hoursPerCell; i++)
                {
                    hoursList2.Add(hoursPerCell.ToString());
                    hoursList2.Add(""); // Пропуск
                }

                if (hoursList2.Count > 21)
                {
                    hoursList2 = hoursList2.Take(22).ToList();
                }
                else
                {
                    for (int i = hoursList2.Count; i < 21; i++)
                    {
                        hoursList2.Add(""); // Дополняем
                    }
                }
            }
            else
            {
                for (int i = 0; i < practicalHours / hoursPerCell; i++)
                {
                    hoursList2.Add(hoursPerCell.ToString());
                }
                for (int i = hoursList2.Count; i < 21; i++)
                {
                    hoursList2.Add("");
                }
            }

            if (hoursList2.Count >= 20)
            {
                hoursList2.Insert(20, practicalHours.ToString());
            }

            for (int i = hoursList2.Count; i < 22; i++)
            {
                hoursList2.Add("");
            }

            // Данные таблицы
            CreateRow(new WordRowParameters
            {
                Texts = hoursList2,
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

            // Аналогично формируем данные для лабораторных занятий
            int laboratoryHours = info.LaboratoryHours;
            var hoursList3 = new List<string> { "3. Лабораторные занятия", "аудит." };

            if (laboratoryHours < 19)
            {
                for (int i = 0; i < laboratoryHours / hoursPerCell; i++)
                {
                    hoursList3.Add(hoursPerCell.ToString());
                    hoursList3.Add(""); // Пропуск
                }

                if (hoursList3.Count > 21)
                {
                    hoursList3 = hoursList3.Take(22).ToList();
                }
                else
                {
                    for (int i = hoursList3.Count; i < 21; i++)
                    {
                        hoursList3.Add("");
                    }
                }
            }
            else
            {
                for (int i = 0; i < laboratoryHours / hoursPerCell; i++)
                {
                    hoursList3.Add(hoursPerCell.ToString());
                }
                for (int i = hoursList3.Count; i < 21; i++)
                {
                    hoursList3.Add("");
                }
            }

            if (hoursList3.Count >= 20)
            {
                hoursList3.Insert(20, laboratoryHours.ToString());
            }

            for (int i = hoursList3.Count; i < 22; i++)
            {
                hoursList3.Add("");
            }

            // Данные таблицы
            CreateRow(new WordRowParameters
            {
                Texts = hoursList3,
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

            // Подвал таблицы
            // Общее количество ячеек для всех типов (зависит от типа занятия)
            int hoursPerCell4 = 2; // Часы на ячейку

            // Формируем метод для добавления ячеек с учетом пропусков
            List<string> GenerateSchedule(int hours, string type)
            {
                var list = new List<string> { type, "аудит." }; // Первые фиксированные элементы

                // Рассчитываем количество ячеек
                int totalCells = hours / hoursPerCell4;

                if (hours < 19)
                {
                    // Добавляем часы в ячейки с пропусками (через одну ячейку)
                    for (int i = 0; i < totalCells; i++)
                    {
                        list.Add(hoursPerCell4.ToString()); // Заполняем ячейку
                        list.Add(""); // Добавляем пропуск
                    }

                    // Убираем лишний пропуск, если общее количество добавленных элементов превышает 21
                    if (list.Count > 21)
                    {
                        list = list.Take(22).ToList(); // Обрезаем список до нужного размера
                    }
                    else
                    {
                        // Добавляем пустые строки для оставшихся ячеек
                        for (int i = list.Count; i < 21; i++)
                        {
                            list.Add("");
                        }
                    }
                }
                else
                {
                    // Если количество часов больше 19, заполняем ячейки без пропусков
                    for (int i = 0; i < totalCells; i++)
                    {
                        list.Add(hoursPerCell4.ToString());
                    }

                    // Добавляем пустые строки до 21 для выравнивания
                    for (int i = list.Count; i < 21; i++)
                    {
                        list.Add("");
                    }
                }

                // Добавляем общее количество часов в 21-ю ячейку
                if (list.Count >= 20)
                {
                    list.Insert(20, hours.ToString());
                }

                // Убедимся, что список состоит ровно из 22 элементов
                for (int i = list.Count; i < 22; i++)
                {
                    list.Add("");
                }

                return list;
            }

            // Создаем списки для каждого типа занятия
            var lectureList = GenerateSchedule(lectureHours, "1. Лекции");
            var practicalList = GenerateSchedule(practicalHours, "2. Практические занятия");
            var laboratoryList = GenerateSchedule(laboratoryHours, "3. Лабораторные занятия");

            // Создаем итоговую строку для суммирования значений по ячейкам
            var totalRow = new List<string> { "Всего", "аудит." };

            // Сложение по столбцам для каждого типа занятий
            for (int i = 2; i < 20; i++) // Пропускаем первые 2 ячейки (тема и аудитория)
            {
                int lectureValue = string.IsNullOrEmpty(lectureList[i]) ? 0 : int.Parse(lectureList[i]);
                int practicalValue = string.IsNullOrEmpty(practicalList[i]) ? 0 : int.Parse(practicalList[i]);
                int laboratoryValue = string.IsNullOrEmpty(laboratoryList[i]) ? 0 : int.Parse(laboratoryList[i]);

                // Суммируем значения
                int totalValue = lectureValue + practicalValue + laboratoryValue;
                totalRow.Add(totalValue.ToString());
            }

            // Добавляем итоговое количество часов в 21 ячейку
            totalRow.Add((lectureHours + practicalHours + laboratoryHours).ToString());

            // Добавляем пустую строку в последнюю ячейку (22-я ячейка)
            totalRow.Add("");

            // Убедимся, что список состоит ровно из 22 элементов (проверим на всякий случай)
            while (totalRow.Count < 22) totalRow.Add("");

            // Данные таблицы
            CreateRow(new WordRowParameters
            {
                Texts = totalRow,
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
