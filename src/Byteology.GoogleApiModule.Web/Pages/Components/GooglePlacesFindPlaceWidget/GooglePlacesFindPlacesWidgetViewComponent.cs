using Byteology.GoogleApiModule.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace Byteology.GoogleApiModule.Web.Pages.Components.GooglePlacesFindPlaceWidget
{
    [Widget(
    DisplayName = "GooglePlacesFindPlaceWidget",
    DisplayNameResource = typeof(GoogleApiModuleResource),
    StyleFiles = new[] { "/Pages/Components/GooglePlacesFindPlaceWidget/Default.css" },
    ScriptFiles = new[] { "/Pages/Components/GooglePlacesFindPlaceWidget/Default.js" })]
    public class GooglePlacesFindPlaceWidgetViewComponent : AbpViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(GooglePlacesFindPlaceWidgetOptions options)
        {
            return View(options);
        }
    }

}
