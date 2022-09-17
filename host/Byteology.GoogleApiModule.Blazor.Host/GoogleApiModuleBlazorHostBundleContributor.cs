using Volo.Abp.Bundling;

namespace Byteology.GoogleApiModule.Blazor.Host;

public class GoogleApiModuleBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
