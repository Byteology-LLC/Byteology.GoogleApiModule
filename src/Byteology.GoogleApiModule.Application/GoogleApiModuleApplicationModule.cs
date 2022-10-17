using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;
using Byteology.GoogleApiModule.Settings;
using Volo.Abp.SettingManagement;

namespace Byteology.GoogleApiModule;

[DependsOn(
    typeof(GoogleApiModuleDomainModule),
    typeof(GoogleApiModuleApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class GoogleApiModuleApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<GoogleApiModuleApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<GoogleApiModuleApplicationModule>(validate: true);
        });
    }
}
