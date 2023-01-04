using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StefansSuperShop.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace StefansSuperShop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public List<TrendingCategory> TrendingCategories { get; set; }
        public class TrendingCategory
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        
        public List<Product> NewProducts { get; set; }
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal? Price { get; set; }
            public string Category { get; set; }
        }

        public List<Category> Categories { get; set; }
        public class Category
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public void OnGet()
        {
            TrendingCategories = _context.Categories.Take(3).Select(c =>
                new TrendingCategory { Id = c.CategoryId, Name = c.CategoryName })
                .ToList();
        }

        public List<Product> GetNewProducts()
        {
            var products = _context.Products.Join(_context.Categories, p => p.CategoryId, c => c.CategoryId,
                (p, c) => new Product { Id = p.ProductId, Name = p.ProductName, Price = p.UnitPrice, Category = c.CategoryName }).ToList();

            var newList = products.OrderByDescending(p => p.Id).Take(10).ToList();
            NewProducts = newList;

            return NewProducts;
        }

        public List<Category> GetCategories()
        {
            Categories = _context.Categories.Select(c => 
                new Category { Id = c.CategoryId, Name = c.CategoryName })
                .ToList();

            return Categories;
        }

        public List<Product> GetProductsByCategory(string cat)
        {
            var products = _context.Products.Join(_context.Categories, p => p.CategoryId, c => c.CategoryId,
                (p, c) => new Product { Id = p.ProductId, Name = p.ProductName, Price = p.UnitPrice, Category = c.CategoryName }).ToList();

            var newList = products.Where(x => x.Category == cat).OrderByDescending(p => p.Id).Take(10).ToList();
            NewProducts = newList;

            return NewProducts;
        }
    }
}
