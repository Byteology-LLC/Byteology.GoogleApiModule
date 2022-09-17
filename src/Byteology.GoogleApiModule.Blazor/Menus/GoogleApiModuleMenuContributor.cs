using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Byteology.GoogleApiModule.Blazor.Menus;

public class GoogleApiModuleMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(GoogleApiModuleMenus.Prefix, displayName: "GoogleApiModule", "/GoogleApiModule", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
