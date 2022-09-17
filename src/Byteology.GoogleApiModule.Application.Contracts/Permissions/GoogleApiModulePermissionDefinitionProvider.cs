using Byteology.GoogleApiModule.Localization;
using Byteology.GoogleApiModule.Options;
using Microsoft.Extensions.Options;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;


namespace Byteology.GoogleApiModule.Permissions;

public class GoogleApiModulePermissionDefinitionProvider : PermissionDefinitionProvider
{
    private readonly GoogleApiModuleOptions Options;

    public GoogleApiModulePermissionDefinitionProvider(IOptions<GoogleApiModuleOptions> options)
    {
        Options = options.Value;
    }

    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(GoogleApiModulePermissions.GroupName, L("Permission:GoogleApiModule"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<GoogleApiModuleResource>(name);
    }
}
