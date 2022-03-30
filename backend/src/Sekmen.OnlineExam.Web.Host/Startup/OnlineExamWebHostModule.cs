using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Sekmen.OnlineExam.Configuration;

namespace Sekmen.OnlineExam.Web.Host.Startup
{
    [DependsOn(
       typeof(OnlineExamWebCoreModule))]
    public class OnlineExamWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public OnlineExamWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OnlineExamWebHostModule).GetAssembly());
        }
    }
}
