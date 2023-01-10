using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StefansSuperShop.Data;
using StefansSuperShop.Repositories;
using Index = Microsoft.EntityFrameworkCore.Metadata.Internal.Index;

namespace StefansSuperShop.Pages;

[IgnoreAntiforgeryToken]
public class SubscribeToNewsletterEndpoints : PageModel
{
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly ISubscriberRepository _subscriberRepository;

    public SubscribeToNewsletterEndpoints(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ISubscriberRepository subscriberRepository)
    {
        _dbContext = dbContext;
        _userManager = userManager;
        _signInManager = signInManager;
        _subscriberRepository = subscriberRepository;
    }
    

    public async Task<IActionResult> OnPostSubscribe(string emailAddress)
    {
        var validateEmailRegex = new Regex("^\\S+@\\S+\\.\\S+$");

        if (emailAddress == null || !validateEmailRegex.IsMatch(emailAddress))
            return BadRequest("Enter valid email address" );

        if (await _subscriberRepository.GetSubscriberAsync(emailAddress) != null)
            return BadRequest("Email already subscribed");
        
        await _subscriberRepository.CreateSubscriberAsync(new Subscriber
        {
            EmailAddress = emailAddress,
            ReceivedNewsletters = new List<Newsletter>()
        });
        
        var user = await _userManager.FindByEmailAsync(emailAddress);
        
        if (user != null)
            await _userManager.AddToRoleAsync(user, "Subscriber");

        return Content("Thank you!");
    }

}