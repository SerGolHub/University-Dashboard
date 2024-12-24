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
		public class StudentViewModel
		{
			public Guid Id { get; set; }
			public string Name { get; set; } = string.Empty;
			public DateTime EnrollmentDate { get; set; }
			public string EnrollmentNumber { get; set; } = string.Empty;
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
			ComboboxHelper.LoadCombobox(
				faculties,
				comboBox: cbFaculty);

		}

		private void ClearTempLists()
		{
			newStudentList.Clear();
			updatedStudentList.Clear();
			removedStudentList.Clear();

		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (tbFullName.Text == string.Empty)
			{
				MessageBox.Show("Введите ФИО студента.");
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

			if (selectedGroup == null)
			{
				MessageBox.Show("Выберите группу");
				return;
			}

			if (selectedCourse == null)
			{
				MessageBox.Show("Выберите курс");
				return;
			}

			if (tbEnrollmentNumber == null)
			{
				MessageBox.Show("Введите номер зачисления");
				return;
			}

			if (tbEnrollmentDate == null)
			{
				MessageBox.Show("Введите дату зачисления");
				return;
			}

			if (isExcelent == null)
			{
				isExcelent = false;
			}

			var newStudent = new StudentViewModel()
			{
				Id = Guid.NewGuid(),
				Name = tbFullName.Text,
				EnrollmentDate = DateTime.ParseExact(tbEnrollmentDate.Text, "dd.mm.yyyy", new System.Globalization.CultureInfo("ru-RU")),
				EnrollmentNumber = tbEnrollmentNumber.Text,
				CourseNumber = (int)selectedCourse,
				GroupId = selectedGroup.Id,
				GroupName = selectedGroup.Name
			};
			
			students.Add(newStudent);
			newStudentList.Add(newStudent);
		}

		private async void btnSave_Click(object sender, EventArgs e)
		{
			lbDbSaveResult.ForeColor = Color.FromArgb(218, 141, 178);
			lbDbSaveResult.Text = "Подождите. Данные сохраняются.";
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
				return;
			}

			var id = (Guid)dgvStudentList.CurrentRow.Cells["Id"].Value;
			StudentViewModel deletedStudent = GetStudent(id);
			students.Remove(deletedStudent);
			newStudentList.Remove(deletedStudent);
			updatedStudentList.Remove(deletedStudent);
			removedStudentList.Add(deletedStudent);

		}

		private StudentViewModel GetStudent(Guid id)
		{
			return students.First(s => s.Id == id);
		}
		private void dgvStudentList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			var editedRow = dgvStudentList.Rows[e.RowIndex];
			var id = (Guid)editedRow.Cells["Id"].Value;
			StudentViewModel updatedStudent = GetStudent(id);
			updatedStudentList.Add(updatedStudent);
		}

		private void dgvStudentList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
			ComboboxHelper.LoadComboboxData<Group>(cbGroup);
		}

		private void cbGroup_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedGroup = (Group?)cbGroup.SelectedItem;
			cbCourse.Items.Clear();
			for (int i = 1; i <= selectedGroup!.MaxCourse; i++)
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
