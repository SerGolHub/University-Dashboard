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
using Microsoft.EntityFrameworkCore;
using University_Dasboard.Controllers;
using University_Dasboard.Database.Models;
using NLog;
using University_Dasboard.Reports.Models;
using University_Dasboard.Reports;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using DocumentFormat.OpenXml.Bibliography;
using OfficePackage.HelperModels;
using OfficePackage.Implements;

namespace University_Dasboard
{
	public partial class FrmSchedulingDisciplineReport : Form
	{
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();

		public FrmSchedulingDisciplineReport()
		{
			InitializeComponent();
			LoadData();
		}

        public class ScheduleDisciplineViewModel
        {
            public Guid Id { get; set; }

            public Guid SubjectId { get; set; }
            public string SubjectName { get; set; } = string.Empty;

            public Guid FacultyId { get; set; }
            public string FacultyName { get; set; } = string.Empty;

            public Guid DirectionId { get; set; }
            public string DirectionName { get; set; } = string.Empty;

            public Guid GroupId { get; set; }
            public string GroupName { get; set; } = string.Empty;

            public Guid ScheduleWeekId { get; set; }
            public string ScheduleWeek { get; set; } = string.Empty;
            public int LectureHours { get; set; }
            public int PracticalHours { get; set; }
            public int LaboratoryHours { get; set; }
        }

        private BindingList<ScheduleDisciplineViewModel> schedules = new();
		private List<ScheduleDisciplineViewModel> newScheduleList = [];
		private List<ScheduleDisciplineViewModel> updatedScheduleList = [];
		private List<ScheduleDisciplineViewModel> removedScheduleList = [];

		private Subject? selectedSubject;
		private Faculty? selectedFaculty;
		private Direction? selectedDirection;
		private Group? selectedGroup;
		private ScheduleWeek? selectedScheduleWeek;
		private Teacher? selectedTeacher;
		private Group? selectedGroupMerge;


        private void LoadData()
		{
			using var ctx = new DatabaseContext();

			LoadComboboxData(ctx);

			logger.Info("Данные расписания успешно загружены");
		}

		private void LoadComboboxData(DatabaseContext ctx)
		{
			// Загрузка факультетов
           
			var teachers = ctx.Teacher.ToList();
            ComboboxHelper.LoadCombobox(
             teachers,
             comboBox: comboBoxTeacher);
        }

        private void cbTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTeacher = (Teacher?)comboBoxTeacher.SelectedItem;
        }


        private void GenerateReportPdf(object sender, EventArgs e)
        {
            if (selectedTeacher == null)
            {
                MessageBox.Show("Выберите преподавателя");
                return;
            }

            try
            {
                

                // Генерация отчёта для каждого расписания
                var reportGenerator = new SaveToPdf();

                    // Создание информации для отчёта
                    var pdfInfo = new PdfInfo
                    {
                        DateCreate = DateTime.Now,
                        DateReport = DateTime.Now,
                        SemesterName = "1 семестр",
                        TeacherName = selectedTeacher?.Name ?? "Не выбран преподаватель",
                        FileName = GetPdfFileName()
                    };

                    // Генерация отчёта для текущего расписания
                    reportGenerator.CreateCheckLesson(pdfInfo);

                // Сообщение об успешной генерации отчётов
                MessageBox.Show("Отчёты по всем расписаниям успешно созданы!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка генерации отчётов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Метод для получения имени файла через диалоговое окно
        private string GetPdfFileName()
        {
            using (var dialog = new SaveFileDialog { Filter = "PDF|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.FileName;
                }
            }

            return string.Empty;
        }
    }
}
