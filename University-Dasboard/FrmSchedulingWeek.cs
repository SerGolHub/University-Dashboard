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
using static University_Dasboard.FrmSchedulingDiscipline;
using NLog;

namespace University_Dasboard
{
	public partial class FrmSchedulingWeek : Form
	{
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();

		public FrmSchedulingWeek()
		{
			InitializeComponent();
			LoadData();
		}

		public class ScheduleWeekViewModel
		{
			public Guid Id { get; set; }

			public string ScheduleWeek { get; set; } = string.Empty;
			public int LectureHours { get; set; }
			public int PracticalHours { get; set; }
			public int LaboratoryHours { get; set; }
		}

		private BindingList<ScheduleWeekViewModel> schedules = [];
		private List<ScheduleWeekViewModel> newScheduleList = [];
		private List<ScheduleWeekViewModel> updatedScheduleList = [];
		private List<ScheduleWeekViewModel> removedScheduleList = [];


		private void LoadData()
		{
			using var ctx = new DatabaseContext();

			ScheduleWeekController.LoadSchedulesWeekAsync(dgvSchedules, ref schedules);
			
			dgvSchedules.DataSource = schedules;
			DataGridViewHelper.HideColumns(dgvSchedules, ["Id", "DisciplineId", "TeacherId", "ScheduleDisciplines"]);

			logger.Info("Загрузилось расписание");
		}

		private void ClearTempLists()
		{
			newScheduleList.Clear();
			updatedScheduleList.Clear();
			removedScheduleList.Clear();
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
			string newNameWeek = tbWeek.Text;
			if (string.IsNullOrEmpty(newNameWeek))
			{
				MessageBox.Show("Введите название или номер недели");
				logger.Warn("Пользователь не ввёл название недели");
				return;
			}

			if (tbLectionsHours.Text.Length == 0)
			{
				MessageBox.Show("Для добавления расписания нужно ввести количество часов лекционных работ");
				logger.Warn("Пользователь не ввёл количество часов лекций");
				return;
			}

			if (tbLaboratoryHours.Text.Length == 0)
			{
				MessageBox.Show("Для добавления расписания нужно ввести количество часов лабораторных работ");
				logger.Warn("Пользователь не ввёл количество часов лабораторных");
				return;
			}

			if (tbPracticeHours.Text.Length == 0)
			{
				MessageBox.Show("Для добавления расписания нужно ввести количество часов практических работ");
				logger.Warn("Пользователь не ввёл количество часов практических");
				return;
			}

			var schedule = new ScheduleWeekViewModel()
			{
				Id = Guid.NewGuid(),
				ScheduleWeek = newNameWeek,
				LectureHours = Convert.ToInt32(tbLectionsHours.Text),
				LaboratoryHours = Convert.ToInt32(tbLaboratoryHours.Text),
				PracticalHours = Convert.ToInt32(tbPracticeHours.Text),
			};

			schedules.Add(schedule);
			newScheduleList.Add(schedule);
		}

		async private void btnSave_Click(object sender, EventArgs e)
		{
			lbDbSaveResult.ForeColor = Color.FromArgb(218, 141, 178);
			lbDbSaveResult.Text = "Подождите. Данные сохраняются.";
			logger.Info("Данные сохраняются...");
			lbDbSaveResult.Visible = true;

			await ScheduleWeekController.SaveSchedulesWeekAsync(
						  newScheduleList,
						  updatedScheduleList,
						  removedScheduleList);

			ClearTempLists();
			lbDbSaveResult.ForeColor = Color.FromArgb(118, 241, 178);
			lbDbSaveResult.Text = "Данные успешно сохранены.";
			await Task.Delay(3000);
			lbDbSaveResult.Visible = false;

			logger.Info("Данные добавлены. Сохранение прошло успешно");
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			ClearTempLists();
			LoadData();
		}

		private ScheduleWeekViewModel GetSchedule(Guid id)
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
			ScheduleWeekViewModel deletedSchedule = GetSchedule(id);
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

		private void dgvSchedules_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			var editedRow = dgvSchedules.Rows[e.RowIndex];
			var id = (Guid)editedRow.Cells["Id"].Value;
			ScheduleWeekViewModel updatedDirection = GetSchedule(id);
			updatedScheduleList.Add(updatedDirection);
		}

		private void dgvSchedules_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			Drawer.DrawNumbers(sender, e);
		}
	}
}
