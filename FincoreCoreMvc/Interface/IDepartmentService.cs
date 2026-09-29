using FincoreCoreMvc.Models;

namespace FincoreCoreMvc.Interface
{
    public interface IDepartmentService
    {
        Task AddDepartment(Department d);
        Task<List<Department>> GetDepartment();

        Task DeleteDepartment(int id);

        Task EditDepartment(Department d);

        Task<Department> GetDepartmentById(int id);
    }
}
