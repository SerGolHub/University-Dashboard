using Database;
using Microsoft.EntityFrameworkCore;
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
            public required string EnrollmentNumber { get; set; }
            public bool IsExcellentStudent { get; set; }
            public int CourseNumber { get; set; }

            public Guid FacultyId { get; set; }
            public string FacultyName { get; set; } = String.Empty;

            public Guid DepartmentId { get; set; }
            public string DepartmentName { get; set; } = String.Empty;

            public Guid DirectionId { get; set; }
            public string DirectionName { get; set; } = String.Empty;

            public Guid GroupId { get; set; }
            public string GroupName { get; set; } = String.Empty;
        }

        public FrmStudents()
        {
            InitializeComponent();
            LoadData();
        }

        private BindingList<StudentViewModel> students = [];
        private BindingList<StudentViewModel> updatedStudentList = [];
        private BindingList<StudentViewModel> removedStudentList = [];
        private Faculty? selectedFaculty;
        private Department? selectedDepartment;
        private Direction? selectedDirection;
        private int courseNumber;
        private Group? selectedGroup;

        private void LoadData()
        {
            using var ctx = new DatabaseContext();
            StudentController.LoadStudents(dgvStudentList, ref students);
            DataGridViewHelper.HideColumns(dgvStudentList,
                ["Id", "DirectionId", "GroupId", "Marks"]);

            LoadComboboxData(ctx, cbFaculty, s => s.Direction!.Department!.Faculty!);
            LoadComboboxData(ctx, cbDepartment, s => s.Direction!.Department!);
            LoadComboboxData(ctx, cbDirection, s => s.Direction!);

        }

        private void LoadComboboxData<T>(
            DatabaseContext ctx,
            ComboBox cb,
            Func<Student, T> selector) where T : class
        {
            var items = ctx.Student
                .Select(selector)
                .Distinct()
                .ToList();

            if (items == null || items.Count == 0)
            {
                return;
            }

            DataGridViewHelper.LoadCombobox<T>(
                items!,
                comboBox: cb,
                comboBoxDisplayMember: "Name",
                comboBoxValueMember: "Id");
        }
    }
}
