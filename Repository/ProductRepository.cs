using FirstStaticWeb.Data;
using FirstStaticWeb.Interface;
using FirstStaticWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstStaticWeb.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AccountDbContext _productDbContext;
        public ProductRepository(AccountDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }
    
        public async Task<IEnumerable<productModel>> GetAllProductsAsync()
        {
            return await _productDbContext.Products.ToListAsync();
        }
        public async Task<productModel> GetProductAsync(int id)
        {
            var product = await _productDbContext.Products.FindAsync(id);
            if (product == null)
            {
                throw new Exception("Product Not found");
            }
            return product;
        }

        public async Task<object> UpdateProductAsync(int id, productModel product)
        {
            //var productDetail = _productDbContext.Products.FindAsync(id);
            productModel productDetail = await _productDbContext.Products.SingleOrDefaultAsync(x=>x.Id == id);

            if (productDetail != null)
            {
                productDetail.Name = product.Name;
                productDetail.Description = product.Description;
                productDetail.Category = product.Category;
                productDetail.Price = product.Price;
                productDetail.StockQuantity = product.StockQuantity;
                productDetail.IsActive = product.IsActive;
                productDetail.Status = product.Status;
                await _productDbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return true;
            }     
        }

        public async Task<object> DeleteProductAsync(int id)
        { 
            productModel product = await _productDbContext.Products.SingleOrDefaultAsync(x=>x.Id == id);  
            product.IsActive = product.IsActive== true? false: true;
            await _productDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<productModel> AddProductAsync(productModel product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product data is null.");
            }

            try
            {
                await _productDbContext.Products.AddAsync(product);
                await _productDbContext.SaveChangesAsync();
                return product;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception("An error occurred while adding the product to the database.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred.", ex);
            }
        }
    }
}
