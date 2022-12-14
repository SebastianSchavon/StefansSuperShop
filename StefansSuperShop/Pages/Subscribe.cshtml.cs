using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StefansSuperShop.Data;

namespace StefansSuperShop.Pages;

[IgnoreAntiforgeryToken]
public class Subscribe : PageModel
{
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<IdentityUser> _userManager;

    public Subscribe(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }
    

    public IActionResult OnPostSubscribe([FromBody]string emailAddress)
    {
        // // you might want to put all this logic in another method
        //
        // _dbContext.Subscribers.Add(new Subscribers
        // {
        //     EmailAddress = emailAddress
        // });
        //
        // var user = await _userManager.FindByEmailAsync(emailAddress);
        //
        // if (user != null)
        //     await _userManager.AddToRoleAsync(user, "Subscriber");

        return StatusCode(200);
    }

}