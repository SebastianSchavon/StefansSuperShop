using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StefansSuperShop.Data;

namespace StefansSuperShop.Repositories;

public class SubscriberRepository : ISubscriberRepository
{
    private readonly ApplicationDbContext _dbContext;

    public SubscriberRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Subscriber>> GetSubscribers()
    {
        return _dbContext.Subscribers.Include(x => x.ReceivedNewsletters);
    }
    
    public async Task<Subscriber> GetSubscriberAsync(int subscriberId)
    {
        return await _dbContext.Subscribers.Include(x => x.ReceivedNewsletters).FirstOrDefaultAsync(x => x.SubscriberId == subscriberId);
    }
    
    public async Task<Subscriber> GetSubscriberAsync(string emailAddress)
    {
        return await _dbContext.Subscribers.Include(x => x.ReceivedNewsletters).FirstOrDefaultAsync(x => x.EmailAddress == emailAddress);
    }
    
    public async Task CreateSubscriberAsync(Subscriber subscriber)
    {
        await _dbContext.Subscribers.AddAsync(subscriber);

        await _dbContext.SaveChangesAsync();
    }
}