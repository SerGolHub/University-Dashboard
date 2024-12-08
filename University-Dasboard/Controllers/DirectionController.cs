using Database;
using static University_Dasboard.FrmDirections;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using University_Dasboard.Database.Models;

namespace University_Dasboard.Controllers
{
    public class DirectionController
    {
        public static void LoadDirectionsAsync(
            DataGridView dgv,
            ref BindingList<DirectionViewModel> bindingList)
        {
            using var ctx = new DatabaseContext();
            var directions = ctx.Direction
            .Include(d => d.Department)
            .ThenInclude(dep => dep.Faculty)
            .Select(d => new DirectionViewModel
            {
                Id = d.Id,
                Name = d.Name,
                Code = d.Code,
                MaxCourse = d.MaxCourse,
                DepartmentId = d.DepartmentId,
                DepartmentName = d.Department.Name,
                FacultyId = d.Department.FacultyId,
                FacultyName = d.Department.Faculty.Name
            })
            .ToList();
            
            bindingList = new BindingList<DirectionViewModel>(directions);
            dgv.DataSource = bindingList;
        }

        public static async Task SaveDirectionsAsync(
                List<DirectionViewModel> newDirectionList,
                List<DirectionViewModel> updatedDirectionList,
                List<DirectionViewModel> removedDirectionList)
        {
            using var ctx = new DatabaseContext();

            await AddNewDirectionsAsync(ctx, newDirectionList);
            await UpdateExistingDirectionsAsync(ctx, updatedDirectionList);
            await RemoveDirectionsAsync(ctx, removedDirectionList);

            await ctx.SaveChangesAsync();
        }

        private static async Task AddNewDirectionsAsync(
            DatabaseContext ctx,
            List<DirectionViewModel> newDirectionsList)
        {
            if (newDirectionsList.Count < 1)
            {
                return;
            }
            var newDirections = newDirectionsList.Select(d => new Direction
            {
                Id = Guid.NewGuid(),
                Name = d.Name,
                Code = d.Code,
                MaxCourse = d.MaxCourse,
                FacultyId = d.FacultyId,
                DepartmentId = d.DepartmentId
            }).ToList();

            await ctx.Direction.AddRangeAsync(newDirections);
        }

        private static async Task UpdateExistingDirectionsAsync(
            DatabaseContext ctx,
            List<DirectionViewModel> updatedDirections)
        {
            if (updatedDirections.Count < 1)
            {
                return;
            }
            var updatedIds = updatedDirections.Select(d => d.Id).ToList();
            var existingDirections = await ctx.Direction
                .Where(d => updatedIds.Contains(d.Id))
                .ToListAsync();

            foreach (var existingDirection in existingDirections)
            {
                var updatedDirection = updatedDirections.First(d => d.Id == existingDirection.Id);
                existingDirection.Name = updatedDirection.Name;
                existingDirection.Code = updatedDirection.Code;
                existingDirection.MaxCourse = updatedDirection.MaxCourse;
                existingDirection.FacultyId = updatedDirection.FacultyId;
                existingDirection.DepartmentId = updatedDirection.DepartmentId;
            }
        }

        private static async Task RemoveDirectionsAsync(
            DatabaseContext ctx, List<DirectionViewModel> removedDirections)
        {
            if (removedDirections.Count < 1)
            {
                return;
            }
            var removedIds = removedDirections.Select(d => d.Id).ToList();
            var directionsToRemove = await ctx.Direction
                .Where(d => removedIds.Contains(d.Id))
                .ToListAsync();

            ctx.Direction.RemoveRange(directionsToRemove);
        }

    }
}
