using Database;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using University_Dasboard.Database.Models;
using static University_Dasboard.FrmDepartments;

namespace University_Dasboard.Controllers
{
    public class DepartmentController
    {
		public static void LoadDepartmentsAsync(
			DataGridView dgv,
			ref BindingList<DepartmentViewModel> bindingList)
		{
			using var ctx = new DatabaseContext();
			var department = ctx.Department
			.Include(d => d.Faculty)
			.Select(d => new DepartmentViewModel
			{
				Id = d.Id,
				Name = d.Name,
				FacultyId = d.FacultyId,
				FacultyName = d.Faculty!.Name
			})
			.ToList();

			bindingList = new BindingList<DepartmentViewModel>(department);
			dgv.DataSource = bindingList;
		}

		public static async Task SaveDepartmentsAsync(
				List<DepartmentViewModel> newDepartmentList,
				List<DepartmentViewModel> updatedDepartmentList,
				List<DepartmentViewModel> removedDepartmentList)
		{
			using var ctx = new DatabaseContext();

			await AddNewDepartmentsAsync(ctx, newDepartmentList);
			await UpdateExistingDepartmentsAsync(ctx, updatedDepartmentList);
			await RemoveDepartmentsAsync(ctx, removedDepartmentList);

			await ctx.SaveChangesAsync();
		}

		private static async Task AddNewDepartmentsAsync(
			DatabaseContext ctx,
			List<DepartmentViewModel> newDepartmentsList)
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
			List<DepartmentViewModel> updatedDepartments)
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
			DatabaseContext ctx, List<DepartmentViewModel> removedDepartments)
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
