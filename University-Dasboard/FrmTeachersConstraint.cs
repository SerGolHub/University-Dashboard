using Database;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Math;
using Microsoft.EntityFrameworkCore;
using NLog;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.RegularExpressions;
using University_Dasboard.Controllers;
using University_Dasboard.Database.Enums;
using University_Dasboard.Database.Models;
using static University_Dasboard.FrmGroups;

namespace University_Dasboard
{
	public partial class FrmTeachersConstraint : Form
	{
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();

		// Вспомогательные ViewModel для отображения данных
		public class TeacherConstraintViewModel
		{
			public Guid Id { get; set; }

			public Guid TeacherId { get; set; }
            public string TeacherName { get; set; } = string.Empty;

			public DayOfWeek DayOfWeek { get; set; }

			public TimeSpan StartTime { get; set; }
			public TimeSpan EndTime { get; set; }

			public string Note { get; set; } = string.Empty;
        }

		public FrmTeachersConstraint()
		{
			InitializeComponent();
			LoadData();
		}

		private BindingList<TeacherConstraintViewModel> teacherConstraints = [];
		private List<TeacherConstraintViewModel> newTeacherConstraintList = [];
		private List<TeacherConstraintViewModel> updatedTeacherConstraintList = [];
		private List<TeacherConstraintViewModel> removedTeacherConstraintList = [];
		private Teacher? selectedTeacher;


        private void LoadData()
        {
            try
            {
                using var ctx = new DatabaseContext();

                // Загрузка данных преподавателей
                TeacherConstraintController.LoadTeacherConstraints(dgvTeacherConstraintList, ref teacherConstraints);
                DataGridViewHelper.HideColumns(dgvTeacherConstraintList, [ "Id", "TeacherId" ]);

                // Загрузка данных для ComboBox
                LoadComboboxData(ctx);

                logger.Info("Данные преподавателей успешно загружены.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
                logger.Error(ex, "Ошибка при загрузке данных преподавателей.");
            }
        }

        private void LoadComboboxData(DatabaseContext ctx)
        {
            var teachers = ctx.Teacher.ToList();
            ComboboxHelper.LoadCombobox(teachers, comboBoxTeachers);

            // Загружаем список дней недели в ComboBox
            cbDayOfWeek.DataSource = Enum.GetValues(typeof(DayOfWeekEnum));
        }

        private void ClearTempLists()
        {
            newTeacherConstraintList.Clear();
            updatedTeacherConstraintList.Clear();
            removedTeacherConstraintList.Clear();
            logger.Info("Временные списки очищены.");
        }

        private void btnAddConstraint_Click(object sender, EventArgs e)
        {
            if (selectedTeacher == null)
            {
                MessageBox.Show("Выберите преподавателя для добавления ограничения.");
                logger.Warn("Попытка добавить ограничение без выбранного преподавателя.");
                return;
            }

            var startTime = dateTimePickerStartTime.Value.TimeOfDay;
            var endTime = dateTimePickerEndTime.Value.TimeOfDay;

            if (startTime >= endTime)
            {
                MessageBox.Show("Время начала должно быть раньше времени окончания.");
                return;
            }

            var selectedDay = cbDayOfWeek.SelectedItem as DayOfWeekEnum?;

            if (selectedDay == null)
            {
                MessageBox.Show("Выберите день недели.");
                return;
            }

            // Преобразуем DayOfWeekEnum в System.DayOfWeek
            System.DayOfWeek systemDay = (System.DayOfWeek)(selectedDay.Value);

            var constraint = new TeacherConstraintViewModel
            {
                Id = Guid.NewGuid(),
                TeacherId = selectedTeacher.Id,

                DayOfWeek = systemDay,
                StartTime = startTime,
                EndTime = endTime,
                Note = tbNote.Text.Trim()
            };

            teacherConstraints.Add(constraint);
            newTeacherConstraintList.Add(constraint);
            logger.Info($"Добавлено новое ограничение для преподавателя {selectedTeacher.Name}.");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lbDbSaveResult.ForeColor = System.Drawing.Color.Blue;
            lbDbSaveResult.Text = "Сохранение данных...";
            lbDbSaveResult.Visible = true;

            try
            {
                TeacherConstraintController.SaveTeacherConstraintsAsync(
                    newTeacherConstraintList,
                    updatedTeacherConstraintList,
                    removedTeacherConstraintList);

                ClearTempLists();
                lbDbSaveResult.ForeColor = System.Drawing.Color.Green;
                lbDbSaveResult.Text = "Данные успешно сохранены.";
                logger.Info("Данные успешно сохранены.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения данных: {ex.Message}");
                logger.Error(ex, "Ошибка сохранения данных ограничений.");
                lbDbSaveResult.ForeColor = System.Drawing.Color.Red;
                lbDbSaveResult.Text = "Ошибка сохранения данных.";
            }
            finally
            {
                lbDbSaveResult.Visible = false;
            }
        }

        private void cbTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTeacher = comboBoxTeachers.SelectedItem as Teacher;
        }

        private void cbDayOfWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Получаем выбранное значение DayOfWeekEnum из ComboBox
            DayOfWeekEnum selectedDay = (DayOfWeekEnum)cbDayOfWeek.SelectedItem!;
        }

        // Для DataGridView, настройте обработчик события CellFormatting
        private void dgvTeacherConstraintList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Проверяем, если это столбцы с временем
            if (e.ColumnIndex == dgvTeacherConstraintList.Columns["StartTime"].Index && e.Value != null)
            {
                e.Value = ((TimeSpan)e.Value).ToString(@"hh\:mm");  // Форматируем в часы:минуты
            }
            else if (e.ColumnIndex == dgvTeacherConstraintList.Columns["EndTime"].Index && e.Value != null)
            {
                e.Value = ((TimeSpan)e.Value).ToString(@"hh\:mm");  // Форматируем в часы:минуты
            }
        }

    }
}
