using Byteology.GoogleApiModule.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace Byteology.GoogleApiModule.Web.Pages.Components.GooglePlacesFindPlaceWidget
{
    [Widget(
    DisplayName = "GooglePlacesFindPlaceWidget",
    DisplayNameResource = typeof(GoogleApiModuleResource),
    StyleTypes = new[] { typeof(GooglePlacesFindPlaceWidgetStyleBundleContributor) },
    ScriptTypes = new[] { typeof(GooglePlacesFindPlaceWidgetScriptBundleContributor) })]
    public class GooglePlacesFindPlaceWidgetViewComponent : AbpViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(GooglePlacesFindPlaceWidgetOptions options)
        {
            return View(options);
        }
    }

    public class GooglePlacesFindPlaceWidgetScriptBundleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files
              .AddIfNotContains("/Pages/Components/GooglePlacesFindPlaceWidget/Default.js");
        }
    }

    public class GooglePlacesFindPlaceWidgetStyleBundleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files
              .AddIfNotContains("/Pages/Components/GooglePlacesFindPlaceWidget/Default.css");
        }
    }

}
