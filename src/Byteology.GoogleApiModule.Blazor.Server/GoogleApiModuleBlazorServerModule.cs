using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace Byteology.GoogleApiModule.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(GoogleApiModuleBlazorModule)
    )]
public class GoogleApiModuleBlazorServerModule : AbpModule
{

}
