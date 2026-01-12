using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileApp2.Model;

namespace MobileApp2.Components.Service
{
    internal interface IProductService
    {
        //Task AddProductAsync(Product product);
        //Task<List<Product>> GetProductsAsync();
        //Task<Product?> GetProductByIdAsync(int id);
        //Task<bool> UpdateProductAsync(Product product);
        //Task<bool> DeleteProductAsync(int id);
        void AddProduct(Product product);
        List<Product> GetProducts();
        Product? GetProductById(int id);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int id);
    }
}
