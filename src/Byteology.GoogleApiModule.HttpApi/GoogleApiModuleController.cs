using Byteology.GoogleApiModule.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Byteology.GoogleApiModule;

public abstract class GoogleApiModuleController : AbpControllerBase
{
    protected GoogleApiModuleController()
    {
        LocalizationResource = typeof(GoogleApiModuleResource);
    }
}
