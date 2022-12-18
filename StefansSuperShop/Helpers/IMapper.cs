using StefansSuperShop.Data;
using StefansSuperShop.Models.Dtos;

namespace StefansSuperShop.Helpers;

public interface IMapper
{
    Newsletters MapNewsletterDto(NewsletterDto newsletterDto);
}