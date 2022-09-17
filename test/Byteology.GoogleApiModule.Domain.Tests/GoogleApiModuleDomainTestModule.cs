using Byteology.GoogleApiModule.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Byteology.GoogleApiModule;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(GoogleApiModuleEntityFrameworkCoreTestModule)
    )]
public class GoogleApiModuleDomainTestModule : AbpModule
{

}
