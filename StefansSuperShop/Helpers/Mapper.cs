using StefansSuperShop.Data;
using StefansSuperShop.Models.Dtos;

namespace StefansSuperShop.Helpers;

public class Mapper : IMapper
{
    public Newsletter MapNewsletterForCreation(NewsletterDto newsletterDto)
    {
        return new Newsletter()
        {
            Content = newsletterDto.Content,
            Title = newsletterDto.Title, 
            NewsletterSent = newsletterDto.NewsletterSent,
            SubscribersWhoReceivedNewsletter = newsletterDto.SubscribersWhoReceivedNewsletter
        };
    }
    

}