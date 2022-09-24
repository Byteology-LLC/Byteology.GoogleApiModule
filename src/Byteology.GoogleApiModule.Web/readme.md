# Byteology.GoogleApiModule.Web

## Installing the Project

For full instructions, or to lean to install from source read the primary instructions on the [main repo page](https://github.com/Byteology-LLC/Byteology.GoogleApiModule/readme.md).

## The Test Page

As this project evolves and adds new widgets, the test page (by default bound to `/googleapimodule`) will have examples of the widgets that you can use to test functionality and permissions.

## The Widgets

At this time, the following widgets are available for use in an MVC project:

### Google Places AutoComplete Widget

This widget creates a simple Select2 autocomplete box backended into the Google Places API (via the inbuilt AppServices) that can be used for address AutoComplete.

It supports the following Options:

- Name : the name of the input field you want returned with the form that holds the formatted address of the selected entry. Defaults to "Address"
- CssClass : This will append whatever you pass into it to the end of the classes in the CSS. Separate multiple classes with a space, for example: "fw-bold text-center"
- PlaceIdInputName : This is the name of the hidden input holding the PlaceId of the selected entry. This is useful if you plan on making another call to the Details endpoint for additional information. Defaults to "PlaceId".

To render the widget, add the following using statement to the top of the page:

```C#
@using Byteology.GoogleApiModule.Web.Pages.Components.GooglePlacesAutocompleteWidget
```

and add the following code where you want the widget to load:

```C#
@await Component.InvokeAsync(typeof(GooglePlacesAutocompleteWidgetViewComponent),new GooglePlacesAutoCompleteWidgetOptions{
    Name = "autoCompleteAddress",
    CssClass = "w-50",
    PlaceIdInputName = "autoCompletePlaceid"
})
```

### Google Places Find Place Widget

This widget creates a Select2 dropdown box, but is tied to the FindPlace API endpoint, so it is designed to work by searching for places by name.

It supports the following Options:

- Name : the name of the input field you want returned with the form that holds the formatted address of the selected entry. Defaults to "Address"
- CssClass : This will append whatever you pass into it to the end of the classes in the CSS. Separate multiple classes with a space, for example: "fw-bold text-center"
- PlaceIdInputName : This is the name of the hidden input holding the PlaceId of the selected entry. This is useful if you plan on making another call to the Details endpoint for additional information. Defaults to "PlaceId".

To render the widget, add the following using statement to the top of the page:

```C#
@using Byteology.GoogleApiModule.Web.Pages.Components.GooglePlacesFindPlaceWidget
```

and add the following code where you want the widget to load:

```C#
@await Component.InvokeAsync(typeof(GooglePlacesFindPlaceWidgetViewComponent),new GooglePlacesFindPlaceWidgetOptions{
        Name = "findAddress",
        CssClass = "w-50",
        PlaceIdInputName = "findPlaceId"
    })
```
