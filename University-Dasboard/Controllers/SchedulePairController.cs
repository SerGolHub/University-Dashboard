using Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_Dasboard.Database.Models;
using static University_Dasboard.FrmSchedulePair;

namespace University_Dasboard.Controllers
{
    public class SchedulePairController
    {
        public static void LoadSchedulePairs(DataGridView dgv, ref BindingList<SchedulePairViewModel> bindingList)
        {
            using var ctx = new DatabaseContext();

            var schedulePairs = ctx.SchedulePairs.Include(sp => sp.ScheduleDiscipline)
                .ThenInclude(sd => sd!.Subject).Include(sp => sp.ScheduleDiscipline!.Faculty)
                .Include(sp => sp.ScheduleDiscipline!.Direction).Include(sp => sp.ScheduleDiscipline!.Group)
                .Include(sp => sp.ScheduleDiscipline!.ScheduleWeek).Include(t => t.Teacher)
                .Select(sp => new SchedulePairViewModel
                {
                    Id = sp.Id,
                    Name = sp.Name, // Изменено для использования свойства Name
                    StartTime = sp.StartTime,
                    EndTime = sp.EndTime,
                    ClassroomName = sp.ClassroomName, // Изменено для ClassroomName
                    TeacherName = sp.TeacherName, // Изменено для TeacherName
                    ScheduleDisciplineId = sp.ScheduleDisciplineId,
                    SubjectName = sp.ScheduleDiscipline!.Subject!.Name
                    
                })
                .ToList();

            bindingList = new BindingList<SchedulePairViewModel>(schedulePairs);
            dgv.DataSource = bindingList;
        }

        public static SchedulePairViewModel LoadSchedulePairById(Guid pairId)
        {
            using var ctx = new DatabaseContext();

            var schedulePair = ctx.SchedulePairs
                .Include(sp => sp.ScheduleDiscipline)
                .ThenInclude(sd => sd.Subject)
                .Where(sp => sp.Id == pairId)
                .Select(sp => new SchedulePairViewModel
                {
                    Id = sp.Id,
                    Name = sp.Name,
                    StartTime = sp.StartTime,
                    EndTime = sp.EndTime,
                    ClassroomName = sp.ClassroomName,
                    TeacherName = sp.TeacherName,
                    ScheduleDisciplineId = sp.ScheduleDisciplineId,
                    SubjectName = sp.ScheduleDiscipline!.Subject!.Name
                })
                .FirstOrDefault();

            return schedulePair!;
        }

        public static async Task SaveSchedulePairsAsync(
            List<SchedulePairViewModel> newPairs,
            List<SchedulePairViewModel> updatedPairs,
            List<SchedulePairViewModel> removedPairs)
        {
            using var ctx = new DatabaseContext();

            await AddNewPairsAsync(ctx, newPairs);
            await UpdateExistingPairsAsync(ctx, updatedPairs);
            await RemovePairsAsync(ctx, removedPairs);

            await ctx.SaveChangesAsync();
        }

        private static async Task AddNewPairsAsync(DatabaseContext ctx, List<SchedulePairViewModel> newPairs)
        {
            if (newPairs.Count < 1)
                return;

            var newEntities = newPairs.Select(p => new SchedulePair
            {
                Id = Guid.NewGuid(),
                Name = p.Name, // Используем Name
                StartTime = p.StartTime,
                EndTime = p.EndTime,
                ClassroomName = p.ClassroomName,
                TeacherName = p.TeacherName,
                SubjectName = p.ScheduleDiscipline!.Subject!.Name
            }).ToList();

            await ctx.SchedulePairs.AddRangeAsync(newEntities);
        }

        private static async Task UpdateExistingPairsAsync(DatabaseContext ctx, List<SchedulePairViewModel> updatedPairs)
        {
            if (updatedPairs.Count < 1)
                return;

            var updatedIds = updatedPairs.Select(p => p.Id).ToList();
            var existingPairs = await ctx.SchedulePairs.Where(p => updatedIds.Contains(p.Id)).ToListAsync();

            foreach (var existingPair in existingPairs)
            {
                var updatedPair = updatedPairs.First(p => p.Id == existingPair.Id);
                existingPair.Name = updatedPair.Name;
                existingPair.StartTime = updatedPair.StartTime;
                existingPair.EndTime = updatedPair.EndTime;
                existingPair.ClassroomName = updatedPair.ClassroomName;
                existingPair.TeacherName = updatedPair.TeacherName;
                existingPair.ScheduleDisciplineId = updatedPair.ScheduleDisciplineId;
            }
        }

        private static async Task RemovePairsAsync(DatabaseContext ctx, List<SchedulePairViewModel> removedPairs)
        {
            if (removedPairs.Count < 1)
                return;

            var removedIds = removedPairs.Select(p => p.Id).ToList();
            var pairsToRemove = await ctx.SchedulePairs.Where(p => removedIds.Contains(p.Id)).ToListAsync();

            ctx.SchedulePairs.RemoveRange(pairsToRemove);
        }
    }
}
