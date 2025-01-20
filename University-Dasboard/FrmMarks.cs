using Database;
using System.ComponentModel;
using University_Dasboard.Controllers;
using University_Dasboard.Database.Models;

namespace University_Dasboard
{
	public partial class FrmMarks : Form
	{
		public FrmMarks()
		{
			InitializeComponent();
			LoadData();
		}

		public class MarksViewModel
		{
			public Guid Id { get; set; }
			public int Mark { get; set; }
			public DateTime GradeDate { get; set; }
			public required string MarkType { get; set; }
			public int Semester { get; set; }

			public Guid StudentId { get; set; }
			public string StudentName { get; set; } = string.Empty;

			public Guid SubjectId { get; set; }
			public string SubjectName { get; set; } = string.Empty;
		}

		private BindingList<MarksViewModel> marks = [];
		private List<MarksViewModel> newMarksList = [];
		private List<MarksViewModel> updatedMarksList = [];
		private List<MarksViewModel> removedMarksList = [];
		private Faculty? selectedFaculty;
		private Department? selectedDepartment;
		private Direction? selectedDirection;
		private int? selectedSemester;
		private Group? selectedGroup;
		private Subject? selectedSubject;
		private Student? selectedStudent;
		private string studentMark = string.Empty;
		private DateTime selectedDateTime;
		private string? selectedMarkType = string.Empty;

		private void LoadData()
		{
			using var ctx = new DatabaseContext();
			MarksController.LoadMarks(dgvMarksList, ref marks);
			DataGridViewHelper.HideColumns(dgvMarksList,
				["Id", "StudentId", "SubjectId"]);
			var faculties = ctx.Faculty.ToList();
			ComboboxHelper.LoadCombobox(
				faculties,
				comboBox: cbFaculty);
		}

		private void ClearTempLists()
		{
			newMarksList.Clear();
			updatedMarksList.Clear();
			removedMarksList.Clear();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
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
			if (selectedSemester == null)
			{
				MessageBox.Show("Выберите семестр");
				return;
			}
			if (selectedGroup == null)
			{
				MessageBox.Show("Выберите группу");
				return;
			}
			if (selectedSubject == null)
			{
				MessageBox.Show("Выберите предмет");
				return;
			}
			if (selectedStudent == null)
			{
				MessageBox.Show("Выберите студента");
				return;
			}
			if (tbMark.Text == string.Empty)
			{
				MessageBox.Show("Введите оценку студента за предмет");
				return;
			}
			if (selectedMarkType == null)
			{
				MessageBox.Show("Выберите тип оценки");
				return;
			}
			var newMark = new MarksViewModel()
			{
				Id = Guid.NewGuid(),
				Mark = Convert.ToInt32(tbMark.Text),
				GradeDate = dateTimePicker1.Value.ToUniversalTime().Date,
				MarkType = selectedMarkType,
				Semester = (int)selectedSemester,
				StudentId = selectedStudent.Id,
				StudentName = selectedStudent.Name,
				SubjectId = selectedSubject.Id,
				SubjectName = selectedSubject.Name
			};
			marks.Add(newMark);
			newMarksList.Add(newMark);
		}

		private async void btnSave_Click(object sender, EventArgs e)
		{
			lbDbSaveResult.ForeColor = Color.FromArgb(218, 141, 178);
			lbDbSaveResult.Text = "Подождите. Данные сохраняются.";
			lbDbSaveResult.Visible = true;
			try
			{
				await MarksController.SaveMarksAsync(
				newMarksList,
				updatedMarksList,
				removedMarksList);

				ClearTempLists();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
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

		private MarksViewModel GetMark(Guid id)
		{
			return marks.First(m => m.Id == id);
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (dgvMarksList.CurrentRow == null)
			{
				MessageBox.Show("Выделите строку для удаления");
				return;
			}
			var id = (Guid)dgvMarksList.CurrentRow.Cells["Id"].Value;
			MarksViewModel deletedMark = GetMark(id);
			marks.Remove(deletedMark);
			newMarksList.Remove(deletedMark);
			updatedMarksList.Remove(deletedMark);
			removedMarksList.Add(deletedMark);
		}

		private void dgvMarksList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0 || e.ColumnIndex < 0)
			{
				return;
			}
			var editedRow = dgvMarksList.Rows[e.RowIndex];
			var id = (Guid)editedRow.Cells["Id"].Value;
			MarksViewModel updatedMark = GetMark(id);
			updatedMarksList.Add(updatedMark);
		}

		private void dgvMarksList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			Drawer.DrawNumbers(sender, e);
		}

