using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StefansSuperShop.Data;
using System;
using System.Linq;

namespace StefansSuperShop.Pages.Admin
{
    public class createproductModel : PageModel
    {
        private readonly ApplicationDbContext _context;


        public createproductModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            var productName = Convert.ToString(Request.Form["productName"]);
            var unitPrice = Convert.ToDecimal(Request.Form["unitPrice"]);
            var unitsInStock = Convert.ToInt16(Request.Form["unitsInStock"]);
            var Rating = Convert.ToUInt16(Request.Form["rating"]);
            var categoryid = Convert.ToUInt16(Request.Form["categoryid"]);
            //var publish = Convert.ToDateTime(Request.Form["publish"]);
            var CampingPrice = Convert.ToDecimal(Request.Form["campingprice"]);



            if (!_context.Products.Any(n => n.ProductName == productName))
            {
                _context.Products.Add(new Products
                {
                    ProductName = productName,
                    UnitPrice = unitPrice,
                    UnitsInStock = unitsInStock,
                    published = DateTime.Now,
                    Rating = Rating,
                    CategoryId = categoryid,
                    CampingPrice = CampingPrice,
                }) ;
                _context.SaveChanges();
            }
        }
    }
}

