using Newtonsoft.Json.Linq;

namespace HubCoreMini.Providers
{
    public interface IEventSubscription
    {
        JToken TriggerEvent(string sourceApi, JToken eventPayload, string[] parameters);
    }
}