using Database;
using System.ComponentModel;
using University_Dasboard.Database.Models;

namespace University_Dasboard
{
    public partial class FrmStudents : Form
    {
        public FrmStudents()
        {
            InitializeComponent();
            LoadData();
        }

        private BindingList<Student> students = [];
        private BindingList<Student> updatedStudentList = [];
        private BindingList<Department> removedStudentList = [];

        private void LoadData()
        {
            using var ctx = new DatabaseContext();
            var studentList = ctx.Student.ToList();
            students = new BindingList<Student>(studentList);
            dgvStudentList.DataSource = students;
            try
            {
                dgvStudentList.Columns["Id"].Visible = false;
                dgvStudentList.Columns["FacultyId"].Visible = false;
                dgvStudentList.Columns["GroupId"].Visible = false;
                dgvStudentList.Columns["DirectionId"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
