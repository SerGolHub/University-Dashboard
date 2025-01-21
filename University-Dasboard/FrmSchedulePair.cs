using Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using University_Dasboard.Controllers;
using University_Dasboard.Database.Models;
using NLog;
using University_Dasboard.Reports.Models;
using University_Dasboard.Reports;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using DocumentFormat.OpenXml.Bibliography;
using OfficePackage.HelperModels;
using OfficePackage.Implements;
using University_Dasboard.Database.Enums;

namespace University_Dasboard
{
    public partial class FrmSchedulePair : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public FrmSchedulePair()
        {
            InitializeComponent();
            LoadData();
        }

        public class SchedulePairViewModel
        {
            public Guid Id { get; set; }

            public int NumberPair { get; set; }

            public DayOfWeek DayOfWeek { get; set; }

            public TimeSpan StartTime { get; set; } // Время начала пары
            public TimeSpan EndTime { get; set; } // Время окончания пары

            public string SubjectName { get; set; } = null!; // Предмет
            public string GroupName { get; set; } = null!; 
            public string ClassroomName { get; set; } = null!; // Аудитория
            public string TeacherName { get; set; } = null!; // Преподаватель

            public Guid TeacherId { get; set; }
            public Teacher? Teacher { get; set; }

            public Guid ScheduleDisciplineId { get; set; }
            public ScheduleDiscipline? ScheduleDiscipline { get; set; }
        }

        private BindingList<SchedulePairViewModel> schedules = new();
        private List<SchedulePairViewModel> newScheduleList = [];
        private List<SchedulePairViewModel> updatedScheduleList = [];
        private List<SchedulePairViewModel> removedScheduleList = [];

        private Teacher? selectedTeacher;
        private ScheduleDiscipline? selectedScheduleDiscipline;


        private void LoadData()
        {
            using var ctx = new DatabaseContext();

            SchedulePairController.LoadSchedulePairs(dgvSchedules, ref schedules);
            DataGridViewHelper.HideColumns(dgvSchedules,
                ["Id", "FacultyId", "DirectionId", "SubjectId", "GroupId", "ScheduleWeekId"]);
            LoadComboboxData(ctx);

            logger.Info("Данные расписания успешно загружены");
        }

        private void LoadComboboxData(DatabaseContext ctx)
        {
            // Загрузка факультетов
            var teachers = ctx.Teacher.ToList();
            ComboboxHelper.LoadCombobox(
                teachers,
                comboBox: comboBoxTeacher);

            // Загрузка недель расписания
            var schedule = ctx.ScheduleDisciplines.ToList();
            ComboboxHelper.LoadCombobox(
                schedule,
                comboBox: comboBoxSchedule);

            // Загружаем список дней недели в ComboBox
            comboBoxDayOfWeek.DataSource = Enum.GetValues(typeof(DayOfWeekEnum));
        }

        private void ClearTempLists()
        {
            newScheduleList.Clear();
            updatedScheduleList.Clear();
            removedScheduleList.Clear();

            logger.Info("Очистка списка расписаний");
        }

        private void tbHours_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (selectedTeacher == null)
            {
                MessageBox.Show("Выберите преподавателя для добавления ограничения.");
                logger.Warn("Попытка добавить преподавателя.");
                return;
            }

            if (selectedScheduleDiscipline == null)
            {
                MessageBox.Show("Выберите расчасовку на неделю.");
                logger.Warn("Попытка добавить расчасовку.");
                return;
            }

            if (string.IsNullOrEmpty(tbClassroomNumber.Text))
            {
                MessageBox.Show("Введите номер аудитории");
                return;
            }

            var startTime = dateTimePickerStartTime.Value.TimeOfDay;
            var endTime = dateTimePickerEndTime.Value.TimeOfDay;

            if (startTime >= endTime)
            {
                MessageBox.Show("Время начала должно быть раньше времени окончания.");
                return;
            }

            var selectedDay = comboBoxDayOfWeek.SelectedItem as DayOfWeekEnum?;

            if (selectedDay == null)
            {
                MessageBox.Show("Выберите день недели.");
                return;
            }

            // Преобразуем DayOfWeekEnum в System.DayOfWeek
            System.DayOfWeek systemDay = (System.DayOfWeek)(selectedDay.Value);

