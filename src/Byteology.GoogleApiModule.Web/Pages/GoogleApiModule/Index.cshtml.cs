using Microsoft.AspNetCore.Mvc;

namespace Byteology.GoogleApiModule.Web.Pages.GoogleApiModule;

public class IndexModel : GoogleApiModulePageModel
{
    [BindProperty]
    public string Address { get; set; }
    [BindProperty]
    public string FindAddress { get; set; }

    public void OnGet()
    {
    }

    public void OnPost()
    {
        var address = Address;
        var find = FindAddress;
    }
}
