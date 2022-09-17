using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Byteology.GoogleApiModule;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(GoogleApiModuleDomainSharedModule)
)]
public class GoogleApiModuleDomainModule : AbpModule
{

}
