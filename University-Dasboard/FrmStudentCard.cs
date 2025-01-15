using Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using University_Dasboard.Database.Models;

namespace University_Dasboard
{
	public partial class FrmStudentCard : Form
	{
		public FrmStudentCard()
		{
			InitializeComponent();
			LoadData();
			InitializeDataGridView();
		}

		private Student? selectedStudent;

		private void LoadData()
		{
			using var ctx = new DatabaseContext();

			var students = ctx.Student.ToList();
			ComboboxHelper.LoadCombobox(
				students,
				comboBox: cbStudent);
		}
		private void InitializeDataGridView()
		{
			dgvStudentInfo.Columns.Clear();

			dgvStudentInfo.Columns.Add("Semester", "Семестр");
			dgvStudentInfo.Columns.Add("SubjectName", "Название предмета");
			dgvStudentInfo.Columns.Add("Mark", "Оценка");
			dgvStudentInfo.Columns.Add("Date", "Дата");

			dgvStudentInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgvStudentInfo.AllowUserToAddRows = false;
		}

		public class SubjectGrade
		{
			public Guid Id { get; set; }
			public int Course { get; set; }
			public int Semester { get; set; }
			public string SubjectName { get; set; } = string.Empty;
			public int Mark { get; set; }
			public DateTime Date { get; set; }
		}

		private void cbStudent_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedStudent = (Student?)cbStudent.SelectedItem;
		}

		private void dgvStudentInfo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			Drawer.DrawNumbers(sender, e);
		}

		private void btnGenerate_Click(object sender, EventArgs e)
		{
			if (selectedStudent == null)
			{
				return;
			}

			dgvStudentInfo.Rows.Clear();
			using var ctx = new DatabaseContext();
			
			var studentMarks = ctx.Marks
				.Where(m => m.StudentId == selectedStudent.Id)
				.Select(m => new
				{
					m.Mark,
					m.GradeDate,
					m.Subject!.Name,
					m.Semester
				})
				.OrderBy(m => m.Semester) // Сортировка по семестрам
				.ToList();

			foreach (var item in studentMarks)
			{
				dgvStudentInfo.Rows.Add(item.Semester, item.Name, item.Mark, item.GradeDate);
			}
		}
	}
}
