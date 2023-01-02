using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StefansSuperShop.Data;
using static StefansSuperShop.Pages.IndexModel;
using System;
using System.Linq;
using static StefansSuperShop.Pages.Admin.ProductsModel;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace StefansSuperShop.Pages.Admin
{
    public class EditModel : PageModel
    {


        private readonly ApplicationDbContext _context;
        [BindProperty]
        public Products Product { get; set; }



        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Product = await _context.Products.FindAsync(id);



            if (Product == null)
            {
                return RedirectToPage("./Index");
            }



            return Page();
        }



        public async Task<IActionResult>  OnPost(int id)
        {

            
            if (!ModelState.IsValid)
            {
                return Page();
            }

           
            
            Product.published= DateTime.Now;
           
            _context.Attach(Product).State = EntityState.Modified;



            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception($"Product {Product.ProductId} not found!");
            }



            return RedirectToPage("./Products");
        }



    
    }
}
