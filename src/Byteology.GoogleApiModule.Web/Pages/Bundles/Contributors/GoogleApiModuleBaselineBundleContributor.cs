using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.Core;
using Volo.Abp.Modularity;

namespace Byteology.GoogleApiModule.Web.Pages.Bundles.Contributors
{
    [DependsOn(typeof(CoreScriptContributor))]
    public class GoogleApiModuleBaselineBundleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.AddIfNotContains("/libs/select2/js/select2.full.min.js");
        }
    }
}
