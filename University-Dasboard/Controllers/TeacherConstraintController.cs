using Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using University_Dasboard.Database.Models;
using static University_Dasboard.FrmTeachersConstraint;

namespace University_Dasboard.Controllers
{
    public static class TeacherConstraintController
    {
        public static void LoadTeacherConstraints(DataGridView dgv, ref BindingList<TeacherConstraintViewModel> bindingList)
        {
            using var ctx = new DatabaseContext();
            try
            {
                var teacherConstraints = ctx.TeacherConstraints.Include(c => c.Teacher)
                    .Select(c => new TeacherConstraintViewModel
                    {
                        Id = c.Id,
                        TeacherId = c.TeacherId,
                        Teacher = c.Teacher,
                        DayOfWeek = c.DayOfWeek,
                        StartTime = c.StartTime,
                        EndTime = c.EndTime,
                        Note = c.Note
                    }).ToList();

                bindingList = new BindingList<TeacherConstraintViewModel>(teacherConstraints);
                dgv.DataSource = bindingList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading teacher constraints: {ex.Message}");
            }
        }

        public static async Task SaveTeacherConstraintsAsync(List<TeacherConstraintViewModel> newTeacherConstraintList,
            List<TeacherConstraintViewModel> updatedTeacherConstraintList, List<TeacherConstraintViewModel> removedTeacherConstraintList)
        {
            using var ctx = new DatabaseContext();
            try
            {
                if (newTeacherConstraintList.Any())
                    await AddNewTeacherConstraintsAsync(ctx, newTeacherConstraintList);

                if (updatedTeacherConstraintList.Any())
                    await UpdateExistingTeacherConstraintsAsync(ctx, updatedTeacherConstraintList);

                if (removedTeacherConstraintList.Any())
                    await RemoveTeacherConstraintsAsync(ctx, removedTeacherConstraintList);

                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving teacher constraints: {ex.Message}");
                throw;
            }
        }

        private static async Task AddNewTeacherConstraintsAsync(DatabaseContext ctx, List<TeacherConstraintViewModel> newTeacherConstraintList)
        {
            var newConstraints = newTeacherConstraintList.Select(c => new TeacherConstraint
            {
                Id = Guid.NewGuid(),
                TeacherId = c.TeacherId,
                DayOfWeek = c.DayOfWeek,
                StartTime = c.StartTime,
                EndTime = c.EndTime,
                Note = c.Note
            }).ToList();

            await ctx.TeacherConstraints.AddRangeAsync(newConstraints);
        }

        private static async Task UpdateExistingTeacherConstraintsAsync(DatabaseContext ctx, List<TeacherConstraintViewModel> updatedTeacherConstraintList)
        {
            var constraintIds = updatedTeacherConstraintList.Select(c => c.Id).ToList();
            var existingConstraints = await ctx.TeacherConstraints
                .Where(c => constraintIds.Contains(c.Id))
                .ToListAsync();

            foreach (var existingConstraint in existingConstraints)
            {
                var updatedConstraint = updatedTeacherConstraintList.First(c => c.Id == existingConstraint.Id);
                existingConstraint.TeacherId = updatedConstraint.TeacherId;
                existingConstraint.Teacher = updatedConstraint.Teacher;
                existingConstraint.DayOfWeek = updatedConstraint.DayOfWeek;
                existingConstraint.StartTime = updatedConstraint.StartTime;
                existingConstraint.EndTime = updatedConstraint.EndTime;
                existingConstraint.Note = updatedConstraint.Note;
            }
        }

        private static async Task RemoveTeacherConstraintsAsync(DatabaseContext ctx, List<TeacherConstraintViewModel> removedTeacherConstraintList)
        {
            var constraintIds = removedTeacherConstraintList.Select(c => c.Id).ToList();
            var constraintsToRemove = await ctx.TeacherConstraints
                .Where(c => constraintIds.Contains(c.Id)).ToListAsync();

            ctx.TeacherConstraints.RemoveRange(constraintsToRemove);
        }
    }
}
