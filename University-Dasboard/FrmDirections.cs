﻿using Database;
using NLog;
using System.ComponentModel;
using University_Dasboard.Controllers;
using University_Dasboard.Database.Models;

namespace University_Dasboard
{
	public partial class FrmDirections : Form
	{
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();

		public class DirectionViewModel
		{
			public Guid Id { get; set; }
			public string Name { get; set; } = string.Empty;
			public string Code { get; set; } = string.Empty;
			public int MaxCourse { get; set; }
			public Guid FacultyId { get; set; }
			public Guid DepartmentId { get; set; }
		}

		private BindingList<DirectionViewModel> directions = [];
		private List<DirectionViewModel> newDirectionList = [];
		private List<DirectionViewModel> updatedDirectionList = [];
		private List<DirectionViewModel> removedDirectionList = [];
		private Faculty? selectedFaculty;
		private Department? selectedDepartment;


		public FrmDirections()
		{
			InitializeComponent();
			LoadData();
		}

		private void LoadData()
		{
			using var ctx = new DatabaseContext();

			DirectionController.LoadDirections(dgvDirections, ref directions);
			DataGridViewHelper.HideColumns(dgvDirections,
				["Id", "DepartmentId", "FacultyId", "Groups"]);
			var faculties = ctx.Faculty.ToList();
			ComboboxHelper.LoadCombobox(
				faculties,
				comboBox: cbFaculty);

			logger.Info("Направления были успешно загружены");
		}

		private void ClearTempLists()
		{
			newDirectionList.Clear();
			updatedDirectionList.Clear();
			removedDirectionList.Clear();

			logger.Info("Очистка списка направлений");
		}

		private void tbMaxCourse_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			string newDirectionName = tbNewDirectionName.Text;
			if (string.IsNullOrEmpty(newDirectionName))
			{
				MessageBox.Show("Введите название нового направления");
				logger.Warn("Пользователь не ввёл название нового направления");
				return;
			}
			if (selectedFaculty == null)
			{
				MessageBox.Show("Выберите факультет");
				logger.Warn("Пользователь не выбрал факультет для нового направления");
				return;
			}
			if (selectedDepartment == null)
			{
				MessageBox.Show("Выберите кафедру");
				logger.Warn("Пользователь не выбрал кафедру для нового направления");
				return;
			}
			if (tbDirectionCode.Text.Length == 0)
			{
				MessageBox.Show("Введите код направления");
				logger.Warn("Пользователь не ввёл нужный код направления для нового направления");
				return;
			}
			if (tbMaxCourse.Text.Length == 0)
			{
				MessageBox.Show("Введите цифру последнего курса");
				logger.Warn("Пользователь не ввёл последний курс для нового направления");
				return;
			}

			var direction = new DirectionViewModel()
			{
				Id = Guid.NewGuid(),
				Name = newDirectionName,
				Code = tbDirectionCode.Text,
				MaxCourse = Convert.ToInt32(tbMaxCourse.Text),
				FacultyId = selectedFaculty.Id,
				DepartmentId = selectedDepartment.Id,
			};

			directions.Add(direction);
			newDirectionList.Add(direction);

			logger.Info("Данные успешно загружены.");
		}

		async private void btnSave_Click(object sender, EventArgs e)
		{
			lbDbSaveResult.ForeColor = Color.FromArgb(218, 141, 178);
			lbDbSaveResult.Text = "Подождите. Данные сохраняются.";
			logger.Info("Данные сохраняются...");
			lbDbSaveResult.Visible = true;

			await DirectionController.SaveDirectionsAsync(
				newDirectionList,
				updatedDirectionList,
				removedDirectionList);

			ClearTempLists();
			lbDbSaveResult.ForeColor = Color.FromArgb(118, 241, 178);
			lbDbSaveResult.Text = "Данные успешно сохранены.";
			await Task.Delay(3000);
			lbDbSaveResult.Visible = false;
			logger.Info("Данные загружены и успешно сохранены в базе данных.");
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			ClearTempLists();
			LoadData();
		}

		private DirectionViewModel GetDirection(Guid id)
		{
			return directions.First(d => d.Id == id);
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (dgvDirections.CurrentRow == null)
			{
				MessageBox.Show("Выделите строку для удаления");
				logger.Warn("Пользователь не выделил строчку для удаления.");
				return;
			}

			var id = (Guid)dgvDirections.CurrentRow.Cells["Id"].Value;
			DirectionViewModel deletedDirection = GetDirection(id);
			directions.Remove(deletedDirection);
			newDirectionList.Remove(deletedDirection);
			updatedDirectionList.Remove(deletedDirection);
			removedDirectionList.Add(deletedDirection);

			logger.Info("Пользователь успешно удалил направление из базы данных.");
		}

		private void dgvDirections_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0 || e.ColumnIndex < 0)
			{
				return;
			}
			var editedRow = dgvDirections.Rows[e.RowIndex];
			var id = (Guid)editedRow.Cells["Id"].Value;
			DirectionViewModel updatedDirection = GetDirection(id);
			updatedDirectionList.Add(updatedDirection);
		}

		private void dgvDirections_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			Drawer.DrawNumbers(sender, e);
		}

		private void cbFaculty_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedFaculty = (Faculty?)cbFaculty.SelectedItem;
			if (selectedFaculty != null)
			{
				ComboboxHelper.LoadFacultyDepartments(
					cbDepartments,
					selectedFaculty.Id,
					selectedDepartment);
			}
		}

		private void cbDepartment_SelectedValueChanged(object sender, EventArgs e)
		{
			selectedDepartment = (Department?)cbDepartments.SelectedItem;
		}

		private void dgvDirections_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			DataGridViewHelper.ExpandComboBoxOnEdit(dgvDirections, e);
		}
	}
}
