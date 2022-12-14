using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace StefansSuperShop.Data;

public class BaseController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<IdentityUser> _userManager;

    public BaseController(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
        
    }
    [HttpPost]
    public async Task<IActionResult> Test(string emailAddress)
    {
        // you might want to put all this logic in another method
        
        _dbContext.Subscribers.Add(new Subscribers
        {
            EmailAddress = emailAddress
        });

        var user = await _userManager.FindByEmailAsync(emailAddress);

        if (user != null)
            await _userManager.AddToRoleAsync(user, "Subscriber");

        return LocalRedirect("https://localhost:5001");
    }
}