using System.Collections.Generic;

namespace HubCoreMini.Providers
{
    public interface IEventSubscriptionRepository
    {
        bool IsEventSubscriptionRegistered(string EventName);        
        List<IEventSubscription> FetchSubscriptions(string EventName);
    }
}