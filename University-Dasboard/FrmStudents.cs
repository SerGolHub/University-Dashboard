using Database;
using System.ComponentModel;
using System.Globalization;
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

			public Guid GroupId { get; set; }
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
		private Group? selectedGroup;
		private bool? isExcelent;
		private bool canSaveChanges = true;

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
		public bool CanSaveChanges(bool value)
		{
			if (value)
			{
				canSaveChanges = true;
				lbDbSaveResult.Visible = false;
			}
			else
			{
				canSaveChanges = false;
				lbDbSaveResult.Text = "Невозможно сохранить изменения";
				lbDbSaveResult.ForeColor = Color.FromArgb(218, 141, 178);
				lbDbSaveResult.Visible = true;
			}
			return canSaveChanges;
		}

		private bool IsValidEnrollmentNumber(string number)
		{
			// Регулярное выражение для формата "xxxx", где x — цифра
			string pattern = @"^\d{4}$";
			return System.Text.RegularExpressions.Regex.IsMatch(number, pattern);
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

			if (tbEnrollmentNumber.Text == string.Empty)
			{
				MessageBox.Show("Введите номер зачисления");
				return;
			}

			if (!IsValidEnrollmentNumber(tbEnrollmentNumber.Text))
			{
				MessageBox.Show("Введите номер зачисления в формате xxxx, где x - цифра");
				return;
			}


			var newStudent = new StudentViewModel()
			{
				Id = Guid.NewGuid(),
				Name = tbFullName.Text,
				EnrollmentDate = new DateTime(dateTimePicker1.Value.Year,
				dateTimePicker1.Value.Month,
				dateTimePicker1.Value.Day,
				0, 0, 0,
				DateTimeKind.Utc),
				EnrollmentNumber = tbEnrollmentNumber.Text,
				GroupId = selectedGroup.Id,
			};

			students.Add(newStudent);
			newStudentList.Add(newStudent);
		}

		private async void btnSave_Click(object sender, EventArgs e)
		{
			if (!CanSaveChanges(canSaveChanges))
			{
				return;
			}

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
			CanSaveChanges(true);
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
			if (e.RowIndex < 0 || e.ColumnIndex < 0)
			{
				return;
			}
			var editedRow = dgvStudentList.Rows[e.RowIndex];
			string columnName = dgvStudentList.Columns[e.ColumnIndex].Name;
			var cell = editedRow.Cells[e.ColumnIndex];
			if (columnName == "EnrollmentDate")
			{
				string inputtedDate = (string)editedRow.Cells["EnrollmentDate"].Value;
				// Попытка разобрать строку в формате "dd.MM.yyyy"
				bool isValidDate = DateTime.TryParseExact(inputtedDate,
													   "dd.MM.yyyy",
													   CultureInfo.InvariantCulture,
													   DateTimeStyles.None,
													   out DateTime result);
				if (!isValidDate)
				{
					MessageBox.Show("Введена некорректная дата. Введите дату в формате: дд.мм.гггг");
					CanSaveChanges(false);
					cell.Style.BackColor = Color.FromArgb(218, 141, 178);
					return;
				}
			}
			if (columnName == "EnrollmentNumber")
			{
				string inputtedEnrollmentNumber = (string)editedRow.Cells["EnrollmentNumber"].Value;
				if (!IsValidEnrollmentNumber(inputtedEnrollmentNumber))
				{
					MessageBox.Show("Введите номер зачисления в формате xxxx, где x - цифра");
					CanSaveChanges(false);
					cell.Style.BackColor = Color.FromArgb(218, 141, 178);
					return;
				}
			}
			cell.Style.BackColor = Color.White;
			CanSaveChanges(true);
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
			if (selectedDirection != null)
			{
				bool areGroupsLoaded = ComboboxHelper.LoadComboboxData<Group>(
				cbGroup,
				g => g.DirectionId == selectedDirection.Id);

				if (areGroupsLoaded)
				{
					using var ctx = new DatabaseContext();
					var maxCourse = ctx.Direction
						.Where(dir => dir.Id == selectedDirection.Id)
						.Select(dir => dir.MaxCourse)
						.First();
					List<int> coursesList = [];
					for (int i = 1; i <= maxCourse; i++)
					{
						coursesList.Add(i);
					}
				}
			}
		}

		private void cbGroup_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedGroup = (Group?)cbGroup.SelectedItem;
		}

		private void dgvStudentList_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			DataGridViewHelper.ExpandComboBoxOnEdit(dgvStudentList, e);
		}

		private void dgvStudentList_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			var editedRow = dgvStudentList.Rows[e.RowIndex];
			string columnName = dgvStudentList.Columns[e.ColumnIndex].Name;
			var cell = editedRow.Cells[e.ColumnIndex];

			if (columnName == "EnrollmentDate")
			{
				MessageBox.Show("Введите дату в формате дд.мм.гггг");
				return;
			}
		}
	}
}
