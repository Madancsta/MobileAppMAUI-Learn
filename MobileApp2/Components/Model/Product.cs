using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MobileApp2.Model
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Image URL is required")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(10, 100000, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [StringLength(200, ErrorMessage = "Description cannot exceed 200 characters")]
        public string Description { get; set; }
    }
}