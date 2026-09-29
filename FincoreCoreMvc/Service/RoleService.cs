using FincoreCoreMvc.Data;
using FincoreCoreMvc.Interface;
using FincoreCoreMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace FincoreCoreMvc.Service
{
    public class RoleService : IRoleService

    {
        private protected AppDbContext db;
        public RoleService(AppDbContext db)
        {
            this.db = db;
        }
        public async Task AddRole(Role r)
        {
            db.role.Add(r);
            await db.SaveChangesAsync();
        }

        public async Task DeleteRole(int id)
        {
           var rid = await db.role.FindAsync(id);
            db.role.Remove(rid);
          
        }

        public async Task EditRole(Role r)
        {
            db.role.Update(r);
            await db.SaveChangesAsync();
        }

        public async Task<List<Role>> GetRole()
        {
            var roles = await db.role.ToListAsync();
            return roles;
        }

        public async Task<Role> GetRoleById(int id)
        {
            return await db.role.FindAsync(id);
        }
    }
}
