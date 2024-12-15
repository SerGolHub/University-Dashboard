using Database;
using Microsoft.EntityFrameworkCore;
using NLog;
using System.ComponentModel;
using University_Dasboard.Controllers;
using University_Dasboard.Database.Models;

namespace University_Dasboard
{
    public partial class FrmDirections : Form
    {
        public class DirectionViewModel
        {
            public Guid Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Code { get; set; } = string.Empty;
            public int MaxCourse { get; set; }
            public Guid FacultyId { get; set; }
            public string FacultyName { get; set; } = string.Empty;
            public Guid DepartmentId { get; set; }
            public string DepartmentName { get; set; } = string.Empty;
        }

        private BindingList<DirectionViewModel> directions = [];
        private List<DirectionViewModel> newDirectionList = [];
        private List<DirectionViewModel> updatedDirectionList = [];
        private List<DirectionViewModel> removedDirectionList = [];
        private Department? selectedDepartment;
        

        public FrmDirections()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using var ctx = new DatabaseContext();

            DirectionController.LoadDirectionsAsync(dgvDirections, ref directions);
            DataGridViewHelper.HideColumns(dgvDirections,
                ["Id", "DepartmentId", "FacultyId", "Groups"]);
            LoadComboboxData(ctx);
        }
        private void LoadComboboxData(DatabaseContext ctx)
        {
            var departments = ctx.Department
                .Include(d => d.Faculty)
                .ToList();

            ComboboxHelper.LoadCombobox(
                departments,
                comboBox: cbDepartments);
        }

        private void ClearTempLists()
        {
            newDirectionList.Clear();
            updatedDirectionList.Clear();
            removedDirectionList.Clear();
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
                return;
            }
            if (selectedDepartment == null)
            {
                MessageBox.Show("Для добавления направления нужно выбрать существующую кафедру");
                return;
            }
            if (tbDirectionCode.Text.Length == 0)
            {
                MessageBox.Show("Для добавления направления нужно ввести код направления");
                return;
            }
            if (tbMaxCourse.Text.Length == 0)
            {
                MessageBox.Show("Для добавления направления нужно ввести цифру последнего курса");
                return;
            }

            var direction = new DirectionViewModel()
            {
                Id = Guid.NewGuid(),
                Name = newDirectionName,
                Code = tbDirectionCode.Text,
                MaxCourse = Convert.ToInt32(tbMaxCourse.Text),
                FacultyId = selectedDepartment.FacultyId,
                FacultyName = selectedDepartment.Faculty.Name,
                DepartmentId = selectedDepartment.Id,
                DepartmentName = selectedDepartment.Name
            };
            directions.Add(direction);
            newDirectionList.Add(direction);
        }

        async private void btnSave_Click(object sender, EventArgs e)
        {
            lbDbSaveResult.ForeColor = Color.FromArgb(218, 141, 178);
            lbDbSaveResult.Text = "Подождите. Данные сохраняются.";
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
                return;
            }
            var id = (Guid)dgvDirections.CurrentRow.Cells["Id"].Value;
            DirectionViewModel deletedDirection = GetDirection(id);
            directions.Remove(deletedDirection);
            newDirectionList.Remove(deletedDirection);
            updatedDirectionList.Remove(deletedDirection);
            removedDirectionList.Add(deletedDirection);
        }

        private void dgvDirections_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var editedRow = dgvDirections.Rows[e.RowIndex];
            var id = (Guid)editedRow.Cells["Id"].Value;
            DirectionViewModel updatedDirection = GetDirection(id);
            updatedDirectionList.Add(updatedDirection);
        }

        private void dgvDirections_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Drawer.DrawNumbers(sender, e);
        }

        private void cbDepartment_SelectedValueChanged(object sender, EventArgs e)
        {
            selectedDepartment = (Department?)cbDepartments.SelectedItem;
        }
    }
}
