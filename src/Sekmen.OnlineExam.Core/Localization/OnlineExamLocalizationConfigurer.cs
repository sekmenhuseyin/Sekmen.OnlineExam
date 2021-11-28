using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Sekmen.OnlineExam.Localization
{
    public static class OnlineExamLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(OnlineExamConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(OnlineExamLocalizationConfigurer).GetAssembly(),
                        "Sekmen.OnlineExam.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
