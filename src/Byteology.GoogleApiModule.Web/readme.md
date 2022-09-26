# Byteology.GoogleApiModule.Web

## Installing the Project

For full instructions, or to lean to install from source read the primary instructions on the [main repo page](https://github.com/Byteology-LLC/Byteology.GoogleApiModule/readme.md).

## The Test Page

As this project evolves and adds new widgets, the test page (by default bound to `/googleapimodule`) will have examples of the widgets that you can use to test functionality and permissions.

## General Widget Details

Each widget defined in this module will share a common architecture that will help you integrate them into your code. The base architecture includes:

- Standard naming convention: {Api}{Function}Widget. I.e. the Google Places AutoComplete endpoint function widget becomes `GooglePlacesAutoCompleteWidget`
- Custom Options, generally named {WidgetName}Options. I.e. `GooglePlacesAutoCompleteWidgetOptions`
- Script and Style [bundles](https://docs.abp.io/en/abp/latest/UI/AspNetCore/Bundling-Minification). Generally named {WidgetName}Bundle. I.e. `GooglePlacesAutoCompleteWidgetBundle`
- Javascript initialization function for manual initialization. Generally named (camelCased) : {widgetName}Init. I.e. `googlePlacesAutoCompleteWidgetInit()`

## The Widgets

At this time, the following widgets are available for use in an MVC project:

### Google Places AutoComplete Widget

This widget creates a simple Select2 autocomplete box backended into the Google Places API (via the inbuilt AppServices) that can be used for address AutoComplete.

It supports the following Options:

```C#
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
```

To render the widget, add the following using statement to the top of the page:

```C#
@using Byteology.GoogleApiModule.Web.Pages.Components.GooglePlacesAutocompleteWidget
```

and add the following code where you want the widget to load:

```C#
@await Component.InvokeAsync(typeof(GooglePlacesAutocompleteWidgetViewComponent),new GooglePlacesAutoCompleteWidgetOptions{
    AddressInputName = "autoCompleteAddress",
    CssClass = "w-50",
    PlaceIdInputName = "autoCompletePlaceid"
})
```

#### Modals

Modals play funny with the way scripts are injected (especially when using the [modalManager](https://docs.abp.io/en/abp/latest/UI/AspNetCore/Modals#defining-the-modal-manager) with a separate cshtml file (like the ABP Suite does with the generated code). In order to combat this, you will need to add a few extra lines.

On the CSHTML file for the page that calls your modal (not the modal.cshtml, but it's parent so to speak), add the following lines at the top below the model declaration:

```C#
@section styles{
    <abp-style-bundle name="GooglePlacesAutoCompleteWidgetBundle" />
}
@section scripts {
    <abp-script-bundle name="GooglePlacesAutoCompleteWidgetBundle" />
}
```

This ensures that the correct Styling and Script files will load on the page so the widget on the modal will function correctly.

Additionally, somewhere near the bottom of your `$(document).ready(function{...})` method on the javascript file for that page, add the following snippet:

```javascript
//add this if you are using the ModalManager to create a Modal to initialize the widgets. assumes your modal is defined as var modalManager = new abp.ModalManager( abp.appPath + 'path/to/modal/cshtml');
    modalManager.onOpen(function () {
        googlePlacesAutoCompleteWidgetInit();
    });
```

That will initialize the widget once the modal is fully open and allow it to work as expected.

### Google Places Find Place Widget

This widget creates a Select2 dropdown box, but is tied to the FindPlace API endpoint, so it is designed to work by searching for places by name.

It supports the following Options:

```C#
public class GooglePlacesFindPlaceWidgetOptions
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
```

To render the widget, add the following using statement to the top of the page:

```C#
@using Byteology.GoogleApiModule.Web.Pages.Components.GooglePlacesFindPlaceWidget
```

and add the following code where you want the widget to load:

```C#
@await Component.InvokeAsync(typeof(GooglePlacesFindPlaceWidgetViewComponent),new GooglePlacesFindPlaceWidgetOptions{
        AddressInputName = "findAddress",
        CssClass = "w-50",
        PlaceIdInputName = "findPlaceId"
    })
```

#### Modals

Modals play funny with the way scripts are injected (especially when using the [modalManager](https://docs.abp.io/en/abp/latest/UI/AspNetCore/Modals#defining-the-modal-manager) with a separate cshtml file (like the ABP Suite does with the generated code). In order to combat this, you will need to add a few extra lines.

On the CSHTML file for the page that calls your modal (not the modal.cshtml, but it's parent so to speak), add the following lines at the top below the model declaration:

```C#
@section styles{
    <abp-style-bundle name="GooglePlacesFindPlaceWidgetBundle" />
}
@section scripts {
    <abp-script-bundle name="GooglePlacesFindPlaceWidgetBundle" />
}
```

This ensures that the correct Styling and Script files will load on the page so the widget on the modal will function correctly.

Additionally, somewhere near the bottom of your `$(document).ready(function{...})` method on the javascript file for that page, add the following snippet:

```javascript
//add this if you are using the ModalManager to create a Modal to initialize the widgets. assumes your modal is defined as var modalManager = new abp.ModalManager( abp.appPath + 'path/to/modal/cshtml');
    modalManager.onOpen(function () {
        googlePlacesFindPlaceWidgetInit();
    });
```
