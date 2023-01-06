using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StefansSuperShop.Data;

namespace StefansSuperShop.Pages
{
    public class IndexController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEnumerable<Products> _products;
        public IndexController(ApplicationDbContext context, IEnumerable<Products> products)
        {
            _context = context;
            _products = products;
        }

        public IActionResult Index()
        {

            return View(_products);
        }
    }
}
