using FirstStaticWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstStaticWeb.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<productModel>> GetAllProductsAsync();
        Task<productModel> GetProductAsync(int id);
        Task<productModel> AddProductAsync(productModel product);
        Task<object> UpdateProductAsync(int id,productModel product);
        Task<object> DeleteProductAsync(int id);

    }
}
