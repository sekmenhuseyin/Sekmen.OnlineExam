using System.Threading.Tasks;
using Abp.Application.Services;
using Sekmen.OnlineExam.Sessions.Dto;

namespace Sekmen.OnlineExam.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
