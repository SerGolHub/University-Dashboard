using Database;
using System.ComponentModel;
using University_Dasboard.Controllers;
using University_Dasboard.Database.Models;

namespace University_Dasboard
{
	public partial class FrmGroups : Form
	{
		public FrmGroups()
		{
			InitializeComponent();
			LoadData();
		}

		public class GroupViewModel
		{
			public Guid Id { get; set; }
			public string Name { get; set; } = string.Empty;
			public int CourseNumber { get; set; }

			public Guid DirectionId { get; set; }
		}

		private BindingList<GroupViewModel> groups = [];
		private List<GroupViewModel> newGroupList = [];
		private List<GroupViewModel> updatedGroupList = [];
		private List<GroupViewModel> removedGroupList = [];
		private Faculty? selectedFaculty;
		private Department? selectedDepartment;
		private Direction? selectedDirection;
		private int? selectedCourseNumber;
		private bool canSaveChanges = true;

		private void LoadData()
		{
			using var ctx = new DatabaseContext();
			GroupController.LoadGroups(dgvGroupList, ref groups);
			DataGridViewHelper.HideColumns(dgvGroupList,
				["Id", "DirectionId", "Direction"]);
			var faculties = ctx.Faculty.ToList();
			ComboboxHelper.LoadCombobox(
				faculties,
				comboBox: cbFaculty);
		}

		private void ClearTempLists()
		{
			newGroupList.Clear();
			updatedGroupList.Clear();
			removedGroupList.Clear();
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

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(tbGroupName.Text))
			{
				MessageBox.Show("Введите название группы");
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
			if (selectedDirection == null)
			{
				MessageBox.Show("Выберите направление");
				return;
			}
			if (selectedCourseNumber == null)
			{
				MessageBox.Show("Выберите направление");
				return;
			}
			var newGroup = new GroupViewModel()
			{
				Id = Guid.NewGuid(),
				Name = tbGroupName.Text,
				CourseNumber = (int)selectedCourseNumber,
				DirectionId = selectedDirection.Id,
			};
			groups.Add(newGroup);
			newGroupList.Add(newGroup);
		}

		private async void btnSave_Click(object sender, EventArgs e)
		{
			if (!CanSaveChanges(canSaveChanges))
			{
				return;
			}

			lbDbSaveResult.ForeColor = Color.FromArgb(218, 141, 178);
			lbDbSaveResult.Text = "Подождите. Данные сохраняются.";
			lbDbSaveResult.Visible = true;

			await GroupController.SaveGroupsAsync(
				newGroupList,
				updatedGroupList,
				removedGroupList);

			ClearTempLists();
			lbDbSaveResult.ForeColor = Color.FromArgb(118, 241, 178);
			lbDbSaveResult.Text = "Данные успешно сохранены.";
			await Task.Delay(3000);
			lbDbSaveResult.Visible = false;
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			ClearTempLists();
			LoadData();
		}

		private GroupViewModel GetGroup(Guid id)
		{
			return groups.First(g => g.Id == id);
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (dgvGroupList.CurrentRow == null)
			{
				MessageBox.Show("Выделите строку для удаления");
				return;
			}
			var id = (Guid)dgvGroupList.CurrentRow.Cells["Id"].Value;
			GroupViewModel deletedGroup = GetGroup(id);
			groups.Remove(deletedGroup);
			newGroupList.Remove(deletedGroup);
			updatedGroupList.Remove(deletedGroup);
			removedGroupList.Add(deletedGroup);
		}

		private void dgvGroupList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0 || e.ColumnIndex < 0)
			{
				return;
			}
			var editedRow = dgvGroupList.Rows[e.RowIndex];
			string columnName = dgvGroupList.Columns[e.ColumnIndex].Name;
			var cell = editedRow.Cells[e.ColumnIndex];

			var id = (Guid)editedRow.Cells["Id"].Value;
			GroupViewModel updatedGroup = GetGroup(id);

			if (columnName == "CourseNumber")
			{
				int editedCourseNumber;
				try
				{
					editedCourseNumber = Convert.ToInt32(editedRow.Cells["CourseNumber"].Value);
				}
				catch
				{
					MessageBox.Show("Введите цифру курса");
					CanSaveChanges(false);
					cell.Style.BackColor = Color.FromArgb(218, 141, 178);
					return;
				}
				if (editedCourseNumber < 1)
				{
					MessageBox.Show("Курс не может быть меньше 1");
					CanSaveChanges(false);
					cell.Style.BackColor = Color.FromArgb(218, 141, 178);
					return;
				}
				using var ctx = new DatabaseContext();
				int maxCourseNumber = Convert.ToInt32(ctx.Group
					.Where(g => g.Id == updatedGroup.Id)
					.Select(g => g.Direction!.MaxCourse)
					.First());
				if (editedCourseNumber > maxCourseNumber)
				{
					MessageBox.Show($"Курс выбранной группы не может быть больше {maxCourseNumber}");
					CanSaveChanges(false);
					cell.Style.BackColor = Color.FromArgb(218, 141, 178);
					return;
				}
			}
			cell.Style.BackColor = Color.White;
			CanSaveChanges(true);
			updatedGroupList.Add(updatedGroup);
		}



		private void dgvGroupList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
			}
		}

		private void cbDirection_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedDirection = (Direction?)cbDirection.SelectedItem;
			if (selectedDirection != null)
			{
				using var ctx = new DatabaseContext();
				var maxCourse = ctx.Direction
					.Where(dir => dir.Id == selectedDirection.Id)
					.Select(dir => dir.MaxCourse)
					.First();
				List<int> coursesList = [];
				for (int i = 1; i <= maxCourse; i++)
				{
					coursesList.Add(i);
				}
				cbCourse.DataSource = coursesList;
				cbCourse.Update();
			}
		}

		private void cbCourse_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedCourseNumber = (int?)cbCourse.SelectedItem;
		}

		private void dgvGroupList_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			DataGridViewHelper.ExpandComboBoxOnEdit(dgvGroupList, e);
		}

		private void dgvGroupList_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			var editedRow = dgvGroupList.Rows[e.RowIndex];
			string columnName = dgvGroupList.Columns[e.ColumnIndex].Name;
			var cell = editedRow.Cells[e.ColumnIndex];

			if (columnName == "CourseNumber")
			{
				MessageBox.Show("Поле может содержать только цифру");
				return;
			}
		}
	}
}