            // Проверяем временные ограничения учителя
            var constraints = TeacherConstraintController.GetTeacherConstraints(selectedTeacher.Id);

            bool isConflict = constraints.Any(tc =>
                startTime < tc.EndTime && endTime > tc.StartTime);

            bool isConflictDay = constraints.Any(tc =>
                systemDay == tc.DayOfWeek);

            if (isConflict)
            {
                MessageBox.Show($"Время {startTime} - {endTime} пересекается с ограничением учителя {selectedTeacher.Name}.");
                return;
            }

            if (isConflictDay)
            {
                MessageBox.Show($"Выбранный день недели {systemDay} уже занят в расписании учителя {selectedTeacher.Name}.");
                return;
            }

            var schedule = new SchedulePairViewModel()
            {
                Id = Guid.NewGuid(),
                NumberPair = Convert.ToInt32(tbNumberPair.Text),
                ClassroomName = tbClassroomNumber.Text,
                TeacherId = selectedTeacher.Id,
                DayOfWeek = systemDay,
                StartTime = startTime,
                EndTime = endTime,
                ScheduleDisciplineId = selectedScheduleDiscipline!.Id,
            };

            schedules.Add(schedule);
            newScheduleList.Add(schedule);
            dgvSchedules.Refresh(); // Принудительное обновление DataGridView
        }


        async private void btnSave_Click(object sender, EventArgs e)
        {
            lbDbSaveResult.ForeColor = Color.FromArgb(218, 141, 178);
            lbDbSaveResult.Text = "Подождите. Данные сохраняются.";
            logger.Info("Данные сохраняются");
            lbDbSaveResult.Visible = true;

            await SchedulePairController.SaveSchedulePairsAsync(
              newScheduleList,
              updatedScheduleList,
              removedScheduleList);

            ClearTempLists();

            // Перезагрузка данных после сохранения
            LoadData();

            lbDbSaveResult.ForeColor = Color.FromArgb(118, 241, 178);
            lbDbSaveResult.Text = "Данные успешно сохранены.";
            await Task.Delay(2000);

            lbDbSaveResult.Visible = false;
            logger.Info("Данные добавлены. Сохранение прошло успешно");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearTempLists();
            LoadData();
        }

        private SchedulePairViewModel GetSchedule(Guid id)
        {
            return schedules.First(d => d.Id == id);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSchedules.CurrentRow == null)
            {
                MessageBox.Show("Выделите строку для удаления");
                logger.Info("Пользователь не выделил строку для удаления");
                return;
            }

            var id = (Guid)dgvSchedules.CurrentRow.Cells["Id"].Value;
            SchedulePairViewModel deletedSchedule = GetSchedule(id);
            schedules.Remove(deletedSchedule);

            if (newScheduleList.Contains(deletedSchedule))
            {
                newScheduleList.Remove(deletedSchedule);
                logger.Info("Удаление прошло успешно");
            }
            else
            {
                updatedScheduleList.Remove(deletedSchedule);
                removedScheduleList.Add(deletedSchedule);
            }
        }

        private void cbTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTeacher = (Teacher?)comboBoxTeacher.SelectedItem;
        }

        private void cbScheduleDiscipline_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedScheduleDiscipline = (ScheduleDiscipline?)comboBoxSchedule.SelectedItem;
        }

        private void cbDayOfWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Получаем выбранное значение DayOfWeekEnum из ComboBox
            DayOfWeekEnum selectedDay = (DayOfWeekEnum)comboBoxDayOfWeek.SelectedItem!;
        }

        // Для DataGridView, настройте обработчик события CellFormatting
        private void dgvTeacherConstraintList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Проверяем, если это столбцы с временем
            if (e.ColumnIndex == dgvSchedules.Columns["StartTime"].Index && e.Value != null)
            {
                e.Value = ((TimeSpan)e.Value).ToString(@"hh\:mm");  // Форматируем в часы:минуты
            }
            else if (e.ColumnIndex == dgvSchedules.Columns["EndTime"].Index && e.Value != null)
            {
                e.Value = ((TimeSpan)e.Value).ToString(@"hh\:mm");  // Форматируем в часы:минуты
            }
        }
    }
}
