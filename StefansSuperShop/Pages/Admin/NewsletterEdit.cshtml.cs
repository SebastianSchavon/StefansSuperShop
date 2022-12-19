﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StefansSuperShop.Data;
using StefansSuperShop.Repositories;

namespace StefansSuperShop.Pages.Admin;

public class NewsletterEditModel : PageModel
{
    [BindProperty]
    public Newsletter Newsletter { get; set; }
    
    private readonly INewsletterRepository _newsletterRepository;

    public NewsletterEditModel(INewsletterRepository newsletterRepository)
    {
        _newsletterRepository = newsletterRepository;
    }
    
    public void OnGet(int newsletterId)
    {
        Newsletter = _newsletterRepository.GetNewsletter(newsletterId);
        
        Console.WriteLine(Newsletter);
    }

    public async Task<IActionResult> OnPostEditNewsletter()
    {
        Newsletter.CreatedDate = DateTime.Now;
        
        await _newsletterRepository.EditNewsletterAsync(Newsletter);

        return Redirect("./Newsletters");
    }
}