using Byteology.GoogleApiModule.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace Byteology.GoogleApiModule.Web.Pages.Components.GooglePlacesAutocompleteWidget;

[Widget(
    DisplayName = "GooglePlacesAutoCompleteWidget",
    DisplayNameResource = typeof(GoogleApiModuleResource),
    StyleTypes = new[] { typeof(GooglePlacesAutocompleteWidgetStyleBundleContributor) },
    ScriptTypes = new[] { typeof(GooglePlacesAutocompleteWidgetScriptBundleContributor) })]
public class GooglePlacesAutocompleteWidgetViewComponent : AbpViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(GooglePlacesAutoCompleteWidgetOptions options)
    {
        return View(options);
    }
}


public class GooglePlacesAutocompleteWidgetScriptBundleContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files
          .AddIfNotContains("/Pages/Components/GooglePlacesAutocompleteWidget/Default.js");
    }
}

public class GooglePlacesAutocompleteWidgetStyleBundleContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files
          .AddIfNotContains("/Pages/Components/GooglePlacesAutocompleteWidget/Default.css");
    }
}