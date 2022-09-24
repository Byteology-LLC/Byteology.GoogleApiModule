namespace Byteology.GoogleApiModule.Web.Pages.Components.GooglePlacesFindPlaceWidget
{
    public class GooglePlacesFindPlaceWidgetOptions
    {
        /// <summary>
        /// Name of the input returning the formatted address. Defaults to "Address"
        /// </summary>
        public string Name { get; set; } = "Address";

        /// <summary>
        /// CSS classes to be added to the end of the classes for the Select2 box.
        /// </summary>
        public string CssClass { get; set; }

        /// <summary>
        /// Name of the hidden input returning the PlaceId of the selection. Defaults to "PlaceId"
        /// </summary>
        public string PlaceIdInputName { get; set; } = "PlaceId";
    }
}
