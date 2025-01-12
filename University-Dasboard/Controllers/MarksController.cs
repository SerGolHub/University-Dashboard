using Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_Dasboard.Database.Models;
using static University_Dasboard.FrmMarks;

namespace University_Dasboard.Controllers
{
    public class MarksController
    {
		public static void LoadMarks(
			DataGridView dgv,
			ref BindingList<MarksViewModel> bindingList)
		{
			using var ctx = new DatabaseContext();
			var marks = ctx.Marks
			.Select(m => new MarksViewModel
			{
				Id = m.Id,
				Mark = m.Mark,
				GradeDate = m.GradeDate,
				MarkType = m.markType,
				StudentId = m.StudentId,
				StudentName = m.Student!.Name,
				SubjectId = m.SubjectId,
				SubjectName = m.Subject!.Name
			})
			.ToList();

			bindingList = new BindingList<MarksViewModel>(marks);
			dgv.DataSource = bindingList;
		}

		public static async Task SaveMarksAsync(
				List<MarksViewModel> newGroupList,
				List<MarksViewModel> updatedGroupList,
				List<MarksViewModel> removedGroupList)
		{
			using var ctx = new DatabaseContext();

			await AddNewMarksAsync(ctx, newGroupList);
			await UpdateExistingMarksAsync(ctx, updatedGroupList);
			await RemoveMarksAsync(ctx, removedGroupList);

			await ctx.SaveChangesAsync();
		}

		private static async Task AddNewMarksAsync(
			DatabaseContext ctx,
			List<MarksViewModel> newMarksList)
		{
			if (newMarksList.Count < 1)
			{
				return;
			}
			var newMarks = newMarksList.Select(m => new Marks
			{
				Id = m.Id,
				Mark = m.Mark,
				GradeDate = m.GradeDate,
				markType = m.MarkType,
				StudentId = m.StudentId,
				SubjectId = m.SubjectId,
			}).ToList();

			await ctx.Marks.AddRangeAsync(newMarks);
		}

		private static async Task UpdateExistingMarksAsync(
			DatabaseContext ctx,
			List<MarksViewModel> updatedMarks)
		{
			if (updatedMarks.Count < 1)
			{
				return;
			}
			var updatedIds = updatedMarks.Select(m => m.Id).ToList();
			var existingMarks = await ctx.Marks
				.Where(m => updatedIds.Contains(m.Id))
				.ToListAsync();

			foreach (var existingMark in existingMarks)
			{
				var updatedMark = updatedMarks.First(m => m.Id == existingMark.Id);
				existingMark.Mark = updatedMark.Mark;
				existingMark.GradeDate = updatedMark.GradeDate;
				existingMark.markType = updatedMark.MarkType;
				existingMark.StudentId = updatedMark.StudentId;
				existingMark.SubjectId = updatedMark.SubjectId;
			}
		}

		private static async Task RemoveMarksAsync(
			DatabaseContext ctx, List<MarksViewModel> removedMarks)
		{
			if (removedMarks.Count < 1)
			{
				return;
			}
			var removedIds = removedMarks.Select(m => m.Id).ToList();
			var marksToRemove = await ctx.Marks
				.Where(m => removedIds.Contains(m.Id))
				.ToListAsync();

			ctx.Marks.RemoveRange(marksToRemove);
		}
	}
}
