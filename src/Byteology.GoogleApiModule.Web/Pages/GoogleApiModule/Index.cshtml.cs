using Microsoft.AspNetCore.Mvc;

namespace Byteology.GoogleApiModule.Web.Pages.GoogleApiModule;

public class IndexModel : GoogleApiModulePageModel
{
    [BindProperty]
    public string AutoCompleteAddress { get; set; }
    [BindProperty]
    public string FindAddress { get; set; }

    [BindProperty]
    public string AutoCompletePlaceId { get; set; }
    [BindProperty]
    public string FindPlaceId { get; set; }

    public void OnGet()
    {
    }

    public void OnPost()
    {
        var address = AutoCompleteAddress;
        var find = FindAddress;
    }
}
