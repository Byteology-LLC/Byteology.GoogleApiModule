namespace Byteology.GoogleApiModule.Web.Pages.Components.GooglePlacesAutocompleteWidget
{
    public class GooglePlacesAutoCompleteWidgetOptions
    {
        /// <summary>
        /// The name field for the returned Address data. Defaults to 'Address'
        /// </summary>
        public string AddressInputName { get; set; } = "Address";
        /// <summary>
        /// The name field for the returned hidden PlaceId data. Defaults to 'PlaceId'
        /// </summary>
        public string PlaceIdInputName { get; set; } = "PlaceId";
        /// <summary>
        /// CSS class or classes to add to the main select box.
        /// </summary>
        public string CssClass { get; set; } = "";
        /// <summary>
        /// CSS class or classes to add to the div parent of the main select box. Defaults to 'm-3'
        /// </summary>
        public string ParentCss { get; set; } = "m-3";
        /// <summary>
        /// Label for the field. Defaults to null.
        /// </summary>
        public string Label { get; set; } = null;
    }
}
