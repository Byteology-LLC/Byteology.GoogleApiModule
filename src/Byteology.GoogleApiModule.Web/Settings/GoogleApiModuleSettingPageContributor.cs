using Byteology.GoogleApiModule.Localization;
using Byteology.GoogleApiModule.Permissions;
using Byteology.GoogleApiModule.Web.Pages.Components.GoogleApiModuleSettingsGroup;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System.Threading.Tasks;
using Volo.Abp.SettingManagement.Localization;
using Volo.Abp.SettingManagement.Web.Pages.SettingManagement;
using Volo.Abp.Users;

namespace Byteology.GoogleApiModule.Web.Settings
{
    public class GoogleApiModuleSettingPageContributor : ISettingPageContributor
    {

        public virtual async Task<bool> CheckPermissionsAsync(SettingPageCreationContext context)
        {
            var authService = context.ServiceProvider.GetRequiredService<IAuthorizationService>();

            return await authService.IsGrantedAsync(GoogleApiModulePermissions.Settings);
        }

        public virtual Task ConfigureAsync(SettingPageCreationContext context)
        {
            var l = context.ServiceProvider.GetRequiredService<IStringLocalizer<GoogleApiModuleResource>>();

            context.Groups.Add(
            new SettingPageGroup(
                "Byteology.GoogleApiModule.Settings",
                l["Menu:GoogleApiModule"],
                typeof(GoogleApiModuleSettingsGroupViewComponent)
                )
            );

            return Task.CompletedTask;
        }
    }
}
