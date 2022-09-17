using Byteology.GoogleApiModule.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Byteology.GoogleApiModule.Pages;

public abstract class GoogleApiModulePageModel : AbpPageModel
{
    protected GoogleApiModulePageModel()
    {
        LocalizationResourceType = typeof(GoogleApiModuleResource);
    }
}
