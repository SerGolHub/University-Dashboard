using Database;
using University_Dasboard.Database.Models;

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
            ComboBox comboBox,
            string comboBoxDisplayMember,
            string comboBoxValueMember)
            where T : class
        {
            comboBox.DataSource = comboboxData;
            comboBox.DisplayMember = comboBoxDisplayMember;
            comboBox.ValueMember = comboBoxValueMember;
        }

        public static void LoadComboboxWithSelector<T>(
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

            LoadCombobox<T>(
                items!,
                comboBox: cb,
                comboBoxDisplayMember: "Name",
                comboBoxValueMember: "Id");
        }
    }
}

