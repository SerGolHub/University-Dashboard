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
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();

		private BindingList<Department> departments = [];
		private List<Department> newDepartmentsList = [];
		private List<Department> updatedDepartmentsList = [];
		private List<Department> removedDepartmentList = [];
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

			var department = new Department
			{
				Id = Guid.NewGuid(),
				Name = newDepartmentName,
				FacultyId = selectedFaculty.Id,
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

		private Department GetDepartment(Guid id)
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
			Department deletedDepartment = GetDepartment(id);
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
			if (e.RowIndex < 0 || e.ColumnIndex < 0)
			{
				return;
			}
			var editedRow = dgvDepartments.Rows[e.RowIndex];
			var id = (Guid)editedRow.Cells["Id"].Value;
			var selectedFacultyId = (Guid)editedRow.Cells["FacultyName"].Value;
			Department updatedDepartment = GetDepartment(id);
			updatedDepartment.FacultyId = selectedFacultyId;
			updatedDepartmentsList.Add(updatedDepartment);

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
			DataGridViewHelper.ExpandComboBoxOnEdit(dgvDepartments, e);
		}
	}
}
