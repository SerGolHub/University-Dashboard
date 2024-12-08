using Database;
using System.ComponentModel;
using University_Dasboard.Database.Models;
namespace University_Dasboard
{
    public partial class FrmDepartments : Form
    {
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
            departments = DatabaseController.FillBindingList<Department>();
            dgvDepartments.DataSource = departments;
            DataGridViewHelper.HideColumns(dgvDepartments, 
                ["Id", "FacultyId", "Faculty", "Directions", "Disciplines", "Teachers"]);

            var faculties = ctx.Faculty.ToList();
            DataGridViewHelper.LoadCombobox(
                faculties,
                comboBox: cbFaculties,
                comboBoxDisplayMember: "Name",
                comboBoxValueMember: "Id");
        }

        private void ClearTempLists()
        {
            newDepartmentsList.Clear();
            updatedDepartmentsList.Clear();
            removedDepartmentList.Clear();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string newDepartmentName = tbNewDepartmentName.Text;
            if (string.IsNullOrEmpty(newDepartmentName))
            {
                MessageBox.Show("Введите название новой кафедры");
                return;
            }
            if (selectedFaculty == null)
            {
                MessageBox.Show("Для добавления кафедры нужно выбрать существующий факультет");
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
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            lbDbSaveResult.ForeColor = Color.FromArgb(218, 141, 178);
            lbDbSaveResult.Text = "Подождите. Данные сохраняются.";
            lbDbSaveResult.Visible = true;
            if (newDepartmentsList.Count > 0)
            {
                try
                {
                    await DatabaseController.AddToDatabaseAsync(newDepartmentsList);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Во время добавления кафедры(др) произошла ошибка: {ex.Message}");
                }
            }

            if (updatedDepartmentsList.Count > 0)
            {
                try
                {
                    await DatabaseController.UpdateDatabaseAsync(updatedDepartmentsList);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Во время обновления кафедры(др) произошла ошибка: {ex.Message}");
                }
            }

            if (removedDepartmentList.Count > 0)
            {
                try
                {
                    await DatabaseController.DeleteFromDatabaseAsync(removedDepartmentList);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Во время удаления кафедры(др) произошла ошибка: {ex.Message}");
                }
            }

            ClearTempLists();
            lbDbSaveResult.ForeColor = Color.FromArgb(118, 241, 178);
            lbDbSaveResult.Text = "Данные успешно сохранены.";
            await Task.Delay(3000);
            lbDbSaveResult.Visible = false;
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
            var editedRow = dgvDepartments.Rows[e.RowIndex];
            var id = (Guid)editedRow.Cells["Id"].Value;
            Department updatedDepartment = GetDepartment(id);
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
    }
}
