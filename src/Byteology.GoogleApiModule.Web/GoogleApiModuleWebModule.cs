using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Byteology.GoogleApiModule.Localization;
using Byteology.GoogleApiModule.Web.Menus;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using Byteology.GoogleApiModule.Permissions;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Microsoft.Extensions.Options;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using System.Linq;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.Select2;
using Byteology.GoogleApiModule.Web.Pages.Bundles.Contributors;

namespace Byteology.GoogleApiModule.Web;

[DependsOn(
    typeof(GoogleApiModuleApplicationContractsModule),
    typeof(AbpAspNetCoreMvcUiThemeSharedModule),
    typeof(AbpAutoMapperModule)
    )]
public class GoogleApiModuleWebModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
        {
            options.AddAssemblyResource(typeof(GoogleApiModuleResource), typeof(GoogleApiModuleWebModule).Assembly);
        });

        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(GoogleApiModuleWebModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new GoogleApiModuleMenuContributor());
        });

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<GoogleApiModuleWebModule>();
        });

        context.Services.AddAutoMapperObjectMapper<GoogleApiModuleWebModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<GoogleApiModuleWebModule>(validate: true);
        });

        Configure<RazorPagesOptions>(options =>
        {
                //Configure authorization.
            });

        Configure<AbpBundlingOptions>(options =>
        {
            options.ScriptBundles.Configure(
                StandardBundles.Scripts.Global,
                bundleConfiguration =>
                {
                    bundleConfiguration.Contributors.Replace<Select2ScriptContributor, GoogleApiModuleBaselineBundleContributor>();
                });

            //Widget Bundle Contributors
            //Autocomplete Widget
            options.ScriptBundles.Add("GooglePlacesAutoCompleteWidgetBundle", bundle =>
            {
                bundle.AddFiles(
                    "/Pages/Components/GooglePlacesAutocompleteWidget/Default.js"
                    );
            });

            options.StyleBundles.Add("GooglePlacesAutoCompleteWidgetBundle", bundle =>
            {
                bundle.AddFiles(
                    "/Pages/Components/GooglePlacesAutocompleteWidget/Default.css"
                    );
            });

            //FindPlace Widget
            options.ScriptBundles.Add("GooglePlacesFindPlaceWidgetBundle", bundle =>
            {
                bundle.AddFiles(
                    "/Pages/Components/GooglePlacesFindPlaceWidget/Default.js"

                );
            });

            options.StyleBundles.Add("GooglePlacesFindPlaceWidgetBundle", bundle =>
            {
                bundle.AddFiles(
                    "/Pages/Components/GooglePlacesFindPlaceWidget/Default.css"
                    );
            });
        });

        
    }
}
