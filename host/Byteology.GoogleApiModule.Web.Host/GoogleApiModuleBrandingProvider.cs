using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Byteology.GoogleApiModule;

[Dependency(ReplaceServices = true)]
public class GoogleApiModuleBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "GoogleApiModule";
}
