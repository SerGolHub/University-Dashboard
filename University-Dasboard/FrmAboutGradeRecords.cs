
using Database;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore;
using University_Dasboard.Database.Models;
using Group = University_Dasboard.Database.Models.Group;

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

		private Group? selectedGroup;
		private int? selectedCourse;
		private Student? selectedStudent;

		private void ExportToExcelUsingOpenXML(DataGridView dataGridView, string fileName)
		{
			// Создание нового файла Excel
			using (var spreadsheetDocument = SpreadsheetDocument.Create(fileName, DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook))
			{
				// Создание рабочей книги
				WorkbookPart workbookPart = spreadsheetDocument.AddWorkbookPart();
				workbookPart.Workbook = new Workbook();

				// Создание листа в книге
				WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
				worksheetPart.Worksheet = new Worksheet(new SheetData());

				Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild(new Sheets());
				Sheet sheet = new Sheet()
				{
					Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
					SheetId = 1,
					Name = "Report"
				};
				sheets.Append(sheet);

				// Получение данных из DataGridView и запись их в Excel
				SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

				// Добавление заголовков столбцов
				Row headerRow = new Row();
				foreach (DataGridViewColumn column in dataGridView.Columns)
				{
					headerRow.AppendChild(new Cell()
					{
						CellValue = new CellValue(column.HeaderText),
						DataType = CellValues.String
					});
				}
				sheetData.AppendChild(headerRow);

				// Добавление строк данных
				foreach (DataGridViewRow dataGridViewRow in dataGridView.Rows)
				{
					if (!dataGridViewRow.IsNewRow) // Пропускаем последнюю пустую строку
					{
						Row row = new Row();
						foreach (DataGridViewCell cell in dataGridViewRow.Cells)
						{
							row.AppendChild(new Cell()
							{
								CellValue = new CellValue(cell.Value?.ToString()),
								DataType = CellValues.String
							});
						}
						sheetData.AppendChild(row);
					}
				}

				// Сохранение документа
				workbookPart.Workbook.Save();
			}
		}

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
				if (selectedCourse == null)
				{
					MessageBox.Show("Выберите курс");
					return;
				}

				// Находим все группы, которые соответствуют выбранному курсу
				var groupsOnCourse = ctx.Group
					.Where(g => g.CourseNumber == selectedCourse) // Фильтруем группы по курсу
					.Include(g => g.Direction!.Subjects) // Подключаем направление и предметы
					.ToList(); // Получаем группы в память

				if (!groupsOnCourse.Any())
				{
					MessageBox.Show("Нет групп на выбранном курсе");
					return;
				}

				// Получаем студентов, которые принадлежат этим группам
				var studentData = ctx.Student
					.Include(st => st.Marks) // Подключаем оценки
					.Include(st => st.Group!.Direction!.Subjects) // Подключаем предметы направления
					.ToList() // Загружаем всех студентов в память
					.Where(st => groupsOnCourse.Any(g => g.Id == st.GroupId)) // Студенты, которые принадлежат группам на выбранном курсе
					.Select(st => new
					{
						st.Name,
						AverageMark = st.Marks.Any() ? st.Marks.Average(m => m.Mark) : 0,
						ThreeCount = st.Marks.Count(m => m.Mark == 3),
						MarksBySubjectAndSemester = st.Marks
							.GroupBy(m => new
							{
								m.SubjectId,
								Semester = m.Semester.ToString()
							})
							.ToList()
					})
					.ToList(); // Вычисляем данные после загрузки всех студентов в память

				foreach (var student in studentData)
				{
					var row = new List<object>
					{
						student.Name,
						student.AverageMark,
						student.ThreeCount
					};

					// Добавляем оценки по предметам, которые есть в выбранных группах (направлениях)
					foreach (var subject in groupsOnCourse.First().Direction!.Subjects) // Извлекаем предметы из первого направления
					{
						foreach (var semester in subject.Semester.Split(' ').Select(int.Parse).OrderBy(sem => sem).Distinct())
						{
							// Ищем оценки для каждого предмета и семестра
							var markForSubjectSemester = student.MarksBySubjectAndSemester
								.FirstOrDefault(group => group.Key.SubjectId == subject.Id && group.Key.Semester == semester.ToString());

							row.Add(markForSubjectSemester?.Average(m => m.Mark));
						}
					}

					dgvReportList.Rows.Add(row.ToArray());
				}
			}
			else if (chbStudent.Checked)
			{
				if (selectedStudent == null)
				{
					MessageBox.Show("Выберите студента");
					return;
				}
				var studentData = ctx.Student
					.Where(st => st.Id == selectedStudent.Id)
					.Include(st => st.Marks)
					.Include(st => st.Group!.Direction!.Subjects)
					.ToList()
					.Select(st => new
					{
						st.Name,
						AverageMark = st.Marks.Any() ? st.Marks.Average(m => m.Mark) : 0,
						ThreeCount = st.Marks.Count(m => m.Mark == 3),
						MarksBySubjectAndSemester = st.Marks
							.GroupBy(m => new
							{
								m.SubjectId,
								Semester = m.Semester.ToString()
							})
							.ToList()
					})
					.FirstOrDefault();

				if (studentData != null)
				{
					var row = new List<object>
					{
						studentData.Name,
						studentData.AverageMark,
						studentData.ThreeCount
					};

					foreach (var subject in selectedStudent.Group!.Direction!.Subjects)
					{
						foreach (var semester in subject.Semester.Split(' ').Select(int.Parse).OrderBy(sem => sem).Distinct())
						{
							var markForSubjectSemester = studentData.MarksBySubjectAndSemester
								.FirstOrDefault(group => group.Key.SubjectId == subject.Id && group.Key.Semester == semester.ToString());

							row.Add(markForSubjectSemester?.Average(m => m.Mark));
						}
					}

					dgvReportList.Rows.Add(row.ToArray());
				}
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
			if (selectedStudent == null)
			{
				return;
			}
			using var ctx = new DatabaseContext();
			selectedStudent = ctx.Student
						   .Include(s => s.Group!.Direction!.Subjects)
						   .FirstOrDefault(s => s.Id == selectedStudent.Id);
		}

		private void dgvStudentList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			Drawer.DrawNumbers(sender, e);
		}

		private void btnExportToExcel_Click(object sender, EventArgs e)
		{
			btnGenerate_Click(sender, e);
			string filePath = @"..\..\..\..\";
			string fileName = "!Report.xlsx";
			string fullFilePath = filePath + fileName;
			// Экспортируем данные в Excel
			ExportToExcelUsingOpenXML(dgvReportList, fullFilePath);
			MessageBox.Show($"Файл {fileName} сохранен!");

		}
	}
}
