using Abp.Application.Services;
using Sekmen.OnlineExam.MultiTenancy.Dto;

namespace Sekmen.OnlineExam.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

