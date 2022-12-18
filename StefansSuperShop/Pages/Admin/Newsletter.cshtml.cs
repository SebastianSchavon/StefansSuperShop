using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StefansSuperShop.Data;
using StefansSuperShop.Repositories.Newsletter;

namespace StefansSuperShop.Pages.Admin;

public class NewsletterModel : PageModel
{
    private readonly INewsletterRepository _newsletterRepository;

    public NewsletterModel(INewsletterRepository newsletterRepository)
    {
        _newsletterRepository = newsletterRepository;
    }
    
    public void OnGet()
    {
        
    }
    
    // pass id of newsletter to send
    // check if newsletter is already sent
    public async Task SendNewsletterAsync(string newsletterId)
    {
        
    }

    public async Task<IEnumerable<Newsletters>> GetSentNewslettersAsync()
    {
        var sentNewsletters = await _newsletterRepository.GetNewsletters();

        return sentNewsletters.Where(x => x.NewsletterSent);
    }
}