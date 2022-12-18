using StefansSuperShop.Data;
using StefansSuperShop.Models.Dtos;

namespace StefansSuperShop.Helpers;

public class Mapper : IMapper
{
    public Newsletters MapNewsletterDto(NewsletterDto newsletterDto)
    {
        return new Newsletters()
        {
            // create mapping class
            Content = newsletterDto.Content,
            NewsletterSent = newsletterDto.NewsletterSent,
            SubscribersWhoReceivedNewsletter = newsletterDto.SubscribersWhoReceivedNewsletter
        };
    }
}