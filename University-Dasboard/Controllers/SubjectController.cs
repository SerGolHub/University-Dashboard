using Database;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using University_Dasboard.Database.Models;
using static University_Dasboard.FrmSubjects;

namespace University_Dasboard.Controllers
{
	public class SubjectController
    {
		public static void LoadDisciplines(
			DataGridView dgv,
			ref BindingList<DisciplineViewModel> bindingList)
		{
			using var ctx = new DatabaseContext();
			var disciplines = ctx.Subject
			.Include(dis => dis.Teacher)
			.Include(dis => dis.Department)
			.ThenInclude(dep => dep!.Faculty)
			.Select(dis => new DisciplineViewModel
			{
				Id = dis.Id,
				Name = dis.Name,
				DepartmentId = dis.DepartmentId,
				DepartmentName = dis.Department!.Name,
				TeacherId = dis.TeacherId,
				TeacherName = dis.Teacher!.Name
			})
			.ToList();

			bindingList = new BindingList<DisciplineViewModel>(disciplines);
			dgv.DataSource = bindingList;
		}

		public static async Task SaveDisciplinesAsync(
				List<DisciplineViewModel> newDisciplineList,
				List<DisciplineViewModel> updatedDisciplineList,
				List<DisciplineViewModel> removedDisciplineList)
		{
			using var ctx = new DatabaseContext();

			await AddNewDisciplinesAsync(ctx, newDisciplineList);
			await UpdateExistingDisciplinesAsync(ctx, updatedDisciplineList);
			await RemoveDisciplinesAsync(ctx, removedDisciplineList);

			await ctx.SaveChangesAsync();
		}

		private static async Task AddNewDisciplinesAsync(
			DatabaseContext ctx,
			List<DisciplineViewModel> newDisciplineList)
		{
			if (newDisciplineList.Count < 1)
			{
				return;
			}
			var newDisciplines = newDisciplineList.Select(dis => new Subject
			{
				Id = dis.Id,
				Name = dis.Name,
				DepartmentId = dis.DepartmentId,
				TeacherId = dis.TeacherId
			}).ToList();

			await ctx.Subject.AddRangeAsync(newDisciplines);
		}

		private static async Task UpdateExistingDisciplinesAsync(
			DatabaseContext ctx,
			List<DisciplineViewModel> updatedDisciplines)
		{
			if (updatedDisciplines.Count < 1)
			{
				return;
			}
			var updatedIds = updatedDisciplines.Select(dis => dis.Id).ToList();
			var existingDisciplines = await ctx.Subject
				.Where(dis => updatedIds.Contains(dis.Id))
				.ToListAsync();

			foreach (var existingDiscipline in existingDisciplines)
			{
				var updatedDiscipline = updatedDisciplines.First(dis => dis.Id == existingDiscipline.Id);
				existingDiscipline.Name = updatedDiscipline.Name;
				existingDiscipline.DepartmentId = updatedDiscipline.DepartmentId;
				existingDiscipline.TeacherId = updatedDiscipline.TeacherId;
			}
		}

		private static async Task RemoveDisciplinesAsync(
			DatabaseContext ctx,
			List<DisciplineViewModel> removedDisciplines)
		{
			if (removedDisciplines.Count < 1)
			{
				return;
			}
			var removedIds = removedDisciplines.Select(dis => dis.Id).ToList();
			var disciplinesToRemove = await ctx.Subject
				.Where(dis => removedIds.Contains(dis.Id))
				.ToListAsync();

			ctx.Subject.RemoveRange(disciplinesToRemove);
		}
	}
}
