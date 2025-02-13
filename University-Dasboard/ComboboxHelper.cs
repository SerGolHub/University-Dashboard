﻿using Database;
using Microsoft.EntityFrameworkCore;
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
            foreach (ComboBox cb in cbs)
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
        }

        public static bool LoadFacultyDepartments(
            ComboBox cbDepartment,
            Guid selectedFacultyId,
            Department? selectedDepartment)
        {
            return LoadComboboxData<Department>(
                    cbDepartment,
                    dep => dep.FacultyId == selectedFacultyId);
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
        }

        public static bool LoadDepartmentTeachers(
            ComboBox cbTeachers,
            Guid selectedDepartmentId,
            Teacher? selectedTeacher)
        {
            return LoadComboboxData<Teacher>(
                cbTeachers,
                t => t.DepartmentId == selectedDepartmentId);
        }

        public static bool LoadDepartmentSubjects(
            ComboBox cbSubjects,
            Guid selectedDepartmentId,
            Subject? selectedSubject)
        {
			using var ctx = new DatabaseContext();
			var filteredDataList = ctx.Subject
                .Include(s => s.Direction)
                .Where(s => s.Direction!.DepartmentId == selectedDepartmentId)
                .ToList();
			LoadCombobox(
				filteredDataList,
				comboBox: cbSubjects);

			if (filteredDataList.Count < 1)
			{
				return false;
			}
			else
			{
				return true;
			}
        }

        public static bool LoadFacultyDirectionSubject(
            ComboBox cbDirection,
            ComboBox cbSubject,
            Guid selectedFacultyId,
            Department? selectedDirection,
            Direction? selectedSubject)
        {
            return LoadComboboxData<Direction>(
                    cbDirection,
                    dep => dep.FacultyId == selectedFacultyId);
        }

        public static bool LoadFacultyDirections(
            ComboBox cbDirection,
            Guid selectedFacultyId,
            Direction? selectedDirection = null)
        {
            // Загружаем направления для указанного факультета
            return LoadComboboxData<Direction>(
                cbDirection,
                dir => dir.FacultyId == selectedFacultyId);
        }

        public static bool LoadDirectionGroups(
            ComboBox cbGroup,
            Guid selectedDirectionId,
            Group? selectedGroup = null)
        {
            // Загружаем группы для указанного направления
            return LoadComboboxData<Group>(
                cbGroup,
                group => group.DirectionId == selectedDirectionId);
        }
    }
}
