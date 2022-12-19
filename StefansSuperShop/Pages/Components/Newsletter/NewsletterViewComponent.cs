using System.Linq;
using System.Security.Principal;
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

    public IViewComponentResult Invoke()
    {
        return View(new SubscribeToNewsletterViewModel());
    }

    public bool IsInAnyRole(IPrincipal principal, params string[] roles)
    {
        return roles.Any(principal.IsInRole);
    }
    
    public async Task AddSubscriber(string emailAddress)
    {
        // you might want to put all this logic in another method
        
        _dbContext.Subscribers.Add(new Subscriber
        {
            EmailAddress = emailAddress
        });

        var user = await _userManager.FindByEmailAsync(emailAddress);

        if (user != null)
            await _userManager.AddToRoleAsync(user, "Subscriber");
    

    }
}