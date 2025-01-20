using System.Data;
using Database;
using ScottPlot;
using University_Dasboard.Database.Models;

namespace University_Dasboard
{
	public partial class FrmGradeRecords : Form
	{
		public FrmGradeRecords()
		{
			InitializeComponent();
			LoadData();
		}
		private Faculty? selectedFaculty;

		private void LoadData()
		{
			using var ctx = new DatabaseContext();
			var faculties = ctx.Faculty.ToList();
			ComboboxHelper.LoadCombobox(
				faculties,
				comboBox: cbFaculty);
		}
		private void LoadGradeAnalysis()
		{
			using var ctx = new DatabaseContext();
			if (selectedFaculty == null)
			{
				return;
			}
			MessageBox.Show($"Value: {dtpPeriodFrom.Value}\n" +
				$"Value.Date: {dtpPeriodFrom.Value.Date}");
			var marks = ctx.Marks
				.Where(m => m.GradeDate >= dtpPeriodFrom.Value.ToUniversalTime().Date // условие по дате
				&& m.GradeDate <= dtpPeriodBy.Value.ToUniversalTime().Date // продолжение условия
				&& m.Student!.Group!.Direction!.FacultyId == selectedFaculty.Id) // где объект Оценка имеет id выбранного факультета
				.ToList();

			int mark5 = marks.Count(m => m.Mark == 5);
			int mark4 = marks.Count(m => m.Mark == 4);
			int mark3 = marks.Count(m => m.Mark == 3);
			int mark2 = marks.Count(m => m.Mark == 2);
			int mark1 = marks.Count(m => m.Mark == 1);
			int totalMarks = mark5 + mark4 + mark3 + mark2 + mark1;
			double percent5 = (double)mark5 / totalMarks * 100;
			double percent4 = (double)mark4 / totalMarks * 100;
			double percent3 = (double)mark3 / totalMarks * 100;
			double percent2 = (double)mark2 / totalMarks * 100;
			double percent1 = (double)mark1 / totalMarks * 100;

			// Создание частей круга
			List<PieSlice> slices = new()
			{
				new PieSlice() { Value = mark5, 
					FillColor = Colors.Green, Label = $"5 баллов ({percent5:F2}%)" },
				new PieSlice() { Value = mark4, 
					FillColor = Colors.GreenYellow, Label = $"4 балла ({percent4:F2}%)" },
				new PieSlice() { Value = mark3, 
					FillColor = Colors.Yellow, Label = $"3 балла ({percent3:F2}%)" },
				new PieSlice() { Value = mark2, 
					FillColor = Colors.Red, Label = $"2 балла ({percent2:F2}%)" },
				new PieSlice() { Value = mark1, 
					FillColor = Colors.Red, Label = $"1 балл ({percent1:F2}%)" },
			};

			// Добавление круга с частями на график
			var pie = fpGradeAnalysis.Plot.Add.Pie(slices);
			// Внутренний радиус круга
			pie.DonutFraction = .5;
			// Показываем подпись частей
			fpGradeAnalysis.Plot.ShowLegend();
			// Убираем оси X, Y
			fpGradeAnalysis.Plot.Axes.Frameless();
			// Убираем квадратную разметку
			fpGradeAnalysis.Plot.HideGrid();
			// Обновляем график
			fpGradeAnalysis.Refresh();
		}

		private void cbFaculty_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedFaculty = (Faculty?)cbFaculty.SelectedItem;
		}

		private void btnShow_Click(object sender, EventArgs e)
		{
			fpGradeAnalysis.Reset();
			LoadGradeAnalysis();
		}
	}
}
