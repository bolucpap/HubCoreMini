using Newtonsoft.Json.Linq;
using System.Linq;

namespace HubCoreMini.Providers
{
    public class TalkBackEventTriggerProvider : IEventHandlerProvider
    {
        private readonly IEventSubscriptionRepository eventSubscriptionRepository;

        public TalkBackEventTriggerProvider(IEventSubscriptionRepository eventSubscriptionRepository)
        {
            this.eventSubscriptionRepository = eventSubscriptionRepository;
        }
        public JToken HandleEvent(string sourceApi, string eventName, JToken eventPayload, string[] eventParameters)
        {
            var retval = JToken.Parse("{}");
            if (eventSubscriptionRepository.IsEventSubscriptionRegistered(eventName))
            {
                var subscriptions = eventSubscriptionRepository.FetchSubscriptions(eventName);
                if (subscriptions.Count == 1)
                {
                    retval = subscriptions[0].TriggerEvent(sourceApi, eventPayload, eventParameters);
                }
                else
                {
                    retval = JArray.FromObject(subscriptions.Select(subscription => subscription.TriggerEvent(sourceApi, eventPayload, eventParameters)).ToArray());
                }
            }
            else
            {
                retval["NoSubscriptions"] = $"No subscriptions exist for event {eventName}";
            }
            return retval;
        }
    }
}