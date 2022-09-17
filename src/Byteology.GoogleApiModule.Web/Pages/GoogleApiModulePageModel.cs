using Byteology.GoogleApiModule.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Byteology.GoogleApiModule.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class GoogleApiModulePageModel : AbpPageModel
{
    protected GoogleApiModulePageModel()
    {
        LocalizationResourceType = typeof(GoogleApiModuleResource);
        ObjectMapperContext = typeof(GoogleApiModuleWebModule);
    }
}
