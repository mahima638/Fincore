namespace FincoreCoreMvc.Models
{
    public interface IBudgets
    {
        Task<List<Budgets>> GetAll();
        Task<Budgets> GetById(int id);
        Task Add(Budgets budget);
        Task Update(Budgets budget);
        Task Delete(int id);
    }
}
