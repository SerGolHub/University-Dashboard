using Database;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using University_Dasboard.Database.Models;
using static University_Dasboard.FrmGroups;

namespace University_Dasboard.Controllers
{
    public class GroupController
    {
        public static void LoadGroups(
            DataGridView dgv,
            ref BindingList<GroupViewModel> bindingList)
        {
            using var ctx = new DatabaseContext();
            var groups = ctx.Group
            .Include(g => g.Direction)
            .ThenInclude(dir => dir!.Department) // dir! означает, что dir не может быть null
            .ThenInclude(dep => dep!.Faculty)
            .Select(g => new GroupViewModel
            {
                Id = g.Id,
                Name = g.Name,
                CourseNumber = g.CourseNumber,
                DirectionId = g.DirectionId,
                DirectionName = g.Direction!.Name,
            })
            .ToList();

            bindingList = new BindingList<GroupViewModel>(groups);
            dgv.DataSource = bindingList;
        }

        public static async Task SaveGroupsAsync(
                List<GroupViewModel> newGroupList,
                List<GroupViewModel> updatedGroupList,
                List<GroupViewModel> removedGroupList)
        {
            using var ctx = new DatabaseContext();

            await AddNewGroupsAsync(ctx, newGroupList);
            await UpdateExistingGroupsAsync(ctx, updatedGroupList);
            await RemoveGroupsAsync(ctx, removedGroupList);

            await ctx.SaveChangesAsync();
        }

        private static async Task AddNewGroupsAsync(
            DatabaseContext ctx,
            List<GroupViewModel> newGroupList)
        {
            if (newGroupList.Count < 1)
            {
                return;
            }
			var newGroups = newGroupList.Select(g => new Group
            {
                Id = g.Id,
                Name = g.Name,
				CourseNumber = g.CourseNumber,
				DirectionId = g.DirectionId,
            }).ToList();

            await ctx.Group.AddRangeAsync(newGroups);
        }

        private static async Task UpdateExistingGroupsAsync(
            DatabaseContext ctx,
            List<GroupViewModel> updatedGroups)
        {
            if (updatedGroups.Count < 1)
            {
                return;
            }
            var updatedIds = updatedGroups.Select(g => g.Id).ToList();
            var existingGroups = await ctx.Group
                .Where(g => updatedIds.Contains(g.Id))
                .ToListAsync();

            foreach (var existingGroup in existingGroups)
            {
                var updatedGroup = updatedGroups.First(g => g.Id == existingGroup.Id);
                existingGroup.Name = updatedGroup.Name;
                existingGroup.DirectionId = updatedGroup.DirectionId;
                existingGroup.CourseNumber = updatedGroup.CourseNumber;
            }
        }

        private static async Task RemoveGroupsAsync(
            DatabaseContext ctx, List<GroupViewModel> removedGroups)
        {
            if (removedGroups.Count < 1)
            {
                return;
            }
            var removedIds = removedGroups.Select(g => g.Id).ToList();
            var groupsToRemove = await ctx.Group
                .Where(g => removedIds.Contains(g.Id))
                .ToListAsync();

            ctx.Group.RemoveRange(groupsToRemove);
        }
    }
}
