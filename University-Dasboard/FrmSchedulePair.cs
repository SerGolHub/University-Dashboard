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

            public string Name { get; set; } = string.Empty;

            public TimeSpan StartTime { get; set; } // Время начала пары
            public TimeSpan EndTime { get; set; } // Время окончания пары

            public string SubjectName { get; set; } = null!; // Предмет
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

		private Database.Models.Subject? selectedSubject;
		private Faculty? selectedFaculty;
		private Direction? selectedDirection;
		private Group? selectedGroup;
		private ScheduleWeek? selectedScheduleWeek;
		private Teacher? selectedTeacher;
		private Group? selectedGroupMerge;


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
            var faculties = ctx.Faculty.ToList();
            ComboboxHelper.LoadCombobox(
                faculties,
                comboBox: comboBoxFaculties);

			// Загрузка Предметов
			var subjects = ctx.Subject.ToList();
			ComboboxHelper.LoadCombobox(
				subjects,
				comboBox: comboBoxDiscipline);

			// Загрузка недель расписания
			var scheduleWeeks = ctx.ScheduleWeek.ToList();

			ComboboxHelper.LoadCombobox(
				scheduleWeeks,
				comboBox: comboBoxScheduleWeek);

			var teachers = ctx.Teacher.ToList();
            ComboboxHelper.LoadCombobox(
             teachers,
             comboBox: comboBoxTeacher);
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
			if (selectedDirection == null)
			{
				MessageBox.Show("Для добавления расписания нужно выбрать существующее направление");
				logger.Warn("Пользователь не выбрал существующее направление");
				return;
			}

			if (selectedSubject == null)
			{
				MessageBox.Show("Для добавления расписания нужно выбрать существующую дисциплину");
				logger.Warn("Пользователь не выбрал существующую дисциплину");
				return;
			}

			if (selectedFaculty == null)
			{
				MessageBox.Show("Для добавления расписания нужно выбрать существующий факультет");
				logger.Warn("Пользователь не выбрал существующий факультет");
				return;
			}

			if (selectedGroup == null)
			{
				MessageBox.Show("Для добавления расписания нужно выбрать существующею группу");
				logger.Warn("Пользователь не выбрал существующую группу");
				return;
			}

			if (selectedScheduleWeek == null)
			{
				MessageBox.Show("Для добавления расписания нужно выбрать существующее расписание академических часов");
				logger.Info("Пользователь не выбрал расписание академических часов");
				return;
			}
			
			var schedule = new SchedulePairViewModel()
			{
				Id = Guid.NewGuid(),

				SubjectName = selectedSubject.Name,

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

        private void cbFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedFaculty = (Faculty?)comboBoxFaculties.SelectedItem;
            if (selectedFaculty != null)
            {
                // Загружаем департаменты и направления через факультет
                var directionsLoaded = ComboboxHelper.LoadFacultyDirectionGroups(
                    comboBoxDirection,
                    comboBoxGroup,
                    selectedFaculty.Id,
                    selectedDirection?.Id);

				if (!directionsLoaded)
                {
                    MessageBox.Show("Нет доступных направлений.");
                }
            }
        }

        private void cbDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedDirection = (Direction?)comboBoxDirection.SelectedItem;
            if (selectedDirection != null)
            {
                // Загружаем группы через выбранное направление
                var groupsLoaded = ComboboxHelper.LoadDirectionGroups(
                    comboBoxDirection,
                    selectedDirection.Id);

                if (!groupsLoaded)
                {
                    comboBoxDirection.Text = "Группы не найдены";
                }

                // Загружаем MergeGroup через выбранное направление
                var mergeGroupsLoaded = ComboboxHelper.LoadDirectionGroups(
                    comboBoxGroupMerge,
                    selectedDirection.Id);

                if (!mergeGroupsLoaded)
                {
                    comboBoxGroupMerge.Text = "Группы не найдены";
                }
            }
        }

        private void cbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedGroup = (Group?)comboBoxGroup.SelectedItem;
        }

        private void cbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSubject = (Database.Models.Subject?)comboBoxDiscipline.SelectedItem;
        }

        private void cbSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedScheduleWeek = (ScheduleWeek?)comboBoxScheduleWeek.SelectedItem;
        }

        private void cbTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTeacher = (Teacher?)comboBoxTeacher.SelectedItem;
        }

        private void cbGroupMerge_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedGroupMerge = (Group?)comboBoxGroupMerge.SelectedItem;
   
        }

    }
}
