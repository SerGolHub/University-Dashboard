using Database;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using University_Dasboard.Database.Models;
using static University_Dasboard.FrmDepartments;

namespace University_Dasboard.Controllers
{
    public class DepartmentController
    {
		public static void LoadDepartments(
			DataGridView dgv,
<<<<<<< HEAD
			ref BindingList<Department> bindingList)
=======
			ref BindingList<DepartmentViewModel> bindingList)
>>>>>>> 0bf24bda135f7866785731ef32cc36e3839cd807
		{
			using var ctx = new DatabaseContext();
			var departments = ctx.Department
			.Include(d => d.Faculty)
<<<<<<< HEAD
			.Select(d => new Department
			{
				Id = d.Id,
				Name = d.Name,
				FacultyId = d.FacultyId
			})
			.ToList();

			bindingList = new BindingList<Department>(departments);
=======
			.Select(d => new DepartmentViewModel
			{
				Id = d.Id,
				Name = d.Name,
				FacultyId = d.FacultyId,
				FacultyName = d.Faculty!.Name
			})
			.ToList();

			bindingList = new BindingList<DepartmentViewModel>(departments);
>>>>>>> 0bf24bda135f7866785731ef32cc36e3839cd807
			var faculties = ctx.Faculty.ToList();
			var cbColumnFaculty = dgv.Columns["FacultyName"] as DataGridViewComboBoxColumn;
			if (cbColumnFaculty != null)
			{
				cbColumnFaculty.DataSource = faculties;
				cbColumnFaculty.DisplayMember = "Name"; // Отображаемое значение
				cbColumnFaculty.ValueMember = "Id"; // Связь по идентификатору
				cbColumnFaculty.DataPropertyName = "FacultyId"; // Связь с свойством BindingList
			}
			dgv.DataSource = bindingList;
		}

		public static async Task SaveDepartmentsAsync(
<<<<<<< HEAD
				List<Department> newDepartmentList,
				List<Department> updatedDepartmentList,
				List<Department> removedDepartmentList)
=======
				List<DepartmentViewModel> newDepartmentList,
				List<DepartmentViewModel> updatedDepartmentList,
				List<DepartmentViewModel> removedDepartmentList)
>>>>>>> 0bf24bda135f7866785731ef32cc36e3839cd807
		{
			using var ctx = new DatabaseContext();

			await AddNewDepartmentsAsync(ctx, newDepartmentList);
			await UpdateExistingDepartmentsAsync(ctx, updatedDepartmentList);
			await RemoveDepartmentsAsync(ctx, removedDepartmentList);

			await ctx.SaveChangesAsync();
		}

		private static async Task AddNewDepartmentsAsync(
			DatabaseContext ctx,
<<<<<<< HEAD
			List<Department> newDepartmentsList)
=======
			List<DepartmentViewModel> newDepartmentsList)
>>>>>>> 0bf24bda135f7866785731ef32cc36e3839cd807
		{
			if (newDepartmentsList.Count < 1)
			{
				return;
			}
			var newDepartments = newDepartmentsList.Select(d => new Department
			{
				Id = d.Id,
				Name = d.Name,
				FacultyId = d.FacultyId
			}).ToList();

			await ctx.Department.AddRangeAsync(newDepartments);
		}

		private static async Task UpdateExistingDepartmentsAsync(
			DatabaseContext ctx,
<<<<<<< HEAD
			List<Department> updatedDepartments)
=======
			List<DepartmentViewModel> updatedDepartments)
>>>>>>> 0bf24bda135f7866785731ef32cc36e3839cd807
		{
			if (updatedDepartments.Count < 1)
			{
				return;
			}
			var updatedIds = updatedDepartments.Select(d => d.Id).ToList();
			var existingDepartments = await ctx.Department
				.Where(d => updatedIds.Contains(d.Id))
				.ToListAsync();

			foreach (var existingDepartment in existingDepartments)
			{
				var updatedDepartment = updatedDepartments.First(d => d.Id == existingDepartment.Id);
				existingDepartment.Name = updatedDepartment.Name;
				existingDepartment.FacultyId = updatedDepartment.FacultyId;
			}
		}

		private static async Task RemoveDepartmentsAsync(
<<<<<<< HEAD
			DatabaseContext ctx, List<Department> removedDepartments)
=======
			DatabaseContext ctx, List<DepartmentViewModel> removedDepartments)
>>>>>>> 0bf24bda135f7866785731ef32cc36e3839cd807
		{
			if (removedDepartments.Count < 1)
			{
				return;
			}
			var removedIds = removedDepartments.Select(d => d.Id).ToList();
			var directionsToRemove = await ctx.Department
				.Where(d => removedIds.Contains(d.Id))
				.ToListAsync();

			ctx.Department.RemoveRange(directionsToRemove);
		}
	}
}
