using Byteology.GoogleApiModule.Localization;
using Volo.Abp.Application.Services;

namespace Byteology.GoogleApiModule;

public abstract class GoogleApiModuleAppService : ApplicationService
{
    protected GoogleApiModuleAppService()
    {
        LocalizationResource = typeof(GoogleApiModuleResource);
        ObjectMapperContext = typeof(GoogleApiModuleApplicationModule);
    }
}
