using Newtonsoft.Json.Linq;

namespace HubCoreMini.Providers
{
    public interface IInfoProvider
    {
        JToken QueryInfoProvider(string sourceApi, string[] infoParams);
    }
}