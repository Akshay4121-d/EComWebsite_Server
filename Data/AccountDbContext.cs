using FirstStaticWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstStaticWeb.Data
{
    public class AccountDbContext :DbContext
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options) { }


        public DbSet<UserModel> Users { get; set; }
        public DbSet<productModel> Products { get; set; }

    }
}
