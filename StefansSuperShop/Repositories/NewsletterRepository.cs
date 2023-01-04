using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StefansSuperShop.Data;


namespace StefansSuperShop.Repositories;

public class NewsletterRepository : INewsletterRepository
{
    private readonly ApplicationDbContext _dbContext;

    public NewsletterRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Newsletter> GetNewsletterAsync(int newsletterId)
    {
        return _dbContext.Newsletters.Include(x => x.SubscribersWhoReceivedNewsletter).FirstOrDefault(x => x.NewsLetterId == newsletterId);
    }
    
    public async Task<IEnumerable<Newsletter>> GetNewslettersAsync()
    {
        return _dbContext.Newsletters.Include(x => x.SubscribersWhoReceivedNewsletter);
    }

    public async Task CreateNewsletterAsync(Newsletter newsletter)
    {
        await _dbContext.Newsletters.AddAsync(newsletter);

        await _dbContext.SaveChangesAsync();
    }

    public async Task EditNewsletterAsync(Newsletter newsletter)
    {
        _dbContext.Update(newsletter);

        await _dbContext.SaveChangesAsync();
    }


    
}