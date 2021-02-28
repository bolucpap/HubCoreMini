using Newtonsoft.Json.Linq;

namespace HubCoreMini.Providers
{
    public interface IEventHandlerProvider
    {
        JToken HandleEvent(string sourceApi, string eventName, JToken eventPayload, string[] eventParameters);
    }
}