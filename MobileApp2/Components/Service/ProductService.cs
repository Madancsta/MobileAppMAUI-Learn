using MobileApp2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp2.Components.Service
{
    internal class ProductService
    {
        // CREATE
        public void AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            // Auto-generate Id
            product.Id = ProductStore.Products.Count > 0
                ? ProductStore.Products.Max(p => p.Id) + 1
                : 1;

            ProductStore.Products.Add(product);
        }

        // READ - All Products
        public List<Product> GetProducts()
        {
            return ProductStore.Products;
        }

        // READ - By Id
        public Product GetProductById(int id)
        {
            return ProductStore.Products.FirstOrDefault(p => p.Id == id);
        }

        // UPDATE
        public bool UpdateProduct(Product updatedProduct)
        {
            if (updatedProduct == null)
                return false;

            var existingProduct = GetProductById(updatedProduct.Id);

            if (existingProduct == null)
                return false;

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Image = updatedProduct.Image;
            existingProduct.Price = updatedProduct.Price;
            existingProduct.Description = updatedProduct.Description;

            return true;
        }

        // DELETE
        public bool DeleteProduct(int id)
        {
            var product = GetProductById(id);

            if (product == null)
                return false;

            ProductStore.Products.Remove(product);
            return true;
        }
    }
}
