using Newtonsoft.Json.Linq;

namespace HubCoreMini.Providers
{
    public interface IInfoQueryProvider
    {
        JToken GetQueryResult(string sourceApi, string infoProviderName, string[] infoParams);
    }
}