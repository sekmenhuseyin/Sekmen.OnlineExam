using System.Threading.Tasks;
using Sekmen.OnlineExam.Configuration.Dto;

namespace Sekmen.OnlineExam.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
