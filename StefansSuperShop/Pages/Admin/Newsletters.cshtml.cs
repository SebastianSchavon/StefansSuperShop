using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StefansSuperShop.Data;
using StefansSuperShop.Repositories;
using StefansSuperShop.Services.EmailSender;

namespace StefansSuperShop.Pages.Admin;

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
        var newsletters = _newsletterRepository.GetNewsletters();

        Newsletters = newsletters.ToList();
    }

    // pass id of newsletter to send
    // check if newsletter is already sent
    public async Task OnPostSendNewsletter(int newsletterId)
    {
        var newsletter = _newsletterRepository.GetNewsletter(newsletterId);

        if (newsletter.NewsletterSent) ;
        // display message that tells admin that the newsletter is already sent? send again?

        var subscribers = await _subscriberRepository.GetSubscribers();

        foreach (var subscriber in subscribers)
        {
            _emailSenderService.SendEmail("stefan@newsletter.com", newsletter.Title, newsletter.Content);
            newsletter.SubscribersWhoReceivedNewsletter.Add(subscriber);
        }

        newsletter.NewsletterSent = true;

        await _newsletterRepository.EditNewsletterAsync(newsletter);
    }

    // public async Task<IEnumerable<Newsletter>> GetSentNewsletters()
    // {
    //     var sentNewsletters = _newsletterRepository.GetNewsletters();
    //
    //     return sentNewsletters.Where(x => x.NewsletterSent);
    // }
}