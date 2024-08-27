using FirstStaticWeb.Data;
using FirstStaticWeb.Interface;
using FirstStaticWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace FirstStaticWeb.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public readonly AccountDbContext _dbContext;
        public AccountRepository(AccountDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ActionResult<UserModel>> RegisterUser(UserModel user)
        {
           
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }


        public async Task<UserModel> LoginAsync(LoginModel login)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Email == login.Email && x.Password == login.Password);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }
            return user;
        }
    }
}
