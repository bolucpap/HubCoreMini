namespace HubCoreMini.Providers
{
    public interface IInfoProviderRepository
    {
        bool IsInfoProviderRegistered(string infoProviderName);
        IInfoProvider FetchProvider(string infoProviderName);
    }
}