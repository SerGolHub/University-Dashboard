﻿using Database;

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
			var cbColumnFaculty = dgv.Columns["Faculty"] as DataGridViewComboBoxColumn;
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
			var cbColumnDepartment = dgv.Columns["Department"] as DataGridViewComboBoxColumn;
			if (cbColumnDepartment != null)
			{
				cbColumnDepartment.DataSource = departments;
				cbColumnDepartment.DisplayMember = "Name"; // Отображаемое значение
				cbColumnDepartment.ValueMember = "Id"; // Связь по идентификатору
				cbColumnDepartment.DataPropertyName = "DepartmentId"; // Связь с свойством BindingList
			}
		}
	}
}

