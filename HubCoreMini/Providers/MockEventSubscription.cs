using Newtonsoft.Json.Linq;

namespace HubCoreMini.Providers
{
    public class MockEventSubscription : IEventSubscription
    {
        private string eventName;

        public MockEventSubscription(string eventName)
        {
            this.eventName = eventName;
        }

        public JToken TriggerEvent(string sourceApi, JToken eventPayload, string[] parameters)
        {
            var retval = JToken.Parse("{}");
            retval["Content"] = $"You called {eventName} from {sourceApi} with parameters: [{string.Join(",", parameters)}] and body { eventPayload.ToString() } ";
            return retval;
        }
    }
}