using Abp.AutoMapper;
using Sekmen.OnlineExam.Authentication.External;

namespace Sekmen.OnlineExam.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
