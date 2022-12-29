﻿using Microsoft.AspNetCore.Mvc;
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


        public class TrendingCategory
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public List<TrendingCategory> TrendingCategories { get; set; }

        public List<Product> NewProducts { get; set; }

        public class Product
        {
            public string Category { get; set; }
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal? Price { get; set; }
        }
        public List<Category> Categories { get; set; }
        public class Category
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            TrendingCategories = _context.Categories.Take(3).Select(c =>
                new TrendingCategory { Id = c.CategoryId, Name = c.CategoryName }
            ).ToList();
        }
        public List<Category> GetCategories()
        {
            Categories = _context.Categories.Select(c =>
                new Category { Id = c.CategoryId, Name = c.CategoryName }
            ).ToList();
            return Categories;
        }
        

        public ApplicationDbContext Get_context()
        {
            return _context;
        }

        public List<Product> GetNewProducts()
        {
            NewProducts = _context.Products.OrderByDescending(p => p.ProductId).Take(10)
                .Select(p => new Product { Id = p.ProductId, Name = p.ProductName, Price = p.UnitPrice})
                .ToList();
            return NewProducts;
        }
    }
}
