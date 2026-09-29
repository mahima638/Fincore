using FincoreCoreMvc.Models;

namespace FincoreCoreMvc.Interface
{
    public interface IRoleService
    {
        Task AddRole(Role r);
        Task<List<Role>> GetRole();

        Task DeleteRole(int id);

        Task EditRole(Role r);

        Task<Role> GetRoleById(int id);
    }
}
