using System.Collections.Generic;

namespace Sekmen.OnlineExam.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
