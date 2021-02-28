using Newtonsoft.Json.Linq;
using System;

namespace HubCoreMini.Providers
{
    public class TalkBackInfoQueryProvider : IInfoQueryProvider
    {
        private IInfoProviderRepository _infoProviderRepository;

        public TalkBackInfoQueryProvider(IInfoProviderRepository infoProviderRepository)
        {
            _infoProviderRepository = infoProviderRepository;
        }

        public JToken GetQueryResult(string sourceApi, string infoProviderName, string[] infoParams)
        {
            if (_infoProviderRepository.IsInfoProviderRegistered(infoProviderName))
            {
                var _infoProvider = _infoProviderRepository.FetchProvider(infoProviderName);
                return _infoProvider.QueryInfoProvider(sourceApi, infoParams);
            }
            else
            {
                throw new Exception($"'{infoProviderName}' is not registered as an available infoProvider");
            }
        }
    }
}