using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Byteology.GoogleApiModule.Pages;

public class IndexModel : GoogleApiModulePageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
