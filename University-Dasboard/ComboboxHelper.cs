using Database;

namespace University_Dasboard
{
	public class ComboboxHelper
	{
		public static void LoadCombobox<T>(
			List<T> comboboxData,
			ComboBox comboBox)
			where T : class
		{
			comboBox.DataSource = comboboxData;
			comboBox.DisplayMember = "Name";
			comboBox.ValueMember = "Id";
			if (comboboxData.Count < 1)
			{
				comboBox.Text = string.Empty;
			}
		}

		public static void LoadComboboxData<T>(ComboBox cb) where T : class
		{
			using var ctx = new DatabaseContext();
			var dataList = ctx.Set<T>().ToList();
			LoadCombobox(
				dataList,
				comboBox: cb);
		}

		public static bool LoadComboboxData<T>(
			ComboBox cb,
			Func<T, bool> filter
			) where T : class
		{
			using var ctx = new DatabaseContext();
			var filteredDataList = ctx.Set<T>().Where(filter).ToList();
			LoadCombobox(
				filteredDataList,
				comboBox: cb);

			if (filteredDataList.Count < 1)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
	}
}
