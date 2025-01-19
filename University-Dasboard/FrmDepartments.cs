using Database;
using NLog;
using System.ComponentModel;
using System.Windows.Forms;
using University_Dasboard.Controllers;
using University_Dasboard.Database.Models;
namespace University_Dasboard
{
	public partial class FrmDepartments : Form
	{
		public class DepartmentViewModel
		{
			public Guid Id { get; set; }
			public required string Name { get; set; }
			public Guid FacultyId { get; set; }
			public string FacultyName { get; set; } = string.Empty;
		}

		private static readonly Logger logger = LogManager.GetCurrentClassLogger();

		private BindingList<DepartmentViewModel> departments = [];
		private List<DepartmentViewModel> newDepartmentsList = [];
		private List<DepartmentViewModel> updatedDepartmentsList = [];
		private List<DepartmentViewModel> removedDepartmentList = [];
		private Faculty? selectedFaculty;

		public FrmDepartments()
		{
			InitializeComponent();
			LoadData();
		}

		private void LoadData()
		{
			var ctx = new DatabaseContext();
			DepartmentController.LoadDepartments(dgvDepartments, ref departments);
			//DataGridViewHelper.HideColumns(dgvDepartments, 
			//    ["Id", "FacultyId", "Faculty", "Directions", "Disciplines", "Teachers"]);

			var faculties = ctx.Faculty.ToList();
			ComboboxHelper.LoadCombobox(
				faculties,
				comboBox: cbFaculties);

			logger.Info("Загрузка всех кафедр произошла успешно");
		}

		private void ClearTempLists()
		{
			newDepartmentsList.Clear();
			updatedDepartmentsList.Clear();
			removedDepartmentList.Clear();

			logger.Info("Очистка списка кафедр");
		}
		private void btnAdd_Click(object sender, EventArgs e)
		{
			string newDepartmentName = tbNewDepartmentName.Text;
			if (string.IsNullOrEmpty(newDepartmentName))
			{
				MessageBox.Show("Введите название новой кафедры");
				logger.Warn("Пользователь не ввёл название кафедры");
				return;
			}
			if (selectedFaculty == null)
			{
				MessageBox.Show("Для добавления кафедры нужно выбрать существующий факультет");
				logger.Warn("Пользователь не выбрал существующий факультет");
				return;
			}

			var department = new DepartmentViewModel
			{
				Id = Guid.NewGuid(),
				Name = newDepartmentName,
				FacultyId = selectedFaculty.Id,
				FacultyName = selectedFaculty.Name
			};
			departments.Add(department);
			newDepartmentsList.Add(department);

			logger.Info("Кафедра успешно добавлена");
		}

		private async void btnSave_Click(object sender, EventArgs e)
		{
			lbDbSaveResult.ForeColor = Color.FromArgb(218, 141, 178);
			lbDbSaveResult.Text = "Подождите. Данные сохраняются.";
			logger.Info("Данные сохраняются");
			lbDbSaveResult.Visible = true;

			await DepartmentController.SaveDepartmentsAsync(
				newDepartmentsList,
				updatedDepartmentsList,
				removedDepartmentList);

			ClearTempLists();
			lbDbSaveResult.ForeColor = Color.FromArgb(118, 241, 178);
			lbDbSaveResult.Text = "Данные успешно сохранены.";
			await Task.Delay(3000);
			lbDbSaveResult.Visible = false;
			logger.Info("Сохранение кафедры прошло успешно");
		}

		private DepartmentViewModel GetDepartment(Guid id)
		{
			return departments.First(d => d.Id == id);
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (dgvDepartments.CurrentRow == null)
			{
				MessageBox.Show("Выделите строку для удаления");
				logger.Warn("Пользователь не выделил кафедру для удаления");
				return;
			}

			var id = (Guid)dgvDepartments.CurrentRow.Cells["Id"].Value;
			DepartmentViewModel deletedDepartment = GetDepartment(id);
			departments.Remove(deletedDepartment);
			newDepartmentsList.Remove(deletedDepartment);
			updatedDepartmentsList.Remove(deletedDepartment);
			removedDepartmentList.Add(deletedDepartment);
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			ClearTempLists();
			LoadData();
		}

		private void dgvDepartments_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
			{
				var editedRow = dgvDepartments.Rows[e.RowIndex];
				var id = (Guid)editedRow.Cells["Id"].Value;
				var selectedFacultyId = (Guid)editedRow.Cells["FacultyName"].Value;
				DepartmentViewModel updatedDepartment = GetDepartment(id);
				updatedDepartment.FacultyId = selectedFacultyId;
				updatedDepartmentsList.Add(updatedDepartment);
			}

		}

		private void dgvDepartments_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			Drawer.DrawNumbers(sender, e);
		}

		private void cbFaculties_SelectedValueChanged(object sender, EventArgs e)
		{
			selectedFaculty = (Faculty?)cbFaculties.SelectedItem;
		}

		private void dgvDepartments_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			DataGridViewCell cell = dgvDepartments.Rows[e.RowIndex].Cells[e.ColumnIndex];
			if (cell is DataGridViewComboBoxCell)
			{
				dgvDepartments.BeginEdit(false);
				((DataGridViewComboBoxEditingControl)dgvDepartments.EditingControl).DroppedDown = true;
			}
		}
	}
}
