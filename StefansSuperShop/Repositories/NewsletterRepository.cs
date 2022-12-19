using System.Collections.Generic;
using System.Threading.Tasks;
using StefansSuperShop.Data;


namespace StefansSuperShop.Repositories;

public class NewsletterRepository : INewsletterRepository
{
    private readonly ApplicationDbContext _dbContext;

    public NewsletterRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Newsletter GetNewsletter(int newsletterId)
    {
        return _dbContext.Newsletters.Find(newsletterId);
    }
    
    public IEnumerable<Newsletter> GetNewsletters()
    {
        return _dbContext.Newsletters;
    }
    
    // dont send email after creation, just add to database as "not sent" 
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