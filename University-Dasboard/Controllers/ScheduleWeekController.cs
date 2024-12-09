using Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using University_Dasboard.Interfaces;
using static University_Dasboard.FrmSchedulingDiscipline;
using University_Dasboard.Database.Models;
using static University_Dasboard.FrmSchedulingWeek;


namespace University_Dasboard.Controllers
{
	public class ScheduleWeekController
	{
		public static void LoadSchedulesWeekAsync(DataGridView dgv, ref BindingList<ScheduleWeekViewModel> bindingList)
		{
			using var ctx = new DatabaseContext();
			var schedules = ctx.ScheduleWeek.Select(s => new ScheduleWeekViewModel
				{
					Id = s.Id,
					ScheduleWeek = s.Name,
					LectureHours = s.LectureHours,
					LaboratoryHours = s.LaboratoryHours,
					PracticalHours = s.PracticalHours,
				}).ToList();

			bindingList = new BindingList<ScheduleWeekViewModel>(schedules);
			dgv.DataSource = bindingList;
		}

		public static async Task SaveSchedulesWeekAsync(List<ScheduleWeekViewModel> newScheduleList,
			List<ScheduleWeekViewModel> updatedScheduleList, List<ScheduleWeekViewModel> removedScheduleList)
		{
			using var ctx = new DatabaseContext();

			await AddNewSchedulesWeekAsync(ctx, newScheduleList);
			await UpdateExistingSchedulesWeekAsync(ctx, updatedScheduleList);
			await RemoveSchedulesWeekAsync(ctx, removedScheduleList);

			await ctx.SaveChangesAsync();
		}

		private static async Task AddNewSchedulesWeekAsync(
			DatabaseContext ctx,
			List<ScheduleWeekViewModel> newSchedules)
		{
			if (newSchedules.Count < 1)
				return;

			var newEntities = newSchedules.Select(s => new ScheduleWeek
			{
				Id = Guid.NewGuid(),
				Name = s.ScheduleWeek,
				LectureHours = s.LectureHours,
				LaboratoryHours = s.LaboratoryHours,
				PracticalHours = s.PracticalHours,
			}).ToList();

			await ctx.ScheduleWeek.AddRangeAsync(newEntities);
		}

		private static async Task UpdateExistingSchedulesWeekAsync(DatabaseContext ctx,
			List<ScheduleWeekViewModel> updatedSchedules)
		{
			if (updatedSchedules.Count < 1)
				return;

			var updatedIds = updatedSchedules.Select(s => s.Id).ToList();
			var existingSchedules = await ctx.ScheduleWeek
				.Where(s => updatedIds.Contains(s.Id))
				.ToListAsync();

			foreach (var existingSchedule in existingSchedules)
			{
				var updatedSchedule = updatedSchedules.First(s => s.Id == existingSchedule.Id);
				existingSchedule.Name = updatedSchedule.ScheduleWeek;
				existingSchedule.LectureHours = updatedSchedule.LectureHours;
				existingSchedule.PracticalHours = updatedSchedule.PracticalHours;
				existingSchedule.LaboratoryHours = updatedSchedule.LaboratoryHours;
			}
		}

		private static async Task RemoveSchedulesWeekAsync(DatabaseContext ctx,
			List<ScheduleWeekViewModel> removedSchedules)
		{
			if (removedSchedules.Count < 1)
				return;

			var removedIds = removedSchedules.Select(s => s.Id).ToList();
			var schedulesToRemove = await ctx.ScheduleWeek
				.Where(s => removedIds.Contains(s.Id))
				.ToListAsync();

			ctx.ScheduleWeek.RemoveRange(schedulesToRemove);
		}
	}
}
