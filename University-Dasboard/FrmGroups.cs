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

			public Guid DirectionId { get; set; }
			public string DirectionName { get; set; } = string.Empty;
		}

		private BindingList<GroupViewModel> groups = [];
		private List<GroupViewModel> newGroupList = [];
		private List<GroupViewModel> updatedGroupList = [];
		private List<GroupViewModel> removedGroupList = [];
		private Faculty? selectedFaculty;
		private Department? selectedDepartment;
		private Direction? selectedDirection;

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
			var newGroup = new GroupViewModel()
			{
				Id = Guid.NewGuid(),
				Name = tbGroupName.Text,
				DirectionId = selectedDirection.Id,
				DirectionName = selectedDirection.Name,
			};
			groups.Add(newGroup);
			newGroupList.Add(newGroup);
		}

		private async void btnSave_Click(object sender, EventArgs e)
		{
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
			var editedRow = dgvGroupList.Rows[e.RowIndex];
			var id = (Guid)editedRow.Cells["Id"].Value;
			GroupViewModel updatedGroup = GetGroup(id);
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
		}
	}
}
