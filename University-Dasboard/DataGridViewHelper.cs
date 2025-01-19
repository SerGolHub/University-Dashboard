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
			DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
			if (cell is DataGridViewComboBoxCell)
			{
				dgv.BeginEdit(false);
				((DataGridViewComboBoxEditingControl)dgv.EditingControl).DroppedDown = true;
			}
		}
	}
}

