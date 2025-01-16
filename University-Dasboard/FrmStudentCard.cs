using Database;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.EntityFrameworkCore;
using System.Data;
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

		public static void CreateWordDocument(
			string filePath,
			string fullName,
			string course,
			string group,
			string directionCode,
			string directionName,
			bool isExcellent,
			DataGridView dataGridView)
		{
			// Создание нового Word документа
			using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(filePath, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
			{
				// Создание главного содержимого документа
				MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
				mainPart.Document = new Document(new Body());

				Body body = mainPart.Document.Body;

				// Добавление строк
				string isExcellentToString = isExcellent ? "Да" : "Нет";
				body.AppendChild(new Paragraph(new Run(new Text($"ФИО: {fullName}"))));
				body.AppendChild(new Paragraph(new Run(new Text($"Курс: {course}"))));
				body.AppendChild(new Paragraph(new Run(new Text($"Группа: {group}"))));
				body.AppendChild(new Paragraph(new Run(new Text($"Направление: {directionCode}, {directionName}"))));
				body.AppendChild(new Paragraph(new Run(new Text($"Отличник: {isExcellentToString}"))));

				// Добавление таблицы из DataGridView
				body.AppendChild(CreateTableFromDataGridView(dataGridView));
			}
		}

		// Метод для создания таблицы из DataGridView
		private static Table CreateTableFromDataGridView(DataGridView dataGridView)
		{
			Table table = new Table();

			// Свойства таблицы: установка границы
			TableProperties tableProperties = new TableProperties(
				new TableBorders(
					new TopBorder { Val = BorderValues.Single, Size = 4, Space = 0 },
					new BottomBorder { Val = BorderValues.Single, Size = 4, Space = 0 },
					new LeftBorder { Val = BorderValues.Single, Size = 4, Space = 0 },
					new RightBorder { Val = BorderValues.Single, Size = 4, Space = 0 },
					new InsideHorizontalBorder { Val = BorderValues.Single, Size = 4, Space = 0 },
					new InsideVerticalBorder { Val = BorderValues.Single, Size = 4, Space = 0 }
				)
			);
			table.AppendChild(tableProperties);

			// Добавление заголовков
			TableRow headerRow = new TableRow();
			foreach (DataGridViewColumn column in dataGridView.Columns)
			{
				TableCell headerCell = new TableCell(new Paragraph(new Run(new Text(column.HeaderText))));
				headerCell.AppendChild(new TableCellProperties(
					new TableCellBorders(
						new TopBorder { Val = BorderValues.Single, Size = 4, Space = 0 },
						new BottomBorder { Val = BorderValues.Single, Size = 4, Space = 0 },
						new LeftBorder { Val = BorderValues.Single, Size = 4, Space = 0 },
						new RightBorder { Val = BorderValues.Single, Size = 4, Space = 0 }
					)
				));
				headerRow.AppendChild(headerCell);
			}
			table.AppendChild(headerRow);

			// Добавление данных из строк DataGridView
			foreach (DataGridViewRow row in dataGridView.Rows)
			{
				if (row.IsNewRow) continue;  // Пропустить пустую строку

				TableRow tableRow = new TableRow();
				foreach (DataGridViewCell cell in row.Cells)
				{
					TableCell tableCell = new TableCell(new Paragraph(new Run(new Text(cell.Value?.ToString() ?? ""))));
					tableCell.AppendChild(new TableCellProperties(
						new TableCellBorders(
							new TopBorder { Val = BorderValues.Single, Size = 4, Space = 0 },
							new BottomBorder { Val = BorderValues.Single, Size = 4, Space = 0 },
							new LeftBorder { Val = BorderValues.Single, Size = 4, Space = 0 },
							new RightBorder { Val = BorderValues.Single, Size = 4, Space = 0 }
						)
					));
					tableRow.AppendChild(tableCell);
				}
				table.AppendChild(tableRow);
			}

			return table;
		}

		private void cbStudent_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedStudent = (Student?)cbStudent.SelectedItem;
			if (selectedStudent == null)
			{
				return;
			}
			using var ctx = new DatabaseContext();
			selectedStudent = ctx.Student
				.Include(st => st.Group!.Direction)
				.First(st => st.Id == selectedStudent.Id);
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

		private void btnExportToWord_Click(object sender, EventArgs e)
		{
			if (selectedStudent == null)
			{
				MessageBox.Show("Выберите студента");
				return;
			}
			btnGenerate_Click(sender, e);
			// Создание документа Word
			string filePath = "!Student_card.docx";
			CreateWordDocument(
				filePath,
				selectedStudent.Name,
				selectedStudent.CourseNumber.ToString(),
				selectedStudent.Group!.Name,
				selectedStudent.Group.Direction!.Code,
				selectedStudent.Group.Direction!.Name,
				selectedStudent.IsExcellentStudent,
				dgvStudentInfo);

			MessageBox.Show($"Документ сохранен!\n{filePath}");
		}
	}
}
