using Microsoft.Extensions.DependencyInjection;
using Byteology.GoogleApiModule.Blazor.Menus;
using Volo.Abp.AspNetCore.Components.Web.Theming;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace Byteology.GoogleApiModule.Blazor;

[DependsOn(
    typeof(GoogleApiModuleApplicationContractsModule),
    typeof(AbpAspNetCoreComponentsWebThemingModule),
    typeof(AbpAutoMapperModule)
    )]
public class GoogleApiModuleBlazorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<GoogleApiModuleBlazorModule>();

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddProfile<GoogleApiModuleBlazorAutoMapperProfile>(validate: true);
        });

        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new GoogleApiModuleMenuContributor());
        });

        Configure<AbpRouterOptions>(options =>
        {
            options.AdditionalAssemblies.Add(typeof(GoogleApiModuleBlazorModule).Assembly);
        });
    }
}
