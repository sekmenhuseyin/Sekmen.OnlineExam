using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Sekmen.OnlineExam.Authorization.Roles;
using Sekmen.OnlineExam.Authorization.Users;
using Sekmen.OnlineExam.MultiTenancy;

namespace Sekmen.OnlineExam.EntityFrameworkCore
{
    public class OnlineExamDbContext : AbpZeroDbContext<Tenant, Role, User, OnlineExamDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public OnlineExamDbContext(DbContextOptions<OnlineExamDbContext> options)
            : base(options)
        {
        }
    }
}
