using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Byteology.GoogleApiModule.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class GoogleApiModuleBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "GoogleApiModule";
}
