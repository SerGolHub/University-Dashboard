using Database;
using Microsoft.EntityFrameworkCore;
using NLog;
using System.Collections.Generic;
using System.ComponentModel;
using University_Dasboard.Controllers;
using University_Dasboard.Database.Models;

namespace University_Dasboard
{
    public partial class FrmTeachers : Form
    {
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();

		// Вспомогательные ViewModel для отображения данных
		public class TeacherViewModel
		{
			public Guid Id { get; set; }

			public string Name { get; set; } = string.Empty;

			public string PhoneNumber { get; set; } = string.Empty;

			public string Email { get; set; } = string.Empty;

			public DateTime HireDate { get; set; }

			public string Degree { get; set; } = string.Empty;

			public string Status { get; set; } = string.Empty;

			public Guid DepartmentId { get; set; }

			public string DepartmentName { get; set; } = string.Empty;

			public List<TeacherConstraintViewModel> Constraints { get; set; } = new();
		}

		public class TeacherConstraintViewModel
		{
			public Guid Id { get; set; }

			public string Note { get; set; } = string.Empty;

			public List<DayConstraintViewModel> DayConstraints { get; set; } = new();
		}

		public class DayConstraintViewModel
		{
			public Guid Id { get; set; }

			public DayOfWeek DayOfWeek { get; set; }
		}

		public FrmTeachers()
        {
            InitializeComponent();
            LoadData();
        }

        private BindingList<TeacherViewModel> teachers = [];
        private List<TeacherViewModel> newTeacherList = [];
        private List<TeacherViewModel> updatedTeacherList = [];
        private List<TeacherViewModel> removedTeavherList = [];
        private Department? selectedDepartment;


        private void LoadData()
        {
            using var ctx = new DatabaseContext();
            TeacherController.LoadTeachers(dgvTeacherList, ref teachers);
    
            var faculties = ctx.Faculty.ToList();
            ComboboxHelper.LoadCombobox(
                faculties,
                comboBox: cbFaculty);

            logger.Info("Список преподавателей успешно загружен.");
        }

        private void ClearTempLists()
        {
            newTeacherList.Clear();
            updatedTeacherList.Clear();
            removedTeavherList.Clear();

            logger.Info("Список преподавателей очищен.");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string fullName = tbFullName.Text;
            if (fullName == string.Empty)
            {
                MessageBox.Show("Введите ФИО Преподавателя.");
                logger.Warn("Пользователь не ввёл ФИО преподавателя.");
                return;
            }


            logger.Info("Преподаватель успешно добавлен в базу данных.");
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            lbDbSaveResult.ForeColor = Color.FromArgb(218, 141, 178);
            lbDbSaveResult.Text = "Подождите. Данные сохраняются.";
            logger.Info("Данные сохраняются....");
            lbDbSaveResult.Visible = true;

            await TeacherController.SaveTeachersAsync(
                newTeacherList,
                updatedTeacherList,
                removedTeavherList);

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
            if (dgvTeacherList.CurrentRow == null)
            {
                MessageBox.Show("Выделите строку для удаления");
				logger.Info("Пользователь не выделил строку для удаления");
				return;
            }

            var id = (Guid)dgvTeacherList.CurrentRow.Cells["Id"].Value;
            TeacherViewModel deletedStudent = GetTeacher(id);
            teachers.Remove(deletedStudent);
            newTeacherList.Remove(deletedStudent);
            updatedTeacherList.Remove(deletedStudent);
            removedTeavherList.Add(deletedStudent);

            logger.Info("Студент удалён из базы данных.");
        }

        private TeacherViewModel GetTeacher(Guid id)
        {
            return teachers.First(s => s.Id == id);
        }

        private void dgvStudentList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var editedRow = dgvTeacherList.Rows[e.RowIndex];
            var id = (Guid)editedRow.Cells["Id"].Value;
            TeacherViewModel updatedStudent= GetTeacher(id);
            updatedTeacherList.Add(updatedStudent);
        }

        private void dgvTeachersList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Drawer.DrawNumbers(sender, e);
        }


        private void cbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
			selectedDepartment = (Department?)cbDepartment.SelectedItem;
			ComboboxHelper.LoadComboboxData<Direction>(
				cbDirection,
				dir => dir.DepartmentId == selectedDepartment!.Id);
		}
    }
}
