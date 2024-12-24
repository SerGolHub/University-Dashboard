using Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University_Dasboard.Database.Models;
using static University_Dasboard.FrmTeachers;

namespace University_Dasboard.Controllers
{
    public static class TeacherConstraintController
    {
        public static async Task<List<TeacherConstraintViewModel>> GetConstraintsByTeacherIdAsync(Guid teacherId)
        {
            using var ctx = new DatabaseContext();
            return await ctx.TeacherConstraints
                .Where(c => c.TeacherId == teacherId)
                .Select(c => new TeacherConstraintViewModel
                {
                    Id = c.Id,
                    DayOfWeek = c.DayOfWeek,
                    StartTime = c.StartTime,
                    EndTime = c.EndTime,
                    Note = c.Note
                })
                .ToListAsync();
        }

        public static async Task AddConstraintsAsync(List<TeacherConstraintViewModel> newConstraints, Guid teacherId)
        {
            using var ctx = new DatabaseContext();
            var constraints = newConstraints.Select(c => new TeacherConstraint
            {
                Id = Guid.NewGuid(),
                TeacherId = teacherId,
                DayOfWeek = c.DayOfWeek,
                StartTime = c.StartTime,
                EndTime = c.EndTime,
                Note = c.Note
            }).ToList();

            await ctx.TeacherConstraints.AddRangeAsync(constraints);
            await ctx.SaveChangesAsync();
        }

        public static async Task UpdateConstraintsAsync(List<TeacherConstraintViewModel> updatedConstraints, Guid teacherId)
        {
            using var ctx = new DatabaseContext();
            var existingConstraints = await ctx.TeacherConstraints
                .Where(c => c.TeacherId == teacherId)
                .ToListAsync();

            ctx.TeacherConstraints.RemoveRange(existingConstraints);

            var newConstraints = updatedConstraints.Select(c => new TeacherConstraint
            {
                Id = Guid.NewGuid(),
                TeacherId = teacherId,
                DayOfWeek = c.DayOfWeek,
                StartTime = c.StartTime,
                EndTime = c.EndTime,
                Note = c.Note
            }).ToList();

            await ctx.TeacherConstraints.AddRangeAsync(newConstraints);
            await ctx.SaveChangesAsync();
        }

        public static async Task RemoveConstraintsByTeacherIdAsync(Guid teacherId)
        {
            using var ctx = new DatabaseContext();
            var constraintsToRemove = await ctx.TeacherConstraints
                .Where(c => c.TeacherId == teacherId)
                .ToListAsync();

            ctx.TeacherConstraints.RemoveRange(constraintsToRemove);
            await ctx.SaveChangesAsync();
        }
    }
}
