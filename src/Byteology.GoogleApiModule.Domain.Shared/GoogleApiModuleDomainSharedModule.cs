using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Byteology.GoogleApiModule.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Byteology.GoogleApiModule;

[DependsOn(
    typeof(AbpValidationModule)
)]
public class GoogleApiModuleDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<GoogleApiModuleDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<GoogleApiModuleResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/GoogleApiModule");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("GoogleApiModule", typeof(GoogleApiModuleResource));
        });
    }
}
