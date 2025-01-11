using Database;
using University_Dasboard.Database.Models;

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

		public static void LoadFacultyDepartments(
			ComboBox cbDepartment,
			ComboBox cbDirection,
			Guid selectedFacultyId,
			Department? selectedDepartment,
			Direction? selectedDirection)
		{
			bool isDepartmentLoaded = LoadComboboxData<Department>(
					cbDepartment,
					dep => dep.FacultyId == selectedFacultyId);
			if (!isDepartmentLoaded)
			{
				selectedDepartment = null;
				cbDepartment.Text = string.Empty;
				cbDepartment.DataSource = null;

				selectedDirection = null;
				cbDirection.Text = string.Empty;
				cbDirection.DataSource = null;
			}
		}

		public static void LoadFacultyDepartments(
			ComboBox cbDepartment,
			Guid selectedFacultyId,
			Department? selectedDepartment)
		{
			bool isDepartmentLoaded = LoadComboboxData<Department>(
					cbDepartment,
					dep => dep.FacultyId == selectedFacultyId);
			if (!isDepartmentLoaded)
			{
				selectedDepartment = null;
				cbDepartment.Text = string.Empty;
				cbDepartment.DataSource = null;
			}
		}

		public static void LoadDepartmentDirections(
			ComboBox cbDirection,
			Guid selectedDepartmentId,
			Direction? selectedDirection)
		{
			bool isDirectionLoaded = LoadComboboxData<Direction>(
				cbDirection,
				dir => dir.DepartmentId == selectedDepartmentId);
			if (!isDirectionLoaded)
			{
				selectedDirection = null;
				cbDirection.Text = string.Empty;
				cbDirection.DataSource = null;
			}
		}

		public static void LoadDepartmentTeachers(
			ComboBox cbTeachers,
			Guid selectedDepartmentId,
			Teacher? selectedTeacher)
		{
			bool isTeacherLoaded = LoadComboboxData<Teacher>(
				cbTeachers,
				t => t.DepartmentId == selectedDepartmentId);
			if (!isTeacherLoaded)
			{
				selectedTeacher = null;
				cbTeachers.Text = string.Empty;
				cbTeachers.DataSource = null;
			}
		}
	}
}
