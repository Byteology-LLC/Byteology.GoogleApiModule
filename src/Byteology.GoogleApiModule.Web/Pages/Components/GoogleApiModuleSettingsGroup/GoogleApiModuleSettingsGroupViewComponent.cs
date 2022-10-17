using Byteology.GoogleApiModule.Settings;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Byteology.GoogleApiModule.Web.Pages.Components.GoogleApiModuleSettingsGroup
{
    public class GoogleApiModuleSettingsGroupViewComponent: AbpViewComponent
    {
        public virtual async Task<IViewComponentResult> InvokeAsync()
        {
            var appService = LazyServiceProvider.LazyGetRequiredService<IGoogleApiModuleSettingAppService>();
            var settings = await appService.GetAsync();
            return View("~/Pages/Components/GoogleApiModuleSettingsGroup/Default.cshtml", settings);
        }
    }
}
