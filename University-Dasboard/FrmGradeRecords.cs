using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScottPlot;

namespace University_Dasboard
{
	public partial class FrmGradeRecords : Form
	{
		public FrmGradeRecords()
		{
			InitializeComponent();
			LoadGradeAnalysis();
		}

		private void LoadGradeAnalysis()
		{
			List<PieSlice> slices = new()
			{
				new PieSlice() { Value = 5, FillColor = Colors.Red, Label = "Red" },
				new PieSlice() { Value = 2, FillColor = Colors.Orange, Label = "Orange" },
				new PieSlice() { Value = 8, FillColor = Colors.Gold, Label = "Yellow" },
				new PieSlice() { Value = 4, FillColor = Colors.Green, Label = "Green" },
				new PieSlice() { Value = 8, FillColor = Colors.Blue, Label = "Blue" },
			};

			var pie = fpGradeAnalysis.Plot.Add.Pie(slices);
			pie.DonutFraction = .5;

			fpGradeAnalysis.Plot.ShowLegend();

			fpGradeAnalysis.Plot.Axes.Frameless();
			fpGradeAnalysis.Plot.HideGrid();

			fpGradeAnalysis.Refresh();
		}
	}
}
