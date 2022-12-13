using Microsoft.AspNetCore.Mvc;
using StefansSuperShop.ViewModels;

namespace StefansSuperShop.Pages.Components;

public class NewsletterViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(string emailAddress)
    {
        
        return View(new NewsletterViewModel());
    }
}