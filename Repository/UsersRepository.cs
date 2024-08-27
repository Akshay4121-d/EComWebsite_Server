using FirstStaticWeb.Data;
using FirstStaticWeb.Interface;
using FirstStaticWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstStaticWeb.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly AccountDbContext _dbContext;
        public UsersRepository(AccountDbContext dbContext)
        {
            _dbContext = dbContext;
        }
      
        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> AddUserAsync(UserModel userModel) 
        {
            if (userModel == null)
            {
                throw new Exception("Invalid Data ");
            }
            try
            {
                _dbContext.Users.Add(userModel);
                await _dbContext.SaveChangesAsync();
                return userModel;
            }
            catch(Exception ex) 
            {
                throw new Exception("An error occurred while adding the User", ex);
            } 
        }

        public async Task<UserModel> UpdateUserAsync(UserModel userModel,int id)
        {
            UserModel user = _dbContext.Users.SingleOrDefault(e=>e.Id == id);
            if (user != null)
            {
                user.Name = userModel.Name;
                user.MobNumber = userModel.MobNumber;
                user.Address = userModel.Address;
                user.Password = userModel.Password;
                user.Gender= userModel.Gender;
                user.Age = userModel.Age;
                user.AgreeTerms = userModel.AgreeTerms;
                user.Email= userModel.Email;
                user.Role = userModel.Role;
                await _dbContext.SaveChangesAsync();
            }
            return userModel;
        }
        
        public async Task<UserModel> DeleteUserAsync(int id)
        {
            UserModel user = await _dbContext.Users.SingleOrDefaultAsync(e => e.Id == id);
            if (user == null)
            {
                return null;
            }

            _dbContext.Users.Remove(user);

            await _dbContext.SaveChangesAsync();
            return user;
        }

    }
}
