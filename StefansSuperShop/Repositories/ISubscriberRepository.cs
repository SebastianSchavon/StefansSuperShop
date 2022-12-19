using System.Collections.Generic;
using System.Threading.Tasks;


namespace StefansSuperShop.Repositories;

public interface ISubscriberRepository
{
    Task<IEnumerable<Data.Subscriber>> GetSubscribers();
}