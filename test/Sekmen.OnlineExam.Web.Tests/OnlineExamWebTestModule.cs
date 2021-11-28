using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Sekmen.OnlineExam.EntityFrameworkCore;
using Sekmen.OnlineExam.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Sekmen.OnlineExam.Web.Tests
{
    [DependsOn(
        typeof(OnlineExamWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class OnlineExamWebTestModule : AbpModule
    {
        public OnlineExamWebTestModule(OnlineExamEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OnlineExamWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(OnlineExamWebMvcModule).Assembly);
        }
    }
}