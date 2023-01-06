using System.Collections.Generic;
using System.Threading.Tasks;
using StefansSuperShop.Data;

namespace StefansSuperShop.Repositories;

public interface INewsletterRepository
{
    Task<Newsletter> GetNewsletterAsync(int newsletterId);
    Task<IEnumerable<Newsletter>> GetNewslettersAsync();
    Task CreateNewsletterAsync(Newsletter newsletter);
    Task EditNewsletterAsync(Newsletter newsletter);

}