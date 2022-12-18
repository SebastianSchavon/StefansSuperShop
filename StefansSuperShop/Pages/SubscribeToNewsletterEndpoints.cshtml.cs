using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StefansSuperShop.Data;
using Index = Microsoft.EntityFrameworkCore.Metadata.Internal.Index;

namespace StefansSuperShop.Pages;

[IgnoreAntiforgeryToken]
public class SubscribeToNewsletterEndpoints : PageModel
{
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<IdentityUser> _userManager;

    public SubscribeToNewsletterEndpoints(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }
    

    public async Task<IActionResult> OnPostSubscribe(string emailAddress)
    {
        var validateEmailRegex = new Regex("^\\S+@\\S+\\.\\S+$");

        if (emailAddress == null || !validateEmailRegex.IsMatch(emailAddress))
            return BadRequest("Enter valid email address" );

        await _dbContext.Subscribers.AddAsync(new Subscribers
        {
            EmailAddress = emailAddress
        });
        
        var user = await _userManager.FindByEmailAsync(emailAddress);
        
        if (user != null)
            await _userManager.AddToRoleAsync(user, "Subscriber");
        
        return Content("Thank you!");
    }

}