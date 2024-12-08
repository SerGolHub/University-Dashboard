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

            DataGridViewHelper.LoadComboboxWithSelector(ctx, cbFaculty, s => s.Direction!.Department!.Faculty!);
            DataGridViewHelper.LoadComboboxWithSelector(ctx, cbDepartment, s => s.Direction!.Department!);
            DataGridViewHelper.LoadComboboxWithSelector(ctx, cbDirection, s => s.Direction!);
            DataGridViewHelper.LoadComboboxWithSelector(ctx, cbGroup, s => s.Group!);

        }

        
    }
}
