using Ecom.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.BusinessLayer.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(string productId);
        Task<bool> AddProduct(Product productDto);
        Task<bool> UpdateProduct(Product productDto);
        Task<bool> DeleteProduct(string productId);
    }
}
