using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace VolunteeringManagementSystem.Localization
{
    public static class VolunteeringManagementSystemLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(VolunteeringManagementSystemConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(VolunteeringManagementSystemLocalizationConfigurer).GetAssembly(),
                        "VolunteeringManagementSystem.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
