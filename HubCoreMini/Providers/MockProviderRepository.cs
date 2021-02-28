namespace HubCoreMini.Providers
{
    public class MockProviderRepository : IInfoProviderRepository
    {
        public IInfoProvider FetchProvider(string infoProviderName)
        {
            return new MockInfoProvider(infoProviderName);
        }

        public bool IsInfoProviderRegistered(string infoProviderName)
        {
            return infoProviderName.ToLowerInvariant() == "myinfoprovider";
        }
    }
}