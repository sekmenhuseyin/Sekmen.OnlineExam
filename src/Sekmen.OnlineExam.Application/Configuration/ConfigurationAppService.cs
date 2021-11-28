using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Sekmen.OnlineExam.Configuration.Dto;

namespace Sekmen.OnlineExam.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : OnlineExamAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
