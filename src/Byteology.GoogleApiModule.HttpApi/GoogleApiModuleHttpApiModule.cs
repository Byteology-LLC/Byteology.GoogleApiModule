using Localization.Resources.AbpUi;
using Byteology.GoogleApiModule.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Byteology.GoogleApiModule;

[DependsOn(
    typeof(GoogleApiModuleApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class GoogleApiModuleHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(GoogleApiModuleHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<GoogleApiModuleResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
