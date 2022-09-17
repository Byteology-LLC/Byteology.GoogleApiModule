using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Byteology.GoogleApiModule.MongoDB;

[DependsOn(
    typeof(GoogleApiModuleDomainModule),
    typeof(AbpMongoDbModule)
    )]
public class GoogleApiModuleMongoDbModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMongoDbContext<GoogleApiModuleMongoDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, MongoQuestionRepository>();
                 */
        });
    }
}
