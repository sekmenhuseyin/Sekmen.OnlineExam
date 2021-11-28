using System.Threading.Tasks;
using Abp.Application.Services;
using Sekmen.OnlineExam.Authorization.Accounts.Dto;

namespace Sekmen.OnlineExam.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<RegisterOutput> Register(RegisterInput input);
    }
}
