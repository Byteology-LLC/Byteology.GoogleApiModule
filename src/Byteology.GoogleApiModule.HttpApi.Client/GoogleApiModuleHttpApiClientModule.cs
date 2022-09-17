using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Byteology.GoogleApiModule;

[DependsOn(
    typeof(GoogleApiModuleApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class GoogleApiModuleHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(GoogleApiModuleApplicationContractsModule).Assembly,
            GoogleApiModuleRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<GoogleApiModuleHttpApiClientModule>();
        });

    }
}
