using Byteology.GoogleApiModule.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Byteology.GoogleApiModule.Blazor.Server.Host;

public abstract class GoogleApiModuleComponentBase : AbpComponentBase
{
    protected GoogleApiModuleComponentBase()
    {
        LocalizationResource = typeof(GoogleApiModuleResource);
    }
}
