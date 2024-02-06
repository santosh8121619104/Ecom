using Ecom.BusinessLayer.Interfaces;
using Ecom.DataAccess.Entities;
using Ecom.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.BusinessLayer.Services
{
    // ProductService.cs
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();

            return products;
        }

        public async Task<Product> GetProductById(string productId)
        {
            var product = await _productRepository.GetProductById(productId);

            return product;
        }

        public async Task<bool> AddProduct(Product product)
        {
         
          return  await _productRepository.CreateProduct(product);
        }

        public async Task <bool> UpdateProduct(Product product)
        {
            return await _productRepository.UpdateProduct(product);

        }

        public async Task<bool> DeleteProduct(string productId)
        {
           return await _productRepository.DeleteProduct(productId);

        }
    }

}
