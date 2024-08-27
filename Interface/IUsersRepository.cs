using FirstStaticWeb.Models;

namespace FirstStaticWeb.Interface
{
    public interface IUsersRepository
    {
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
        Task<UserModel> AddUserAsync(UserModel userModel);
        Task<UserModel> UpdateUserAsync(UserModel userModel,int id);
        Task<UserModel> DeleteUserAsync(int id);
    }
}
