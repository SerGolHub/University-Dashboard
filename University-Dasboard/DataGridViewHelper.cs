using Database;

namespace University_Dasboard
{
    public class DataGridViewHelper
    {
        public static void HideColumns(DataGridView dgv, List<string> hiddenColumns)
        {
            foreach (var columnName in hiddenColumns)
            {
                if (dgv.Columns.Contains(columnName))
                {
                    dgv.Columns[columnName].Visible = false;
                }
            }
        }

		public static void ExpandComboBoxOnEdit(DataGridView dgv, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0 || e.ColumnIndex < 0)
			{
				return;
			}
			DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
			if (cell is DataGridViewComboBoxCell)
			{
				dgv.BeginEdit(false);
				((DataGridViewComboBoxEditingControl)dgv.EditingControl).DroppedDown = true;
			}
		}

		// При открытии списка может ненадолго показаться выбранное значение из другого списка.
		// Это визуальный баг. И вполне возможно, что не из-за кода.
		public static void LoadFaculties(DatabaseContext ctx, DataGridView dgv)
		{
			var faculties = ctx.Faculty.ToList();
			var cbColumnFaculty = dgv.Columns["DgvCbFaculty"] as DataGridViewComboBoxColumn;
			if (cbColumnFaculty != null)
			{
				cbColumnFaculty.DataSource = faculties;
				cbColumnFaculty.DisplayMember = "Name"; // Отображаемое значение
				cbColumnFaculty.ValueMember = "Id"; // Связь по идентификатору
				cbColumnFaculty.DataPropertyName = "FacultyId"; // Связь с свойством BindingList
			}
		}

		public static void LoadDepartments(DatabaseContext ctx, DataGridView dgv)
		{
			var departments = ctx.Department.ToList();
			var cbColumnDepartment = dgv.Columns["DgvCbDepartment"] as DataGridViewComboBoxColumn;
			if (cbColumnDepartment != null)
			{
				cbColumnDepartment.DataSource = departments;
				cbColumnDepartment.DisplayMember = "Name"; // Отображаемое значение
				cbColumnDepartment.ValueMember = "Id"; // Связь по идентификатору
				cbColumnDepartment.DataPropertyName = "DepartmentId"; // Связь с свойством BindingList
			}
		}

		public static void LoadTeachers(DatabaseContext ctx, DataGridView dgv)
		{
			var teachers = ctx.Teacher.ToList();
			var cbColumnTeacher = dgv.Columns["DgvCbTeacher"] as DataGridViewComboBoxColumn;
			if (cbColumnTeacher != null)
			{
				cbColumnTeacher.DataSource = teachers;
				cbColumnTeacher.DisplayMember = "Name"; // Отображаемое значение
				cbColumnTeacher.ValueMember = "Id"; // Связь по идентификатору
				cbColumnTeacher.DataPropertyName = "TeacherId"; // Связь с свойством BindingList
			}
		}

		public static void LoadDirections(DatabaseContext ctx, DataGridView dgv)
		{
			var directions = ctx.Direction.ToList();
			var cbColumnDirection = dgv.Columns["DgvCbDirection"] as DataGridViewComboBoxColumn;
			if (cbColumnDirection != null)
			{
				cbColumnDirection.DataSource = directions;
				cbColumnDirection.DisplayMember = "Name"; // Отображаемое значение
				cbColumnDirection.ValueMember = "Id"; // Связь по идентификатору
				cbColumnDirection.DataPropertyName = "DirectionId"; // Связь с свойством BindingList
			}
		}

		public static void LoadGroup(DatabaseContext ctx, DataGridView dgv)
		{
			var groups = ctx.Group.ToList();
			var cbColumnDGroup = dgv.Columns["DgvCbGroup"] as DataGridViewComboBoxColumn;
			if (cbColumnDGroup != null)
			{
				cbColumnDGroup.DataSource = groups;
				cbColumnDGroup.DisplayMember = "Name"; // Отображаемое значение
				cbColumnDGroup.ValueMember = "Id"; // Связь по идентификатору
				cbColumnDGroup.DataPropertyName = "GroupId"; // Связь с свойством BindingList
			}
		}
	}
}

