﻿using Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static University_Dasboard.FrmDirections;

using Microsoft.EntityFrameworkCore;
using University_Dasboard.Database.Models;
using static University_Dasboard.FrmSchedulingDiscipline;

namespace University_Dasboard.Controllers
{
	public class ScheduleDesciplineController
	{
		public static void LoadSchedulesAsync(DataGridView dgv,	ref BindingList<ScheduleDisciplineViewModel> bindingList)
		{
			using var ctx = new DatabaseContext();
			var schedules = ctx.ScheduleDisciplines.Include(s => s.Discipline).Include(s => s.Group!)
				.ThenInclude(s => s.Direction!).ThenInclude(s => s.Faculty)
				.Include(s => s.ScheduleWeek)
				.Select(s => new ScheduleDisciplineViewModel
				{
					Id = s.Id,
					DirectionId = s.DirectionId,
					DirectionName = s.Direction!.Name,
					DisciplineId = s.DisciplineId,
					DisciplineName = s.Discipline!.Name,
					GroupId = s.GroupId,
					GroupName = s.Group!.Name,
					FacultyId = s.FacultyId,
					FacultyName = s.Faculty!.Name,
					ScheduleWeekId = s.ScheduleWeekId,
					ScheduleWeek = s.ScheduleWeek!.Name
				}).ToList();

			bindingList = new BindingList<ScheduleDisciplineViewModel>(schedules);
			dgv.DataSource = bindingList;
		}

		public static async Task SaveSchedulesAsync(
			List<ScheduleDisciplineViewModel> newScheduleList,
			List<ScheduleDisciplineViewModel> updatedScheduleList,
			List<ScheduleDisciplineViewModel> removedScheduleList)
		{
			using var ctx = new DatabaseContext();

			await AddNewSchedulesAsync(ctx, newScheduleList);
			await UpdateExistingSchedulesAsync(ctx, updatedScheduleList);
			await RemoveSchedulesAsync(ctx, removedScheduleList);

			await ctx.SaveChangesAsync();
		}

		private static async Task AddNewSchedulesAsync(
			DatabaseContext ctx,
			List<ScheduleDisciplineViewModel> newSchedules)
		{
			if (newSchedules.Count < 1)
				return;

			var newEntities = newSchedules.Select(s => new ScheduleDiscipline
			{
				Id = Guid.NewGuid(),
				DisciplineId = s.DisciplineId,
				FacultyId = s.FacultyId,
				DirectionId = s.DirectionId,
				GroupId = s.GroupId,
				ScheduleWeekId = s.ScheduleWeekId,
			}).ToList();

			await ctx.ScheduleDisciplines.AddRangeAsync(newEntities);
		}

		private static async Task UpdateExistingSchedulesAsync(DatabaseContext ctx,
			List<ScheduleDisciplineViewModel> updatedSchedules)
		{
			if (updatedSchedules.Count < 1)
				return;

			var updatedIds = updatedSchedules.Select(s => s.Id).ToList();
			var existingSchedules = await ctx.ScheduleDisciplines
				.Where(s => updatedIds.Contains(s.Id))
				.ToListAsync();

			foreach (var existingSchedule in existingSchedules)
			{
				var updatedSchedule = updatedSchedules.First(s => s.Id == existingSchedule.Id);
				existingSchedule.FacultyId = updatedSchedule.FacultyId;
				existingSchedule.DirectionId = updatedSchedule.DirectionId;
				existingSchedule.DisciplineId = updatedSchedule.DisciplineId;
				existingSchedule.GroupId = updatedSchedule.GroupId;
				existingSchedule.ScheduleWeekId = updatedSchedule.ScheduleWeekId;
			}
		}

		private static async Task RemoveSchedulesAsync(
			DatabaseContext ctx,
			List<ScheduleDisciplineViewModel> removedSchedules)
		{
			if (removedSchedules.Count < 1)
				return;

			var removedIds = removedSchedules.Select(s => s.Id).ToList();
			var schedulesToRemove = await ctx.ScheduleDisciplines
				.Where(s => removedIds.Contains(s.Id))
				.ToListAsync();

			ctx.ScheduleDisciplines.RemoveRange(schedulesToRemove);
		}
	}
}
