using Database;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.ChartDrawing;
using Microsoft.EntityFrameworkCore;
using OfficePackage.HelperEnums;
using OfficePackage.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_Dasboard.Reports.Models;

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
            int lectureHours = info.LectureHours; // Общее количество часов
            int hoursPerCell = 2; // Часы на каждую ячейку
            int totalCells = lectureHours / hoursPerCell; // Количество ячеек

            // Формируем список строк
            var hoursList = new List<string> { "1. Лекции занятий", "аудит." }; // Первые фиксированные элементы

            if (lectureHours < 19)
            {
                // Добавляем часы в ячейки с пропусками
                for (int i = 0; i < totalCells; i++)
                {
                    hoursList.Add(hoursPerCell.ToString()); // Заполняем ячейку
                    hoursList.Add(""); // Добавляем пропуск
                }

                // Убираем лишний пропуск, если общее количество добавленных элементов превышает общее число ячеек
                if (hoursList.Count > 21)
                {
                    hoursList = hoursList.Take(22).ToList(); // Обрезаем список до нужного размера
                }
                else
                {
                    // Добавляем пустые строки для оставшихся ячеек
                    for (int i = hoursList.Count; i < 21; i++)
                    {
                        hoursList.Add("");
                    }
                }
            }
            else
            {
                for (int i = 0; i < totalCells; i++)
                {
                    hoursList.Add(hoursPerCell.ToString());
                }
                // Добавляем пустые строки для оставшихся ячеек (если их нужно выравнивать)
                for (int i = hoursList.Count; i < 21; i++) // Предполагаем, что всего в строке должно быть 22 элемента
                {
                    hoursList.Add("");
                }
            }

            // Добавляем общее количество часов в 21-ю ячейку
            if (hoursList.Count >= 20)
            {
                hoursList.Insert(20, lectureHours.ToString());
            }

            // Убедимся, что список состоит ровно из 22 элементов
            for (int i = hoursList.Count; i < 22; i++)
            {
                hoursList.Add("");
            }

            // Создаем строку таблицы
            CreateRow(new PdfRowParameters
            {
                Texts = hoursList,
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

            int practicalHours = info.PracticalHours; // Общее количество часов
            int hoursPerCell2 = 2; // Часы на каждую ячейку
            int totalCells2 = practicalHours / hoursPerCell2; // Количество ячеек

            // Формируем список строк
            var hoursList2 = new List<string> { "2. Практические занятия", "аудит." }; // Первые фиксированные элементы
            if (practicalHours < 19)
            {
                // Добавляем часы в ячейки с пропусками
                for (int i = 0; i < totalCells2; i++)
                {
                    hoursList2.Add(hoursPerCell2.ToString()); // Заполняем ячейку
                    hoursList2.Add(""); // Добавляем пропуск
                }

                // Убираем лишний пропуск, если общее количество добавленных элементов превышает общее число ячеек
                if (hoursList2.Count > 21)
                {
                    hoursList2 = hoursList2.Take(22).ToList(); // Обрезаем список до нужного размера
                }
                else
                {
                    // Добавляем пустые строки для оставшихся ячеек
                    for (int i = hoursList2.Count; i < 21; i++)
                    {
                        hoursList2.Add("");
                    }
                }
            }
            else
            {
                for (int i = 0; i < totalCells2; i++)
                {
                    hoursList2.Add(hoursPerCell2.ToString());
                }
                // Добавляем пустые строки для оставшихся ячеек (если их нужно выравнивать)
                for (int i = hoursList2.Count; i < 21; i++) // Предполагаем, что всего в строке должно быть 22 элемента
                {
                    hoursList2.Add("");
                }
            }

            // Добавляем общее количество часов в 21-ю ячейку
            if (hoursList2.Count >= 20)
            {
                hoursList2.Insert(20, practicalHours.ToString());
            }

            // Убедимся, что список состоит ровно из 22 элементов
            for (int i = hoursList2.Count; i < 22; i++)
            {
                hoursList2.Add("");
            }

            // Создаем строку таблицы
            CreateRow(new PdfRowParameters
            {
                Texts = hoursList2,
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
            int laboratoryHours = info.LaboratoryHours; // Общее количество часов
            int hoursPerCell3 = 2; // Часы на каждую ячейку
            int totalCells3 = laboratoryHours / hoursPerCell3; // Количество ячеек

            // Формируем список строк
            var hoursList3 = new List<string> { "3. Лабораторные занятия", "аудит." }; // Первые фиксированные элементы
            if (laboratoryHours < 19)
            {
                // Добавляем часы в ячейки с пропусками
                for (int i = 0; i < totalCells3; i++)
                {
                    hoursList3.Add(hoursPerCell3.ToString()); // Заполняем ячейку
                    hoursList3.Add(""); // Добавляем пропуск
                }

                // Убираем лишний пропуск, если общее количество добавленных элементов превышает общее число ячеек
                if (hoursList3.Count > 21)
                {
                    hoursList3 = hoursList3.Take(22).ToList(); // Обрезаем список до нужного размера
                }
                else
                {
                    // Добавляем пустые строки для оставшихся ячеек
                    for (int i = hoursList3.Count; i < 21; i++)
                    {
                        hoursList3.Add("");
                    }
                }
            }
            else
            {
                for (int i = 0; i < totalCells3; i++)
                {
                    hoursList3.Add(hoursPerCell3.ToString());
                }
                // Добавляем пустые строки для оставшихся ячеек (если их нужно выравнивать)
                for (int i = hoursList3.Count; i < 21; i++) // Предполагаем, что всего в строке должно быть 22 элемента
                {
                    hoursList3.Add("");
                }
            }

            // Добавляем общее количество часов в 21-ю ячейку
            if (hoursList3.Count >= 20)
            {
                hoursList3.Insert(20, laboratoryHours.ToString());
            }

            // Убедимся, что список состоит ровно из 22 элементов
            for (int i = hoursList3.Count; i < 22; i++)
            {
                hoursList3.Add("");
            }


            // Создаем строку таблицы
            CreateRow(new PdfRowParameters
            {
                Texts = hoursList3,
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

            // Создаем строку для подвала таблицы
            CreateRow(new PdfRowParameters
            {
                Texts = totalRow,
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
            CreateTable(new List<string> { "3cm", "3cm", "3cm", "4cm", "3.5cm" });
            CreateRow(new PdfRowParameters
            {
                Texts = new List<string> { "Направление", "Группа", "Дисциплина", "Ф.И.О. Преподавателя", "Роспись преподавателя" },
                Style = "TableHeader",
                Font = "Times New Roman",
                FontWeight = "Bold",
                ParagraphAlignment = PdfParagraphAlignmentType.Center
            });

            // Загружаем все расписания
            using var ctx = new DatabaseContext();
            var schedules = ctx.ScheduleDisciplines.Include(s => s.Subject)
                .Include(s => s.Group).ThenInclude(g => g!.Direction).ThenInclude(d => d!.Faculty)
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
            foreach (var schedule in schedules)
            {
                CreateRow(new PdfRowParameters
                {
                    Texts = new List<string>
                {
                    schedule.DirectionName.ToString(),
                    schedule.GroupName.ToString(),
                    schedule.SubjectName.ToString(),
                    info.TeacherName.ToString(),
                    schedule.EmptyColumn.ToString()
                },
                    Style = "Normal",
                    Font = "Times New Roman",
                    ParagraphAlignment = PdfParagraphAlignmentType.Left
                });
            }

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
            foreach (var schedule in schedules)
            {
                CreateRow(new PdfRowParameters
                {
                    Texts = new List<string>
                    {
                        {schedule.DateReport.ToShortDateString()},
                        schedule.DateReport.ToShortTimeString(),
                        schedule.GroupName.ToString(),
                        schedule.SubjectName.ToString(),
                        schedule.TeacherName.ToString(),
                        schedule.EmptyColumn.ToString()
                    },
                    Font = "Times New Roman",
                    Style = "TableText",
                    ParagraphAlignment = PdfParagraphAlignmentType.Center
                });
            }

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
