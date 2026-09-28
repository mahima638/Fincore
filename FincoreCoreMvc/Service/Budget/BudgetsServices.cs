using FincoreCoreMvc.Data;
using FincoreCoreMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace FincoreCoreMvc.Service.Budget
{
    public class BudgetsServices : IBudgets
    {
        private readonly AppDbContext db;

        public BudgetsServices(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<List<Budgets>> GetAll()
        {
            var data = await db.Budgets.Include(x => x.BudgetCategory).ToListAsync();
            return data;
        }

        public async Task<Budgets> GetById(int id)
        {
            var data = await db.Budgets.Include(x => x.BudgetCategory)
                          .FirstOrDefaultAsync(x => x.Budget_Id == id);
            return data;
        }

        public async Task Add(Budgets budget)
        {
            await db.Budgets.AddAsync(budget);
            await db.SaveChangesAsync();
        }

        public async Task Update(Budgets budget)
        {
            db.Budgets.Update(budget);
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var budget = await db.Budgets.FindAsync(id);

            if (budget != null)
            {
                db.Budgets.Remove(budget);
                await db.SaveChangesAsync();
            }
        }
    }
}

