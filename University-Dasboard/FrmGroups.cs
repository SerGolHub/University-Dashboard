using Database;
using System.ComponentModel;
using University_Dasboard.Controllers;
using University_Dasboard.Database.Models;

namespace University_Dasboard
{
    public partial class FrmGroups : Form
    {
        public FrmGroups()
        {
            InitializeComponent();
        }

        public class GroupViewModel
        {
            public Guid Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public int MaxCourse { get; set; }

            public Guid DirectionId { get; set; }
            public string DirectionName { get; set; } = string.Empty;
        }

        private BindingList<GroupViewModel> groups = [];
        private List<GroupViewModel> newGroupList = [];
        private List<GroupViewModel> updatedGroupList = [];
        private List<GroupViewModel> removedGroupList = [];
        private Faculty? selectedFaculty;
        private Department? selectedDepartment;
        private Direction? selectedDirection;
        private int? maxCourse;

        private void LoadData()
        {
            using var ctx = new DatabaseContext();
            GroupController.LoadGroups(dgvGroupList, ref groups);
            DataGridViewHelper.HideColumns(dgvGroupList,
                ["Id", "DirectionId", "Direction"]);
            var faculties = ctx.Faculty.ToList();
            DataGridViewHelper.LoadCombobox(
                faculties,
                comboBox: cbFaculty);
        }

        private void ClearTempLists()
        {
            newGroupList.Clear();
            updatedGroupList.Clear();
            removedGroupList.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
