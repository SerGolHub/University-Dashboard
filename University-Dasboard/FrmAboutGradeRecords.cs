
using Database;
using DocumentFormat.OpenXml.InkML;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using University_Dasboard.Database.Models;

namespace University_Dasboard
{
	public partial class FrmAboutGradeRecords : Form
	{
		public FrmAboutGradeRecords()
		{
			InitializeComponent();
			LoadData();
			InitializeDataGridView();
		}

		//private string templateName = "DocTemplate.doc";
		//private string newName = "DocTemplate-New.doc";
		private Group? selectedGroup;
		private int? selectedCourse;
		private Student? selectedStudent;

		private void InitializeDataGridView()
		{
			dgvReportList.Columns.Add("Name", "ФИО студента");
			dgvReportList.Columns.Add("AverageMark", "Средний балл");
			dgvReportList.Columns.Add("ThreeCount", "Количество троек");

			if (selectedStudent != null)
			{
				// Получаем список всех предметов с их семестрами
				var subjects = selectedGroup!.Direction!.Subjects
					.Select(s => new
					{
						s.Id,
						s.Name,
						Semesters = s.Semester.Split(' ').Select(int.Parse).OrderBy(sem => sem).Distinct()
					})
					.OrderBy(s => string.Join(" ", s.Semesters)) // Сортируем предметы по их семестрам
					.ToList();

				// Создаем столбцы для каждого предмета и семестра
				foreach (var subject in subjects)
				{
					foreach (var semester in subject.Semesters)
					{
						dgvReportList.Columns.Add($"{subject.Id}_{semester}", $"{subject.Name} ({semester} сем.)");
					}
				}

				dgvReportList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
				dgvReportList.AllowUserToAddRows = false;
			}
		}

		private void LoadData()
		{
			using var ctx = new DatabaseContext();

			var groups = ctx.Group.ToList();
			if (groups.Count < 1)
			{
				return;
			}
			ComboboxHelper.LoadCombobox(
				groups,
				comboBox: cbGroup);

			var maxCourse = ctx.Group
				.Select(g => g.Direction!.MaxCourse)
				.Max();
			for (int i = 1; i <= maxCourse; i++)
			{
				cbCourse.Items.Add(i);
			}

			var students = ctx.Student.ToList();
			ComboboxHelper.LoadCombobox(
				students,
				comboBox: cbStudent);
		}
		private void HideComboboxes()
		{
			cbGroup.Visible = false;
			cbCourse.Visible = false;
			cbStudent.Visible = false;
		}

		private void ClearSelection()
		{
			selectedGroup = null;
			cbGroup.Text = string.Empty;

			selectedCourse = null;
			cbCourse.Text = string.Empty;

			selectedStudent = null;
			cbStudent.Text = string.Empty;
		}

		private void btnGenerate_Click(object sender, EventArgs e)
		{
			dgvReportList.Rows.Clear();
			using var ctx = new DatabaseContext();
			if (chbGroup.Checked)
			{
				if (selectedGroup == null)
				{
					MessageBox.Show("Выберите группу");
					return;
				}

				var studentData = ctx.Student
					.Where(st => st.GroupId == selectedGroup.Id)
					.Include(st => st.Marks)
					.Include(st => st.Group!.Direction!.Subjects)
					.ToList() // Получаем данные в память
					.Select(st => new
					{
						st.Name,
						AverageMark = st.Marks.Any() ? st.Marks.Average(m => m.Mark) : 0,
						ThreeCount = st.Marks.Count(m => m.Mark == 3),
						// Группировка после загрузки данных в память
						MarksBySubjectAndSemester = st.Marks
							.GroupBy(m => new 
							{
								m.SubjectId,
								Semester = m.Semester.ToString()
							})
							.ToList()
					})
					.ToList();

				foreach (var student in studentData)
				{
					var row = new List<object>
					{
						student.Name,
						student.AverageMark,
						student.ThreeCount
					};

					// Для каждого предмета и семестра добавляем оценки
					foreach (var subject in selectedGroup.Direction!.Subjects)
					{
						foreach (var semester in subject.Semester.Split(' ').Select(int.Parse).OrderBy(sem => sem).Distinct())
						{
							// Ищем оценки для данного предмета и семестра среди уже сгруппированных данных
							var markForSubjectSemester = student.MarksBySubjectAndSemester
								.FirstOrDefault(group => group.Key.SubjectId == subject.Id && group.Key.Semester == semester.ToString());

							// Если есть оценки для предмета в данном семестре, добавляем среднее значение, иначе null
							row.Add(markForSubjectSemester?.Average(m => m.Mark));
						}
					}

					dgvReportList.Rows.Add(row.ToArray());

				}
			}
			else if (chbCourse.Checked)
			{

			}
			else if (chbStudent.Checked)
			{

			}
			else
			{
				MessageBox.Show("Выберите один из пунктов");
			}
		}

		private void chbGroup_CheckedChanged(object sender, EventArgs e)
		{
			if (chbGroup.Checked)
			{
				chbCourse.Checked = false;
				chbStudent.Checked = false;

				HideComboboxes();
				cbGroup.Visible = true;

				ClearSelection();
			}
		}

		private void chbCourse_CheckedChanged(object sender, EventArgs e)
		{
			if (chbCourse.Checked)
			{
				chbGroup.Checked = false;
				chbStudent.Checked = false;

				HideComboboxes();
				cbCourse.Visible = true;

				ClearSelection();
			}
		}

		private void chbStudent_CheckedChanged(object sender, EventArgs e)
		{
			if (chbStudent.Checked)
			{
				chbGroup.Checked = false;
				chbCourse.Checked = false;

				HideComboboxes();
				cbStudent.Visible = true;

				ClearSelection();
			}
		}

		private void cbGroup_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedGroup = (Group?)cbGroup.SelectedItem;
			if (selectedGroup == null)
			{
				return;
			}
			using var ctx = new DatabaseContext();
			selectedGroup = ctx.Group
						   .Include(g => g.Direction!.Subjects)
						   .FirstOrDefault(g => g.Id == selectedGroup.Id);
		}

		private void cbCourse_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedCourse = (int?)cbCourse.SelectedItem;
		}

		private void cbStudent_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedStudent = (Student?)cbStudent.SelectedItem;
		}

		private void dgvStudentList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			Drawer.DrawNumbers(sender, e);
		}
	}
}
