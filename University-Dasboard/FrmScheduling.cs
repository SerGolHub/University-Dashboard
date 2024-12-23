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

namespace University_Dasboard
{
	public partial class FrmScheduling : Form
	{
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();

		public FrmScheduling()
		{
			InitializeComponent();
			LoadData();
		}

		public class ScheduleDisciplineViewModel
		{
			public Guid Id { get; set; }

			public Guid DisciplineId { get; set; }
			public string DisciplineName { get; set; } = string.Empty;
			public Guid FacultyId { get; set; }
			public string FacultyName { get; set; } = string.Empty;
			public Guid DirectionId { get; set; }
			public string DirectionName { get; set; } = string.Empty;
			public Guid GroupId { get; set; }
			public string GroupName { get; set; } = string.Empty;

			public Guid ScheduleWeekId { get; set; }
			public string ScheduleWeek { get; set; } = string.Empty;
			public int LectureHours { get; set; }
			public int PracticalHours { get; set; }
			public int LaboratoryHours { get; set; }
		}

		private BindingList<ScheduleDisciplineViewModel> schedules = new();
		private List<ScheduleDisciplineViewModel> newScheduleList = [];
		private List<ScheduleDisciplineViewModel> updatedScheduleList = [];
		private List<ScheduleDisciplineViewModel> removedScheduleList = [];

		private Discipline? selectedDiscipline;
		private Faculty? selectedFaculty;
		private Direction? selectedDirection;
		private Group? selectedGroup;
		private ScheduleWeek? selectedScheduleWeek;


		private void LoadData()
		{
			using var ctx = new DatabaseContext();

			DataGridViewHelper.HideColumns(dgvSchedules,
				["Id", "FacultyId", "DisciplineId", "DirectionId", "GroupId", "ScheduleWeekId"]);
			LoadComboboxData(ctx);

			logger.Info("Данные расписания успешно загружены");
		}

		private void LoadComboboxData(DatabaseContext ctx)
		{
			// Загрузка факультетов
			var faculties = ctx.Faculty
				.Select(f => new { f.Id, f.Name })
				.ToList();

            ComboboxHelper.LoadCombobox(
				faculties,
				comboBox: comboBoxFaculties);

			// Загрузка направлений
			var directions = ctx.Direction
				.Select(d => new { d.Id, d.Name })
				.ToList();

            ComboboxHelper.LoadCombobox(
				directions,
				comboBox: comboBoxDirection);

			// Загрузка групп
			var groups = ctx.Group
				.Select(g => new { g.Id, g.Name })
				.ToList();

            ComboboxHelper.LoadCombobox(
				groups,
				comboBox: comboBoxGroup);

			// Загрузка недель расписания
			var scheduleWeeks = ctx.ScheduleWeek
				.Select(sw => new { sw.Id, sw.Name })
				.ToList();

            ComboboxHelper.LoadCombobox(
				scheduleWeeks,
				comboBox: comboBoxScheduleWeek);
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

			if (selectedDiscipline == null)
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
			
			var schedule = new ScheduleDisciplineViewModel()
			{
				Id = Guid.NewGuid(),
				DirectionId = selectedDirection.Id,
				DirectionName = selectedDirection.Name,
				DisciplineId = selectedDiscipline.Id,
				DisciplineName = selectedDiscipline.Name,
				FacultyId = selectedFaculty.Id,
				FacultyName = selectedFaculty.Name,
				GroupId = selectedGroup.Id,
				GroupName = selectedGroup.Name,
				ScheduleWeekId = selectedScheduleWeek.Id,
				ScheduleWeek = selectedScheduleWeek.Name,
				LectureHours = selectedScheduleWeek.LectureHours,
				PracticalHours = selectedScheduleWeek.PracticalHours,
				LaboratoryHours = selectedScheduleWeek.LaboratoryHours,
			};

			schedules.Add(schedule);
			newScheduleList.Add(schedule);
		}

		async private void btnSave_Click(object sender, EventArgs e)
		{
			lbDbSaveResult.ForeColor = Color.FromArgb(218, 141, 178);
			lbDbSaveResult.Text = "Подождите. Данные сохраняются.";
			logger.Info("Данные сохраняются");
			lbDbSaveResult.Visible = true;


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

		private ScheduleDisciplineViewModel GetSchedule(Guid id)
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
			ScheduleDisciplineViewModel deletedSchedule = GetSchedule(id);
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
			ScheduleDisciplineViewModel updatedSchedule = GetSchedule(id);
			updatedScheduleList.Add(updatedSchedule);
		}

		private void dgvSchedules_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			Drawer.DrawNumbers(sender, e);
		}

		private void GenerateReport(object sender, EventArgs e)
		{
			string fileName = "";

			using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
			{
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					fileName = dialog.FileName.ToString();
					MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}

			var config = new WordWithTableConfig
			{
				FilePath = fileName,
				Header = "ГРАФИК УЧЕБНОГО ПРОЦЕССА",
				Footer = "Создано ",
				ColumnsRowsWidth = new List<(int, int)> { (0, 5), (0, 5), (0, 10), (0, 10), (0, 7), (0, 7), (0, 10), (0, 10), (0, 8) },
				UseUnion = true,
				ColumnsRowsDataCount = (8, 8),
				Headers = new List<(int ColumnIndex, int RowIndex, string Header, string PropertyName)>	{
				(0, 0, "Форма занятий:", ""),
				(1, 0, "Недели:", ""),
				(2, 0, "1", ""),
				(3, 0, "2", ""),
				(4, 0, "3", ""),
				(5, 0, "4", ""),
				(6, 0, "5", ""),
				(7, 0, "6", ""),
				(8, 0, "7", ""),
				(9, 0, "8", ""),
				(10, 0, "9", ""),
				(11, 0, "10", ""),
				(12, 0, "11", ""),
				(13, 0, "12", ""),
				(14, 0, "13", ""),
				(15, 0, "14", ""),
				(16, 0, "15", ""),
				(17, 0, "16", ""),
				(18, 0, "17", ""),
				(19, 0, "18", ""),
				(20, 0, "Σ", ""),
				(21, 0, "Отчётность", ""),
				}
			};

			var report = new WordWithTableReport(config);
			report.GenerateReport(fileName);
		}
	}
}
