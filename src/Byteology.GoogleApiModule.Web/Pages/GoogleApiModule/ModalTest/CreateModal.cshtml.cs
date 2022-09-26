using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Byteology.GoogleApiModule.Web.Pages.GoogleApiModule
{
    public class CreateModalModel: AbpPageModel
    {
        [BindProperty]
        public string Address { get; set; }
        [BindProperty]
        public string PlaceId { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            var address = Address;
            var placeid = PlaceId;
        }
    }
}
