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

            var schedulePairs = ctx.SchedulePairs
                .Include(sp => sp.ScheduleDiscipline)
                .ThenInclude(sd => sd!.Subject)
                .Include(sp => sp.ScheduleDiscipline!.Group)
                .Include(sp => sp.ScheduleDiscipline!.Subject)
                .Select(sp => new SchedulePairViewModel
                {
                    Id = sp.Id,
                    PairNumber = sp.PairNumber,
                    StartTime = sp.StartTime,
                    EndTime = sp.EndTime,
                    Classroom = sp.Classroom,
                    Teacher = sp.Teacher,
                    ScheduleDisciplineId = sp.ScheduleDisciplineId,
                    ScheduleDisciplineName = sp.ScheduleDiscipline!.Subject!.Name
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
                    PairNumber = sp.PairNumber,
                    StartTime = sp.StartTime,
                    EndTime = sp.EndTime,
                    Classroom = sp.Classroom,
                    Teacher = sp.Teacher,
                    ScheduleDisciplineId = sp.ScheduleDisciplineId,
                    ScheduleDisciplineName = sp.ScheduleDiscipline!.Subject!.Name
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
                PairNumber = p.PairNumber,
                StartTime = p.StartTime,
                EndTime = p.EndTime,
                Classroom = p.Classroom,
                Teacher = p.Teacher,
                ScheduleDisciplineId = p.ScheduleDisciplineId
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
                existingPair.PairNumber = updatedPair.PairNumber;
                existingPair.StartTime = updatedPair.StartTime;
                existingPair.EndTime = updatedPair.EndTime;
                existingPair.Classroom = updatedPair.Classroom;
                existingPair.Teacher = updatedPair.Teacher;
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
