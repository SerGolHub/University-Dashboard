using Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static University_Dasboard.FrmTeachers;
using Microsoft.EntityFrameworkCore;
using University_Dasboard.Database.Models;

namespace University_Dasboard.Controllers
{
	public class TeacherController
	{
		// Загрузка списка преподавателей с ограничениями
		public static void LoadTeachers(DataGridView dgv, ref BindingList<TeacherViewModel> bindingList)
		{
			using var ctx = new DatabaseContext();

			var teachers = ctx.Teacher
				.Include(t => t.Department)
				.Include(t => t.Constraints)
					.ThenInclude(c => c.DayConstraints)
				.Select(t => new TeacherViewModel
				{
					Id = t.Id,
					Name = t.Name,
					PhoneNumber = t.PhoneNumber,
					Email = t.Email,
					HireDate = t.HireDate,
					Degree = t.Degree,
					Status = t.Status,
					DepartmentName = t.Department != null ? t.Department.Name : string.Empty,
					Constraints = t.Constraints.Select(c => new TeacherConstraintViewModel
					{
						Id = c.Id,
						Note = c.Note,
						DayConstraints = c.DayConstraints.Select(dc => new DayConstraintViewModel
						{
							Id = dc.Id,
							DayOfWeek = dc.DayOfWeek
						}).ToList()
					}).ToList()
				})
				.ToList();

			bindingList = new BindingList<TeacherViewModel>(teachers);
			dgv.DataSource = bindingList;
		}

		// Сохранение преподавателей и их ограничений
		public static async Task SaveTeachersAsync(
			List<TeacherViewModel> newTeacherList,
			List<TeacherViewModel> updatedTeacherList,
			List<TeacherViewModel> removedTeacherList)
		{
			using var ctx = new DatabaseContext();

			await AddNewTeachersAsync(ctx, newTeacherList);
			await UpdateExistingTeachersAsync(ctx, updatedTeacherList);
			await RemoveTeachersAsync(ctx, removedTeacherList);

			await ctx.SaveChangesAsync();
		}

		private static async Task AddNewTeachersAsync(
			DatabaseContext ctx,
			List<TeacherViewModel> newTeacherList)
		{
			if (!newTeacherList.Any())
				return;

			var newTeachers = newTeacherList.Select(t => new Teacher
			{
				Id = Guid.NewGuid(),
				Name = t.Name,
				PhoneNumber = t.PhoneNumber,
				Email = t.Email,
				HireDate = t.HireDate,
				Degree = t.Degree,
				Status = t.Status,
				DepartmentId = t.DepartmentId,
				Constraints = t.Constraints.Select(c => new TeacherConstraint
				{
					Id = Guid.NewGuid(),
					Note = c.Note,
					DayConstraints = c.DayConstraints.Select(dc => new DayConstraint
					{
						Id = Guid.NewGuid(),
						DayOfWeek = dc.DayOfWeek
					}).ToList()
				}).ToList()
			}).ToList();

			await ctx.Teacher.AddRangeAsync(newTeachers);
		}

		private static async Task UpdateExistingTeachersAsync(
			DatabaseContext ctx,
			List<TeacherViewModel> updatedTeacherList)
		{
			if (!updatedTeacherList.Any())
				return;

			var updatedIds = updatedTeacherList.Select(t => t.Id).ToList();
			var existingTeachers = await ctx.Teacher
				.Include(t => t.Constraints)
					.ThenInclude(c => c.DayConstraints)
				.Where(t => updatedIds.Contains(t.Id))
				.ToListAsync();

			foreach (var existingTeacher in existingTeachers)
			{
				var updatedTeacher = updatedTeacherList.First(t => t.Id == existingTeacher.Id);
				existingTeacher.Name = updatedTeacher.Name;
				existingTeacher.PhoneNumber = updatedTeacher.PhoneNumber;
				existingTeacher.Email = updatedTeacher.Email;
				existingTeacher.HireDate = updatedTeacher.HireDate;
				existingTeacher.Degree = updatedTeacher.Degree;
				existingTeacher.Status = updatedTeacher.Status;
				existingTeacher.DepartmentId = updatedTeacher.DepartmentId;

				UpdateConstraints(existingTeacher, updatedTeacher);
			}
		}

		private static void UpdateConstraints(Teacher existingTeacher, TeacherViewModel updatedTeacher)
		{
			// Удаление старых ограничений
			existingTeacher.Constraints.Clear();

			// Добавление новых ограничений
			foreach (var constraint in updatedTeacher.Constraints)
			{
				var newConstraint = new TeacherConstraint
				{
					Id = Guid.NewGuid(),
					Note = constraint.Note,
					DayConstraints = constraint.DayConstraints.Select(dc => new DayConstraint
					{
						Id = Guid.NewGuid(),
						DayOfWeek = dc.DayOfWeek
					}).ToList()
				};
				existingTeacher.Constraints.Add(newConstraint);
			}
		}

		private static async Task RemoveTeachersAsync(
			DatabaseContext ctx,
			List<TeacherViewModel> removedTeacherList)
		{
			if (!removedTeacherList.Any())
				return;

			var removedIds = removedTeacherList.Select(t => t.Id).ToList();
			var teachersToRemove = await ctx.Teacher
				.Where(t => removedIds.Contains(t.Id))
				.ToListAsync();

			ctx.Teacher.RemoveRange(teachersToRemove);
		}
	}
}
