using Ecom.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.DataAccess.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductById(string productId);
        Task<List<Product>> GetAllProducts();
        Task<bool> CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(string productId);
    }
}
