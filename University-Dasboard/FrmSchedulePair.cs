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

            public string Name { get; set; } = string.Empty;

			public DayOfWeek DayOfWeek { get; set; }

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

		private Subject? selectedSubject;
		private Teacher? selectedTeacher;
		private Group? selectedGroup;
		private ScheduleWeek? selectedScheduleDiscipline;
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
            var teachers = ctx.Teacher.ToList();
            ComboboxHelper.LoadCombobox(
                teachers,
                comboBox: comboBoxTeacher);

			// Загрузка Предметов
			var subjects = ctx.Subject.ToList();
			ComboboxHelper.LoadCombobox(
				subjects,
				comboBox: comboBoxDiscipline);

			// Загрузка недель расписания
			var scheduleWeeks = ctx.ScheduleWeek.ToList();

			
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
			if (selectedSubject == null)
			{
				MessageBox.Show("Для добавления расписания нужно выбрать существующую дисциплину");
				logger.Warn("Пользователь не выбрал существующую дисциплину");
				return;
			}

			if (selectedGroup == null)
			{
				MessageBox.Show("Для добавления расписания нужно выбрать существующею группу");
				logger.Warn("Пользователь не выбрал существующую группу");
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

       

        private void cbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedGroup = (Group?)comboBoxGroup.SelectedItem;
        }

        private void cbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSubject = (Database.Models.Subject?)comboBoxDiscipline.SelectedItem;
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
