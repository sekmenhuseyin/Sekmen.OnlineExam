using Abp.MultiTenancy;
using Sekmen.OnlineExam.Authorization.Users;

namespace Sekmen.OnlineExam.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
