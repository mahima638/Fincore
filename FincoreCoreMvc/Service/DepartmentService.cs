using FincoreCoreMvc.Data;
using FincoreCoreMvc.Interface;
using FincoreCoreMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace FincoreCoreMvc.Service
{
    public class DepartmentService : IDepartmentService

    {
        private readonly AppDbContext db;
        public DepartmentService(AppDbContext db)
        {
            this.db = db;
        }
        public async Task AddDepartment(Department d)
        {
            db.department.Add(d);
            await db.SaveChangesAsync();
        }

        public async Task DeleteDepartment(int id)
        {
            var did = await db.department.FindAsync(id);
            db.department.Remove(did);
        }

        public async Task EditDepartment(Department d)
        {
            db.department.Update(d);
            await db.SaveChangesAsync();
        }

        public async Task<List<Department>> GetDepartment()
        {
            var departments = await db.department.ToListAsync();
            return departments;
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            return await db.department.FindAsync(id);
        }
    }
}
