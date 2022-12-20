using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StefansSuperShop.Data;
using StefansSuperShop.Repositories;

namespace StefansSuperShop.Pages.Admin;

[Authorize(Roles = "Admin")]
public class NewsletterCreateModel : PageModel
{
    [BindProperty]
    public Newsletter Newsletter { get; set; }
    
    private readonly INewsletterRepository _newsletterRepository;

    public NewsletterCreateModel(INewsletterRepository newsletterRepository)
    {
        _newsletterRepository = newsletterRepository;
    }
    
    public void OnGet()
    {
    }
    
    public async Task<IActionResult> OnPostCreateNewsletter()
    {
        Newsletter.CreatedDate = DateTime.Now;
        Newsletter.NewsletterSent = false;
        
        await _newsletterRepository.CreateNewsletterAsync(Newsletter);

        return Redirect("./Newsletters");
    }
}