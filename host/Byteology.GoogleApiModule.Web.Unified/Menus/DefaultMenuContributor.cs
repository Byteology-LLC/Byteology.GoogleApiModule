using System.Threading.Tasks;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace Byteology.GoogleApiModule.Menus
{
    public class DefaultMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private static Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {

            //Administration
            var administration = context.Menu.GetAdministration();

            //Administration->Identity
            administration.SetSubItemOrder(IdentityMenuNames.GroupName, 1);
            //Administration->Settings
            administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 2);


            return Task.CompletedTask;
        }
    }
}
