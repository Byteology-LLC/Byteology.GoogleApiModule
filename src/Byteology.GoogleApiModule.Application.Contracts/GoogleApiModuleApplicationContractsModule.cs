using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Byteology.GoogleApiModule;

[DependsOn(
    typeof(GoogleApiModuleDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class GoogleApiModuleApplicationContractsModule : AbpModule
{

}
