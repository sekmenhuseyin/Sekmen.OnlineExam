using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Sekmen.OnlineExam.Authorization;

namespace Sekmen.OnlineExam
{
    [DependsOn(
        typeof(OnlineExamCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class OnlineExamApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<OnlineExamAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(OnlineExamApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
