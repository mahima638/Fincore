using FincoreCoreMvc.Data;
using FincoreCoreMvc.Interface;
using FincoreCoreMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FincoreCoreMvc.Service
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext db;
        public AuthService(AppDbContext db)
        {
            this.db = db;
        }
        public User Login(string email, string password)
        {
            var user = db.Users.Include(x => x.role).FirstOrDefault(x =>
             x.email == email &&
             x.pass == password &&
             x.is_active == 1
            );
            return user;
        }

        
    }
}
