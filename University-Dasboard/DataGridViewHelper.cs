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
        public static void LoadCombobox<T>(
            List<T> comboboxData,
            ComboBox comboBox)
            where T : class
        {
            comboBox.DataSource = comboboxData;
            comboBox.DisplayMember = "Name";
            comboBox.ValueMember = "Id";
        }
    }
}

