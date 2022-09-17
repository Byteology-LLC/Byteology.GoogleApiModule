using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace Byteology.GoogleApiModule.Blazor.WebAssembly;

[DependsOn(
    typeof(GoogleApiModuleBlazorModule),
    typeof(GoogleApiModuleHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class GoogleApiModuleBlazorWebAssemblyModule : AbpModule
{

}
