using FincoreCoreMvc.Data;
using FincoreCoreMvc.Interface;
using FincoreCoreMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace FincoreCoreMvc.Service
{
    public class UserService : IUserService
    {
        private readonly AppDbContext db;
        public UserService(AppDbContext db)
        {
            this.db = db;
            
        }
        public async Task AddUser(User u)
        {
            db.Users.Add(u);
            await db.SaveChangesAsync();

        }

        public async Task DeleteUser(int id)
        {
            var uid = await db.Users.FindAsync(id);
            db.Users.Remove(uid);
        }

        public async Task EditUser(User u)
        {
            db.Users.Update(u);
            await db.SaveChangesAsync();
        }

        public async Task<List<User>> GetUser()
        {
            var users = await db.Users.ToListAsync();
            return users;

        }

        public async Task<User> GetUserById(int id)
        {
            return await db.Users.FindAsync(id);
        }
    }
}
