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

            LoadComboboxFacultyData(ctx, cbFaculty);
            LoadComboboxDepartmentData(ctx, cbDepartment);

        }

        private void LoadComboboxFacultyData(DatabaseContext ctx, ComboBox cb)
        {
            var faculties = ctx.Student
                .Select(s => s.Direction.Department.Faculty)
                .Distinct() // Уникальные факультеты. У многих студентов может быть один и тот же факультет,
                            // из-за чего в списке могут быть дубликаты, а нам этого не нужно
                .ToList();
            if (faculties?.Count == 0)
            {
                return;
            }

            DataGridViewHelper.LoadCombobox(
                faculties,
                comboBox: cb,
                comboBoxDisplayMember: "Name",
                comboBoxValueMember: "Id");
        }

        private void LoadComboboxDepartmentData(DatabaseContext ctx, ComboBox cb)
        {
            var departments = ctx.Student
                .Select(s => s.Direction.Department)
                .Distinct()
                .ToList();
            DataGridViewHelper.LoadCombobox(
                departments,
                comboBox: cb,
                comboBoxDisplayMember: "Name",
                comboBoxValueMember: "Id");
        }
    }
}
