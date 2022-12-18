using System.Collections.Generic;
using System.Threading.Tasks;
using StefansSuperShop.Data;
using StefansSuperShop.Models.Dtos;

namespace StefansSuperShop.Repositories.Newsletter;

public interface INewsletterRepository
{
    Task<IEnumerable<Newsletters>> GetNewsletters();
    Task CreateNewsletterAsync(NewsletterDto newsletterDto);
    Task EditNewsletterAsync(string newsletterId);

}