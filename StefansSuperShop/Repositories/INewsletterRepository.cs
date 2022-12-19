using System.Collections.Generic;
using System.Threading.Tasks;
using StefansSuperShop.Data;

namespace StefansSuperShop.Repositories;

public interface INewsletterRepository
{
    Newsletter GetNewsletter(int newsletterId);
    IEnumerable<Newsletter> GetNewsletters();
    Task CreateNewsletterAsync(Newsletter newsletter);
    Task EditNewsletterAsync(Newsletter newsletter);

}