using System.Collections.Generic;

namespace HubCoreMini.Providers
{
    public class MockSubscriptionRepository : IEventSubscriptionRepository
    {
        public List<IEventSubscription> FetchSubscriptions(string EventName)
        {
            return new List<IEventSubscription>() { new MockEventSubscription(EventName) };
        }

        public bool IsEventSubscriptionRegistered(string EventName)
        {
            return EventName.ToLowerInvariant() == "myeventsubscriptions";
        }
    }
}