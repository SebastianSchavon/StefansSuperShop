using System.Collections.Generic;
using System.Threading.Tasks;
using StefansSuperShop.Data;

namespace StefansSuperShop.Repositories.Subscriber;

public class SubscriberRepository : ISubscriberRepository
{
    private readonly ApplicationDbContext _dbContext;

    public SubscriberRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Data.Subscriber>> GetSubscribers()
    {
        return _dbContext.Subscribers;
    }
}