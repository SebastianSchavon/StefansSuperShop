using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StefansSuperShop.Data;
using StefansSuperShop.Repositories;
using StefansSuperShop.Services.EmailSender;

namespace StefansSuperShop.Pages.Admin;

[Authorize(Roles = "Admin")]
public class NewslettersModel : PageModel
{
    public List<Newsletter> Newsletters { get; set; }

    private readonly INewsletterRepository _newsletterRepository;
    private readonly ISubscriberRepository _subscriberRepository;
    private readonly IEmailSenderService _emailSenderService;

    public NewslettersModel(INewsletterRepository newsletterRepository, ISubscriberRepository subscriberRepository,
        IEmailSenderService emailSenderService)
    {
        _newsletterRepository = newsletterRepository;
        _subscriberRepository = subscriberRepository;
        _emailSenderService = emailSenderService;
    }

    public async void OnGet()
    {
        var newsletters = await _newsletterRepository.GetNewslettersAsync();

        Newsletters = newsletters.ToList();
    }

    public async Task<IActionResult> OnPostSendNewsletter(int newsletterId)
    {
        var newsletter = await _newsletterRepository.GetNewsletterAsync(newsletterId);
        
        var subscribers = await _subscriberRepository.GetSubscribers();

        foreach (var subscriber in subscribers)
        {
            _emailSenderService.SendEmail("stefan@newsletter.com", newsletter.Title, newsletter.Content);
            newsletter.SubscribersWhoReceivedNewsletter.Add(subscriber);
            subscriber.ReceivedNewsletters.Add(newsletter);
        }

        newsletter.NewsletterSent = true;

        await _newsletterRepository.EditNewsletterAsync(newsletter);

        return Redirect("./Newsletters");
    }

}