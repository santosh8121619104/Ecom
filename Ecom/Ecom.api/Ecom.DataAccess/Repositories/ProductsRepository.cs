using Ecom.DataAccess.Entities;
using Ecom.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.DataAccess.Repositories
{
    public class ProductsRepository : IProductRepository
    {
        private readonly IBaseRepository<Product> _baseRepository;

        public ProductsRepository(IBaseRepository<Product> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<Product> GetProductById(string productId)
        {
            return await _baseRepository.First(p => p.ProductId.Equals(productId));
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _baseRepository.List();
        }

        public async Task<bool> CreateProduct(Product product)
        {
            _baseRepository.Create(product);
            await _baseRepository.CommitAsync();
            return true;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var existingProduct = await GetProductById(product.ProductId);

            if (existingProduct != null)
            {
                _baseRepository.Update(product);

                await _baseRepository.CommitAsync();
               
            }
            return true;
        }

        public async Task<bool> DeleteProduct(string productId)
        {
            var product = await GetProductById(productId);
            if (product != null)
            {
                _baseRepository.Delete(product);
                await _baseRepository.CommitAsync();
               
            }
            return true;
        }
    }
}
