using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StefansSuperShop.Data;
using StefansSuperShop.ViewModels;

namespace StefansSuperShop.Pages.Components;

public class NewsletterViewComponent : ViewComponent
{
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<IdentityUser> _userManager;

    public NewsletterViewComponent(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }

    public async Task<IViewComponentResult> Invoke(string emailAddress)
    {
        // you might want to put all this logic in another method
        
        _dbContext.Subscribers.Add(new Subscribers
        {
            EmailAddress = emailAddress
        });

        var user = await _userManager.FindByEmailAsync(emailAddress);

        if (user != null)
            await _userManager.AddToRoleAsync(user, "Subscriber");
        
        return View(new NewsletterViewModel());
    }
}