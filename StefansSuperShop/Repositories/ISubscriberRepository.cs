using System.Collections.Generic;
using System.Threading.Tasks;
using StefansSuperShop.Data;


namespace StefansSuperShop.Repositories;

public interface ISubscriberRepository
{
    Task<IEnumerable<Data.Subscriber>> GetSubscribers();
    Task CreateSubscriberAsync(Data.Subscriber subscriber);
    Task<Subscriber> GetSubscriberAsync(string emailAddress);
    Task<Subscriber> GetSubscriberAsync(int subscriberId);
}