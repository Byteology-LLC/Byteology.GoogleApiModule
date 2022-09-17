using Byteology.GoogleApiModule.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace Byteology.GoogleApiModule.Web.Pages.Components.GooglePlacesAutocompleteWidget;

[Widget(
    DisplayName = "GooglePlacesAutoCompleteWidget",
    DisplayNameResource = typeof(GoogleApiModuleResource),
    StyleFiles = new[] { "/Pages/Components/GooglePlacesAutocompleteWidget/Default.css" },
    ScriptFiles = new[] { "/Pages/Components/GooglePlacesAutocompleteWidget/Default.js" })]
public class GooglePlacesAutocompleteWidgetViewComponent : AbpViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(GooglePlacesAutoCompleteWidgetOptions options)
    {
        return View(options);
    }
}
