using StefansSuperShop.Data;
using StefansSuperShop.Models.Dtos;

namespace StefansSuperShop.Helpers;

public interface IMapper
{
    Newsletter MapNewsletterForCreation(NewsletterDto newsletterDto);
}