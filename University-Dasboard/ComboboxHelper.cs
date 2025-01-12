using Database;
using System.Security.Cryptography.X509Certificates;
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

		public static void ClearComboboxes(params ComboBox[] cbs)
		{
			foreach(ComboBox cb in cbs)
			{
				cb.Text = string.Empty;
				cb.DataSource = null;
			}
		}

		public static bool LoadFacultyDepartments(
			ComboBox cbDepartment,
			ComboBox cbDirection,
			Guid selectedFacultyId,
			Department? selectedDepartment,
			Direction? selectedDirection)
		{
			return LoadComboboxData<Department>(
					cbDepartment,
					dep => dep.FacultyId == selectedFacultyId);
			//if (!isDepartmentLoaded)
			//{
			//	selectedDepartment = null;
			//	ClearComboboxes(cbDepartment);
			//	//cbDepartment.Text = string.Empty;
			//	//cbDepartment.DataSource = null;
			//	ClearComboboxes(cbDirection);
			//	selectedDirection = null;
			//	//cbDirection.Text = string.Empty;
			//	//cbDirection.DataSource = null;
			//}
		}

		public static bool LoadFacultyDepartments(
			ComboBox cbDepartment,
			Guid selectedFacultyId,
			Department? selectedDepartment)
		{
			return LoadComboboxData<Department>(
					cbDepartment,
					dep => dep.FacultyId == selectedFacultyId);
			//if (!isDepartmentLoaded)
			//{
			//	selectedDepartment = null;
			//	ClearComboboxes(cbDepartment);
			//	//cbDepartment.Text = string.Empty;
			//	//cbDepartment.DataSource = null;
			//}
		}

		public static bool LoadDepartmentDirections(
			ComboBox cbDirection,
			Guid selectedDepartmentId,
			Direction? selectedDirection,
			Group? selectedGroup = null,
			ComboBox? cbGroup = null)
		{
			return LoadComboboxData<Direction>(
				cbDirection,
				dir => dir.DepartmentId == selectedDepartmentId);
			//if (!isDirectionLoaded)
			//{
			//	selectedDirection = null;
			//	ClearComboboxes(cbDirection);
			//	//cbDirection.Text = string.Empty;
			//	//cbDirection.DataSource = null;

			//	selectedGroup = null;
			//	if (cbGroup != null)
			//	{
			//		ClearComboboxes(cbGroup);
			//		//cbGroup.Text = string.Empty;
			//		//cbGroup.DataSource = null;
			//	}
			//}
		}

		public static bool LoadDepartmentTeachers(
			ComboBox cbTeachers,
			Guid selectedDepartmentId,
			Teacher? selectedTeacher)
		{
			return LoadComboboxData<Teacher>(
				cbTeachers,
				t => t.DepartmentId == selectedDepartmentId);
			//if (!isTeacherLoaded)
			//{
			//	selectedTeacher = null;
			//	ClearComboboxes(cbTeachers);
			//	//cbTeachers.Text = string.Empty;
			//	//cbTeachers.DataSource = null;
			//}
		}

		public static bool LoadDepartmentSubjects(
			ComboBox cbSubjects,
			Guid selectedDepartmentId,
			Subject? selectedSubject)
		{
			return LoadComboboxData<Subject>(
				cbSubjects,
				s => s.DepartmentId == selectedDepartmentId);
			//if (!isSubjectLoaded)
			//{
			//	selectedSubject = null;
			//	ClearComboboxes(cbSubjects);
			//	//cbSubjects.Text = string.Empty;
			//	//cbSubjects.DataSource = null;
			//}
		}
	}
}
