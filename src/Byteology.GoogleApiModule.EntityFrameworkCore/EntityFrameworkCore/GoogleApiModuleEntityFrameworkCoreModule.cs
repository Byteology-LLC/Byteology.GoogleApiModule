using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Byteology.GoogleApiModule.EntityFrameworkCore;

[DependsOn(
    typeof(GoogleApiModuleDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class GoogleApiModuleEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<GoogleApiModuleDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
        });
    }
}
