using Database;
using System.ComponentModel;
using University_Dasboard.Database.Models;

namespace University_Dasboard
{
    public partial class FrmFaculties : Form
    {
        private BindingList<Faculty> faculties = [];
        private List<Faculty> newFacultiesList = [];
        private List<Faculty> updatedFacultiesList = [];
        private List<Faculty> removedFacultiesList = [];
        public FrmFaculties()
        {
            InitializeComponent();
            LoadData();
            
        }
        private void LoadData()
        {
            var ctx = new DatabaseContext();
            faculties = DatabaseController.FillBindingList<Faculty>();
            dgvFaculties.DataSource = faculties;
            DataGridViewHelper.HideColumns(dgvFaculties, ["Id", "Departments", "Directions", "Students", "ScheduleDisciplines"]);
        }

        private void ClearTempLists()
        {
            newFacultiesList.Clear();
            updatedFacultiesList.Clear();
            removedFacultiesList.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string newFacultyName = tbNewFacultyName.Text;
            if (string.IsNullOrEmpty(newFacultyName))
            {
                MessageBox.Show("Введите название нового факультета");
                return;
            }

            Faculty faculty = new Faculty
            {
                Id = Guid.NewGuid(),
                Name = newFacultyName
            };
            faculties.Add(faculty);
            newFacultiesList.Add(faculty);
        }

        async private void btnSave_Click(object sender, EventArgs e)
        {
            lbDbSaveResult.ForeColor = Color.FromArgb(218, 141, 178);
            lbDbSaveResult.Text = "Подождите. Данные сохраняются.";
            lbDbSaveResult.Visible = true;
            if (newFacultiesList.Count > 0)
            {
                try
                {
                    await DatabaseController.AddToDatabaseAsync(newFacultiesList);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Во время добавления факультета(ов) произошла ошибка: {ex.Message}");
                }
            }

            if (updatedFacultiesList.Count > 0)
            {
                try
                {
                    await DatabaseController.UpdateDatabaseAsync(updatedFacultiesList);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Во время обновления факультета(ов) произошла ошибка: {ex.Message}");
                }
            }

            if (removedFacultiesList.Count > 0)
            {
                try
                {
                    await DatabaseController.DeleteFromDatabaseAsync(removedFacultiesList);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Во время удаления факультета(ов) произошла ошибка: {ex.Message}");
                }
            }
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

        private Faculty GetFacultyId(Guid id)
        {
            return faculties.First(d => d.Id == id);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvFaculties.CurrentRow == null)
            {
                MessageBox.Show("Выделите строку для удаления");
                return;
            }
            var id = (Guid)dgvFaculties.CurrentRow.Cells["Id"].Value;
            Faculty deletedFaculty = GetFacultyId(id);
            faculties.Remove(deletedFaculty);
            newFacultiesList.Remove(deletedFaculty);
            updatedFacultiesList.Remove(deletedFaculty);
            removedFacultiesList.Add(deletedFaculty);
        }

        private void dgvFaculties_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var editedRow = dgvFaculties.Rows[e.RowIndex];
            var id = (Guid)editedRow.Cells["Id"].Value;
            Faculty updatedFaculty = GetFacultyId(id);
            updatedFacultiesList.Add(updatedFaculty);
        }

        private void dgvFaculties_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Drawer.DrawNumbers(sender, e);
        }
    }
}
