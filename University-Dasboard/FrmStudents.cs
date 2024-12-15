using Database;
using Microsoft.EntityFrameworkCore;
using NLog;
using System.Collections.Generic;
using System.ComponentModel;
using University_Dasboard.Controllers;
using University_Dasboard.Database.Models;

namespace University_Dasboard
{
    public partial class FrmStudents : Form
    {
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();

		public class StudentViewModel
        {
            public Guid Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public DateTime EnrollmentDate { get; set; }
            public required string EnrollmentNumber { get; set; }
            public bool IsExcellentStudent { get; set; }
            public int CourseNumber { get; set; }

            public Guid GroupId { get; set; }
            public string GroupName { get; set; } = String.Empty;
        }

        public FrmStudents()
        {
            InitializeComponent();
            LoadData();
        }

        private BindingList<StudentViewModel> students = [];
        private List<StudentViewModel> newStudentList = [];
        private List<StudentViewModel> updatedStudentList = [];
        private List<StudentViewModel> removedStudentList = [];
        private Faculty? selectedFaculty;
        private Department? selectedDepartment;
        private Direction? selectedDirection;
        private int? selectedCourse;
        private Group? selectedGroup;
        private bool? isExcelent;

        private void LoadData()
        {
            using var ctx = new DatabaseContext();
            StudentController.LoadStudents(dgvStudentList, ref students);
            DataGridViewHelper.HideColumns(dgvStudentList,
                ["Id", "GroupId", "Marks"]);
            var faculties = ctx.Faculty.ToList();
            DataGridViewHelper.LoadCombobox(
                faculties,
                comboBox: cbFaculty);

            logger.Info("Список студентов успешно загружен.");
        }

        private void ClearTempLists()
        {
            newStudentList.Clear();
            updatedStudentList.Clear();
            removedStudentList.Clear();

            logger.Info("Список студентов очищен.");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string fullName = tbFullName.Text;
            if (fullName == string.Empty)
            {
                MessageBox.Show("Введите ФИО студента.");
                logger.Warn("Пользователь не ввёл ФИО студента.");
                return;
            }


            logger.Info("Студент успешно добавлен в базу данных.");
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            lbDbSaveResult.ForeColor = Color.FromArgb(218, 141, 178);
            lbDbSaveResult.Text = "Подождите. Данные сохраняются.";
            logger.Info("Данные сохраняются....");
            lbDbSaveResult.Visible = true;

            await StudentController.SaveStudentsAsync(
                newStudentList,
                updatedStudentList,
                removedStudentList);

            ClearTempLists();
            lbDbSaveResult.ForeColor = Color.FromArgb(118, 241, 178);
            lbDbSaveResult.Text = "Данные успешно сохранены.";
            await Task.Delay(3000);
            lbDbSaveResult.Visible = false;

            logger.Info("Студент успешно сохранён. Данные загружены и сохранены.");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearTempLists();
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudentList.CurrentRow == null)
            {
                MessageBox.Show("Выделите строку для удаления");
				logger.Info("Пользователь не выделил строку для удаления");
				return;
            }

            var id = (Guid)dgvStudentList.CurrentRow.Cells["Id"].Value;
            StudentViewModel deletedStudent = GetStudent(id);
            students.Remove(deletedStudent);
            newStudentList.Remove(deletedStudent);
            updatedStudentList.Remove(deletedStudent);
            removedStudentList.Add(deletedStudent);

            logger.Info("Студент удалён из базы данных.");
        }

        private StudentViewModel GetStudent(Guid id)
        {
            return students.First(s => s.Id == id);
        }
        private void dgvStudentList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var editedRow = dgvStudentList.Rows[e.RowIndex];
            var id = (Guid)editedRow.Cells["Id"].Value;
            StudentViewModel updatedStudent= GetStudent(id);
            updatedStudentList.Add(updatedStudent);
        }

        private void dgvStudentList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Drawer.DrawNumbers(sender, e);
        }

        private void LoadComboboxData<T>(ComboBox cb) where T : class
        {
            using var ctx = new DatabaseContext();
            var entityList = ctx.Set<T>().ToList();
            DataGridViewHelper.LoadCombobox(
                entityList,
                comboBox: cb);
        }
        private void cbFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedFaculty = (Faculty?)cbFaculty.SelectedItem;
            LoadComboboxData<Department>(cbDepartment);
        }

        private void cbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedDepartment = (Department?)cbDepartment.SelectedItem;
            LoadComboboxData<Direction>(cbDirection);
        }

        private void cbDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedDirection = (Direction?)cbDirection.SelectedItem;
            LoadComboboxData<Group>(cbGroup);
        }

        private void cbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedGroup = (Group?)cbGroup.SelectedItem;
            cbCourse.Items.Clear();
            for (int i = 1;  i <= selectedGroup!.MaxCourse; i++)
            {
                cbCourse.Items.Add(i);
            }
        }

        private void cbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCourse = (int?)cbCourse.SelectedItem;
        }

        private void cbExcellentStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            isExcelent = (bool?)cbExcellentStudent.SelectedItem;
        }
    }
}
