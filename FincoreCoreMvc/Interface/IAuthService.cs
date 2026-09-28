using FincoreCoreMvc.Models;

namespace FincoreCoreMvc.Interface
{
    public interface IAuthService
    {
        User Login(string email, string password);
    }
}
