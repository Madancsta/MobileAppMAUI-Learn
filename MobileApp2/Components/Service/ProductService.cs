using MobileApp2.Components.Service;
using MobileApp2.Model;
using System.Collections.Generic;
using System.Linq;

namespace MobileApp2.Services
{
    public class ProductService : IProductService
    {
        public Task AddProductAsync(Product product)
        {
            product.Id = ProductStore.Products.Count > 0
                ? ProductStore.Products.Max(p => p.Id) + 1
                : 1;

            ProductStore.Products.Add(product);
            return Task.CompletedTask;
        }

        public Task<List<Product>> GetProductsAsync()
        {
            return Task.FromResult(ProductStore.Products);
        }

        public Task<Product?> GetProductByIdAsync(int id)
        {
            var product = ProductStore.Products.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(product);
        }

        public Task<bool> UpdateProductAsync(Product product)
        {
            var existing = ProductStore.Products.FirstOrDefault(p => p.Id == product.Id);
            if (existing == null) return Task.FromResult(false);

            existing.Name = product.Name;
            existing.Price = product.Price;
            existing.Description = product.Description;
            existing.Image = product.Image;

            return Task.FromResult(true);
        }

        public Task<bool> DeleteProductAsync(int id)
        {
            var product = ProductStore.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return Task.FromResult(false);

            ProductStore.Products.Remove(product);
            return Task.FromResult(true);
        }
        //public void AddProduct(Product product)
        //{
        //    product.Id = ProductStore.Products.Count > 0
        //        ? ProductStore.Products.Max(p => p.Id) + 1
        //        : 1;

        //    ProductStore.Products.Add(product);
        //}

        //public List<Product> GetProducts()
        //{
        //    return ProductStore.Products;
        //}

        //public Product? GetProductById(int id)
        //{
        //    return ProductStore.Products.FirstOrDefault(p => p.Id == id);
        //}

        //public bool UpdateProduct(Product product)
        //{
        //    var existing = GetProductById(product.Id);
        //    if (existing == null) return false;

        //    existing.Name = product.Name;
        //    existing.Price = product.Price;
        //    existing.Description = product.Description;
        //    existing.Image = product.Image;

        //    return true;
        //}

        //public bool DeleteProduct(int id)
        //{
        //    var product = GetProductById(id);
        //    if (product == null) return false;

        //    ProductStore.Products.Remove(product);
        //    return true;
        //}
    }
}