		private void btnShow_Click(object sender, EventArgs e)
		{
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
			if (selectedSemester == null)
			{
				MessageBox.Show("Выберите семестр");
				return;
			}
			if (selectedGroup == null)
			{
				MessageBox.Show("Выберите группу");
				return;
			}
			if (selectedSubject == null)
			{
				MessageBox.Show("Выберите предмет");
				return;
			}

			DateTime? date = dateTimePicker1.Checked ? dateTimePicker1.Value.Date : null;
			using var ctx = new DatabaseContext();
			List<MarksViewModel> marksList;
			if (date != null)
			{
				int year = date.Value.Year;
				int month = date.Value.Month;

				marksList = ctx.Marks
				.Where(m => m.SubjectId == selectedSubject.Id)
				.Where(m => m.Student!.Group!.Id == selectedGroup.Id)
				.Where(m => m.GradeDate.Year == year && m.GradeDate.Month == month)
				.Select(m => new MarksViewModel
				{
					Id = m.Id,
					Mark = m.Mark,
					GradeDate = m.GradeDate,
					MarkType = m.markType,
					Semester = m.Semester,
					StudentId = m.StudentId,
					StudentName = m.Student!.Name,
					SubjectId = m.SubjectId,
					SubjectName = m.Subject!.Name
				})
				.ToList();
			}
			else
			{
				marksList = ctx.Marks
				.Where(m => m.SubjectId == selectedSubject.Id)
				.Where(m => m.Student!.Group!.Id == selectedGroup.Id)
				.Select(m => new MarksViewModel
				{
					Id = m.Id,
					Mark = m.Mark,
					GradeDate = m.GradeDate,
					MarkType = m.markType,
					Semester = m.Semester,
					StudentId = m.StudentId,
					StudentName = m.Student!.Name,
					SubjectId = m.SubjectId,
					SubjectName = m.Subject!.Name
				})
				.ToList();
			}
			marks = new BindingList<MarksViewModel>(marksList);
			dgvMarksList.DataSource = marks;
			ClearTempLists();
		}

		private void cbFaculty_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedFaculty = (Faculty?)cbFaculty.SelectedItem;
			if (selectedFaculty != null)
			{
				bool areDepartmentsLoaded = ComboboxHelper.LoadFacultyDepartments(
					cbDepartment,
					cbDirection,
					selectedFaculty.Id,
					selectedDepartment,
					selectedDirection);
				if (!areDepartmentsLoaded)
				{
					ComboboxHelper.ClearComboboxes(
					cbDepartment,
					cbDirection,
					cbGroup,
					cbSemester,
					cbSubject,
					cbStudent);
					selectedDepartment = null;
					selectedDirection = null;
					selectedGroup = null;
					selectedSemester = null;
					selectedSubject = null;
					selectedStudent = null;
				}
			}
		}

		private void cbDepartment_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedDepartment = (Department?)cbDepartment.SelectedItem;
			if (selectedDepartment != null)
			{
				bool areDirectionsLoaded = ComboboxHelper.LoadDepartmentDirections(
					cbDirection,
					selectedDepartment.Id,
					selectedDirection,
					selectedGroup,
					cbGroup);

				bool areSubjectsLoaded = ComboboxHelper.LoadDepartmentSubjects(
					cbSubject,
					selectedDepartment.Id,
					selectedSubject);

				if (!areDirectionsLoaded)
				{
					ComboboxHelper.ClearComboboxes(
					cbDirection,
					cbGroup,
					cbSemester,
					cbStudent);
					selectedDirection = null;
					selectedGroup = null;
					selectedSemester = null;
					selectedStudent = null;
				}
			}
		}

		private void cbDirection_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedDirection = (Direction?)cbDirection.SelectedItem;
			if (selectedDirection != null)
			{
				bool areSubjectsLoaded = ComboboxHelper.LoadDepartmentSubjects(
					cbSubject,
					selectedDepartment!.Id,
					selectedSubject);

				bool areGroupsLoaded = ComboboxHelper.LoadComboboxData<Group>(
				cbGroup,
				g => g.DirectionId == selectedDirection.Id);
				if (!areGroupsLoaded)
				{
					ComboboxHelper.ClearComboboxes(
					cbGroup,
					cbSemester,
					cbSubject,
					cbStudent);
					selectedGroup = null;
					selectedSemester = null;
					selectedSubject = null;
					selectedStudent = null;
				}
			}
		}

		private void cbGroup_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedGroup = (Group?)cbGroup.SelectedItem;
			if (selectedGroup != null)
			{
				bool areStudentsLoaded = ComboboxHelper.LoadComboboxData<Student>(
				cbStudent,
				st => st.GroupId == selectedGroup.Id);
				if (!areStudentsLoaded)
				{
					ComboboxHelper.ClearComboboxes(cbStudent);
					selectedStudent = null;
				}
			}
		}

		private void cbCourse_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedSemester = (int?)cbSemester.SelectedItem;
		}

		private void cbSubject_SelectedIndexChanged(object sender, EventArgs e)
		{
            selectedSubject = (Subject?)cbSubject.SelectedItem;
			if (selectedSubject != null)
			{
				cbSemester.Items.Clear();
				cbSemester.Text = "";
				selectedSemester = null;
				using var ctx = new DatabaseContext();
				var semesters = ctx.Subject
					.Where(s => s.Id == selectedSubject.Id)
					.Select(s => s.Semester)
					.AsEnumerable() // Переключаемся на выполнение в памяти
					.SelectMany(item => item.Split()) // Разделяем строки на числа
					.Distinct()
					.Select(int.Parse) // Преобразуем строки в числа
					.ToList();

				foreach (var semester in semesters)
				{
					cbSemester.Items.Add(semester);
				}
			}
		}

		private void cbStudent_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedStudent = (Student?)cbStudent.SelectedItem;
		}

		private void tbMark_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private void cbMarkType_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedMarkType = (string?)cbMarkType.SelectedItem;
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked)
			{
				label7.Visible = true;
				cbStudent.Visible = true;
				label8.Visible = true;
				tbMark.Visible = true;
				label11.Visible = true;
				cbMarkType.Visible = true;
				btnAdd.Visible = true;
			}
			else
			{
				label7.Visible = false;
				cbStudent.Visible = false;
				label8.Visible = false;
				tbMark.Visible = false;
				label11.Visible = false;
				cbMarkType.Visible = false;
				btnAdd.Visible = false;
			}
		}
	}
}
