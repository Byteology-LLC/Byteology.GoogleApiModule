using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Byteology.GoogleApiModule;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(GoogleApiModuleHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class GoogleApiModuleConsoleApiClientModule : AbpModule
{

}
