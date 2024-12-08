using Database;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using University_Dasboard.Interfaces;

namespace University_Dasboard
{
    public class DatabaseController
    {
        public static BindingList<T> FillBindingList<T>() where T : class
        {
            using var ctx = new DatabaseContext();
            var entitiesList = ctx.Set<T>().ToList();
            var bindingList = new BindingList<T>();
            foreach (var entity in entitiesList)
            {
                bindingList.Add(entity);
            }
            return bindingList;
        }

        public static async Task AddToDatabaseAsync<T>(List<T> entities) where T : class
        {
            using var ctx = new DatabaseContext();
            await ctx.Set<T>().AddRangeAsync(entities);
            await ctx.SaveChangesAsync();
        }

        public static async Task UpdateDatabaseAsync<T>(List<T> updatedEntitiesList) where T : class, IEntity
        {
            using var ctx = new DatabaseContext();
            var updatedEntityIds = updatedEntitiesList.Select(e => e.Id).ToList();
            var existingEntities = await ctx.Set<T>()
                    .Where(e => updatedEntityIds.Contains(e.Id))
                    .ToListAsync();
            foreach (var entity in updatedEntitiesList)
            {
                var existingEntity = existingEntities.FirstOrDefault(e => e.Id == entity.Id);
                if (existingEntity != null)
                {
                    existingEntity.Name = entity.Name;
                }
            }
        }

        public static async Task DeleteFromDatabaseAsync<T>(List<T> removedEntitiesList) where T : class
        {
            using var ctx = new DatabaseContext();
            ctx.Set<T>().RemoveRange(removedEntitiesList);
            await ctx.SaveChangesAsync();
        }
    }
}
