using Microsoft.Extensions.Options;
using NS.STMS.MVC.Settings;

namespace NS.STMS.MVC.Services.ExternalServices.STMSServices
{
    public class BaseSTMSService
    {

        public readonly AppSettings _appSettings;

        public BaseSTMSService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

    }
}
