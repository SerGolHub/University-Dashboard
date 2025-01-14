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

namespace University_Dasboard
{
	public partial class FrmSchedulingDiscipline : Form
	{
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();

		public FrmSchedulingDiscipline()
		{
			InitializeComponent();
			LoadData();
		}

		public class ScheduleDisciplineViewModel
		{
			public Guid Id { get; set; }

			public Guid SubjectId { get; set; }
			public string SubjectName { get; set; } = string.Empty;

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

		private Subject? selectedSubject;
		private Faculty? selectedFaculty;
		private Direction? selectedDirection;
		private Group? selectedGroup;
		private ScheduleWeek? selectedScheduleWeek;


		private void LoadData()
		{
			using var ctx = new DatabaseContext();

			ScheduleDesciplineController.LoadSchedules(dgvSchedules, ref schedules);
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
			
			var schedule = new ScheduleDisciplineViewModel()
			{
				Id = Guid.NewGuid(),
				DirectionId = selectedDirection.Id,
				DirectionName = selectedDirection.Name,
				SubjectId = selectedSubject.Id,
				SubjectName = selectedSubject.Name,
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

			await ScheduleDesciplineController.SaveSchedulesAsync(
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
            }
        }

        private void cbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedGroup = (Group?)comboBoxGroup.SelectedItem;
        }

        private void cbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSubject = (Subject?)comboBoxDiscipline.SelectedItem;
        }

        private void cbSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedScheduleWeek = (ScheduleWeek?)comboBoxScheduleWeek.SelectedItem;
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

		}
	}
}
