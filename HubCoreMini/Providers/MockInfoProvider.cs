using Newtonsoft.Json.Linq;

namespace HubCoreMini.Providers
{
    public class MockInfoProvider : IInfoProvider
    {
        private readonly string infoProviderName;

        public MockInfoProvider(string infoProviderName)
        {
            this.infoProviderName = infoProviderName;
        }
        public JToken QueryInfoProvider(string sourceApi, string[] infoParams)
        {
            var retval = JToken.Parse("{}");
            retval["Content"] = $"You called {infoProviderName} from {sourceApi} with parameters: [{string.Join(",", infoParams)}] ";
            return retval;
        }
    }
}