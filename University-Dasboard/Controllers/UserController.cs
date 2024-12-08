using Database;
using Microsoft.EntityFrameworkCore;

namespace University_Dasboard.Controllers
{
    public class UserController
    {
        public static async Task<bool> IsUserExistsAsync(string login)
        {
            using var ctx = new DatabaseContext();
            return await ctx.User.AnyAsync(u => u.Login == login);
        }
        public static async Task<User?> GetUserAsync(string login)
        {
            using var ctx = new DatabaseContext();
            return await ctx.User.FirstOrDefaultAsync(u => u.Login == login);
        }

        public static async Task AddUserAsync(string login, string password, string fullName)
        {
            string passwordHash = PasswordSecurity.getHash(password);
            User newUser = new User
            {
                Login = login,
                PasswordHash = passwordHash,
                FullName = fullName
            };
            using var ctx = new DatabaseContext();
            ctx.User.Add(newUser);
            await ctx.SaveChangesAsync();
        }

        //public static async Task UpdateUserAsync(string login, string password)
        //{

        //}

        public static async Task DeleteUserAsync(string login)
        {
            using var ctx = new DatabaseContext();
            User user = await ctx.User.FirstAsync(u => u.Login == login);
            ctx.User.Remove(user);
            await ctx.SaveChangesAsync();
        }
    }
}
