using FirstStaticWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstStaticWeb.Interface
{
    public interface IAccountRepository
    {
       
        Task<ActionResult<UserModel>> RegisterUser(UserModel user);
        Task<UserModel> LoginAsync(LoginModel login);
    }
}
