﻿using Database;
using NLog;
using System.ComponentModel;
using System.Data;
using University_Dasboard.Controllers;
using University_Dasboard.Database.Models;

namespace University_Dasboard
{
	public partial class FrmSubjects : Form
	{
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();

		public FrmSubjects()
		{
			InitializeComponent();
			LoadData();
		}

		public class DisciplineViewModel
		{
			public Guid Id { get; set; }
			public string Name { get; set; } = string.Empty;
			public string Semester { get; set; } = string.Empty;

			public Guid DirectionId { get; set; }
			public Guid TeacherId { get; set; }
		}


		private BindingList<DisciplineViewModel> disciplines = [];
		private List<DisciplineViewModel> newDisciplinesList = [];
		private List<DisciplineViewModel> updatedDisciplinesList = [];
		private List<DisciplineViewModel> removedDisciplinesList = [];
		private Faculty? selectedFaculty;
		private Department? selectedDepartment;
		private Direction? selectedDirection;
		private Teacher? selectedTeacher;
		private bool canSaveChanges = true;

		private void LoadData()
		{
			logger.Info("Начата загрузка дисциплин");
			using var ctx = new DatabaseContext();
			SubjectController.LoadDisciplines(dgvDisciplines, ref disciplines);
			DataGridViewHelper.HideColumns(dgvDisciplines,
				["Id", "DepartmentId", "TeacherId", "DirectionId"]);
			var faculties = ctx.Faculty.ToList();
			ComboboxHelper.LoadCombobox(
				faculties,
				comboBox: cbFaculty);
			logger.Info("Загрузка дисциплин завершена");
		}

		private void ClearTempLists()
		{
			updatedDisciplinesList.Clear();
			removedDisciplinesList.Clear();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			string newSubjectName = tbNewDisciplineName.Text;
			if (string.IsNullOrEmpty(newSubjectName))
			{
				MessageBox.Show("Введите название новой дисциплины");
				logger.Warn("Пользователь не ввёл название новой дисциплины");
				return;
			}
			if (selectedFaculty == null)
			{
				MessageBox.Show("Выберите факультет");
				return;
			}
			if (selectedDepartment == null)
			{
				MessageBox.Show("Выберите кафедру");
				return;
			}
			if (selectedTeacher == null)
			{
				MessageBox.Show("Выберите преподавателя");
				return;
			}
			if (selectedDirection == null)
			{
				MessageBox.Show("Выберите направление");
				return;
			}
			if (tbSemesters.Text == string.Empty)
			{
				MessageBox.Show("Введите семестры дисциплины через пробел");
				return;
			}

			var discipline = new DisciplineViewModel()
			{
				Id = Guid.NewGuid(),
				Name = newSubjectName,
				Semester = tbSemesters.Text,
				DirectionId = selectedDirection.Id,
				TeacherId = selectedTeacher.Id,
			};
			disciplines.Add(discipline);
			newDisciplinesList.Add(discipline);

			logger.Info("Пользователь успешно добавил дисциплину");
		}

		private async void btnSave_Click(object sender, EventArgs e)
		{
			if (!CanSaveChanges(canSaveChanges))
			{
				return;
			}

			lbDbSaveResult.ForeColor = Color.FromArgb(218, 141, 178);
			lbDbSaveResult.Text = "Подождите. Данные сохраняются.";
			logger.Info("Данные сохраняются....");
			lbDbSaveResult.Visible = true;

			try
			{

				await SubjectController.SaveDisciplinesAsync(
					newDisciplinesList,
					updatedDisciplinesList,
					removedDisciplinesList);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Возникла ошибка: {ex}");
				logger.Error($"Возникла ошибка: {ex.Message}");
			}

			lbDbSaveResult.ForeColor = Color.FromArgb(118, 241, 178);
			lbDbSaveResult.Text = "Данные успешно сохранены.";
			await Task.Delay(3000);
			lbDbSaveResult.Visible = false;

			logger.Info("Данные успешно сохранены");
		}

		private DisciplineViewModel GetDiscipline(Guid id)
		{
			return disciplines.First(dis => dis.Id == id);
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (dgvDisciplines.CurrentRow == null)
			{
				MessageBox.Show("Выделите строку для удаления");
				return;
			}
			var id = (Guid)dgvDisciplines.CurrentRow.Cells["Id"].Value;
			DisciplineViewModel deletedDiscipline = GetDiscipline(id);
			disciplines.Remove(deletedDiscipline);
			newDisciplinesList.Remove(deletedDiscipline);
			updatedDisciplinesList.Remove(deletedDiscipline);
			removedDisciplinesList.Add(deletedDiscipline);
			logger.Info("Пользователь удалил дисциплину из списка.");
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			ClearTempLists();
			LoadData();
			CanSaveChanges(true);
		}
		public bool CanSaveChanges(bool value)
		{
			if (value)
			{
				canSaveChanges = true;
				lbDbSaveResult.Visible = false;
			}
			else
			{
				canSaveChanges = false;
				lbDbSaveResult.Text = "Невозможно сохранить изменения";
				lbDbSaveResult.ForeColor = Color.FromArgb(218, 141, 178);
				lbDbSaveResult.Visible = true;
			}
			return canSaveChanges;
		}

		private void dgvSubjects_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0 || e.ColumnIndex < 0)
			{
				return;
			}
			var editedRow = dgvDisciplines.Rows[e.RowIndex];
			string columnName = dgvDisciplines.Columns[e.ColumnIndex].Name;
			var cell = editedRow.Cells[e.ColumnIndex];

			if (columnName == "Semester")
			{
				string semestersString = (string)editedRow.Cells["Semester"].Value;
				// Посимвольная проверка на ввод только цифры или пробела
				foreach (char c in semestersString)
				{
					// Если не цифра или не пробел, то выдаём ошибку
					if (!Char.IsDigit(c) && c != (char)Keys.Space)
					{
						MessageBox.Show("В колонке Семестр можно вводить только цифры через пробел");
						CanSaveChanges(false);
						cell.Style.BackColor = Color.FromArgb(218, 141, 178);
						return;
					}
				}
			}
			CanSaveChanges(true);
			cell.Style.BackColor = Color.White;
			var id = (Guid)editedRow.Cells["Id"].Value;
			DisciplineViewModel updatedSubject = GetDiscipline(id);
			updatedDisciplinesList.Add(updatedSubject);
		}

		private void dgvSubjects_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			Drawer.DrawNumbers(sender, e);
		}

		private void cbFaculty_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedFaculty = (Faculty?)cbFaculty.SelectedItem;
			if (selectedFaculty != null)
			{
				ComboboxHelper.LoadFacultyDepartments(
					cbDepartment,
					cbDirection,
					selectedFaculty.Id,
					selectedDepartment,
					selectedDirection);
			}
		}

		private void cbDepartment_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedDepartment = (Department?)cbDepartment.SelectedItem;
			if (selectedDepartment != null)
			{
				ComboboxHelper.LoadDepartmentDirections(
					cbDirection,
					selectedDepartment.Id,
					selectedDirection);
				ComboboxHelper.LoadDepartmentTeachers(
					cbTeacher,
					selectedDepartment.Id,
					selectedTeacher);
			}
		}

		private void cbDirection_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedDirection = (Direction?)cbDirection.SelectedItem;
		}

		private void cbTeacher_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedTeacher = (Teacher?)cbTeacher.SelectedItem;
		}

		private void tbSemesters_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Space)
			{
				e.Handled = true;
			}
		}

		private void dgvDisciplines_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			DataGridViewHelper.ExpandComboBoxOnEdit(dgvDisciplines, e);
		}
	}
}
