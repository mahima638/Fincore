using FincoreCoreMvc.Models;

namespace FincoreCoreMvc.Interface
{
    public interface IUserService
    {
        Task AddUser(User u);
        Task<List<User>> GetUser();

        Task DeleteUser(int id);

        Task EditUser(User u);

        Task<User> GetUserById(int id);
    }
}
