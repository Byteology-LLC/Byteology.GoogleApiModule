using Byteology.GoogleApiModule.Options;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Byteology.GoogleApiModule;

[DependsOn(
    typeof(GoogleApiModuleApplicationModule),
    typeof(GoogleApiModuleDomainTestModule)
    )]
public class GoogleApiModuleApplicationTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        //Replacing the IHttpContextAccessor service
        //context.Services.Replace(ServiceDescriptor.Transient<IHttpContextAccessor, IHttpContextAccessor>());

        Configure<GoogleApiModuleOptions>(options =>
        {
            options.APIKey = configuration["GoogleApis:ApiKey"];
            options.RequireAuthentication = false;
            options.IncludePremiumEndpoints = false;
            options.SearchEngineId = configuration["GoogleApis:SearchEngineId"];
        });
    }
}
