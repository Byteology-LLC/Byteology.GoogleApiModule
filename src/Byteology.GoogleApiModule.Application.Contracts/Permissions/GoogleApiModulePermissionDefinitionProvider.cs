using Byteology.GoogleApiModule.Localization;
using Byteology.GoogleApiModule.Options;
using Microsoft.Extensions.Options;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;


namespace Byteology.GoogleApiModule.Permissions;

public class GoogleApiModulePermissionDefinitionProvider : PermissionDefinitionProvider
{
    private readonly GoogleApiModuleOptions Options;

    public GoogleApiModulePermissionDefinitionProvider(IOptions<GoogleApiModuleOptions> options)
    {
        Options = options.Value;
    }

    public override void Define(IPermissionDefinitionContext context)
    {
        var apiGroup = context.AddGroup(GoogleApiModulePermissions.GroupName, L("Permission:GoogleApiModule"));
        apiGroup.AddPermission(GoogleApiModulePermissions.Settings, L("Permission:Settings"));

        if (Options.RequireGranularPermissions)
        {
            //Map Permissions
            var mapGroup = apiGroup.AddPermission(GoogleApiModulePermissions.Maps.Default, L("Permission:Maps"));
            mapGroup.AddChild(GoogleApiModulePermissions.Maps.Directions, L("Permission:Maps:Directions"));
            mapGroup.AddChild(GoogleApiModulePermissions.Maps.DistanceMatrix, L("Permission:Maps:DistanceMatrix"));
            mapGroup.AddChild(GoogleApiModulePermissions.Maps.Elevation, L("Permission:Maps:Elevation"));
            mapGroup.AddChild(GoogleApiModulePermissions.Maps.Geolocation, L("Permission:Maps:Geolocation"));
            mapGroup.AddChild(GoogleApiModulePermissions.Maps.TimeZone, L("Permission:Maps:TimeZone"));
            mapGroup.AddChild(GoogleApiModulePermissions.Maps.StreetView, L("Permission:Maps:StreetView"));
            mapGroup.AddChild(GoogleApiModulePermissions.Maps.StaticMaps, L("Permission:Maps:StaticMaps"));

            var mapGeocode = mapGroup.AddChild(GoogleApiModulePermissions.Maps.Geocode.Default, L("Permission:Maps:Geocode"));
            mapGeocode.AddChild(GoogleApiModulePermissions.Maps.Geocode.Place, L("Permission:Maps:Geocode:Place"));
            mapGeocode.AddChild(GoogleApiModulePermissions.Maps.Geocode.Address, L("Permission:Maps:Geocode:Address"));
            mapGeocode.AddChild(GoogleApiModulePermissions.Maps.Geocode.PlusCode, L("Permission:Maps:Geocode:PlusCode"));
            mapGeocode.AddChild(GoogleApiModulePermissions.Maps.Geocode.Location, L("Permission:Maps:Geocode:Location"));

            var mapRoads = mapGroup.AddChild(GoogleApiModulePermissions.Maps.Roads.Default, L("Permission:Maps:Roads"));
            mapRoads.AddChild(GoogleApiModulePermissions.Maps.Roads.NearestRoads, L("Permission:Maps:Roads:NearestRoads"));
            mapRoads.AddChild(GoogleApiModulePermissions.Maps.Roads.SnapToRoads, L("Permission:Maps:Roads:SnapToRoads"));
            mapRoads.AddChild(GoogleApiModulePermissions.Maps.Roads.SpeedLimits, L("Permission:Maps:Roads:SpeedLimits"));

            //Places Permissions
            var placesGroup = apiGroup.AddPermission(GoogleApiModulePermissions.Places.Default, L("Permission:Places"));
            placesGroup.AddChild(GoogleApiModulePermissions.Places.AutoComplete, L("Permission:Places:AutoComplete"));
            placesGroup.AddChild(GoogleApiModulePermissions.Places.Details, L("Permission:Places:Details"));
            placesGroup.AddChild(GoogleApiModulePermissions.Places.Photos, L("Permission:Places:Photos"));
            placesGroup.AddChild(GoogleApiModulePermissions.Places.QueryAutoComplete, L("Permission:Places:QueryAutoComplete"));

            var placesSearch = placesGroup.AddChild(GoogleApiModulePermissions.Places.Search.Default, L("Permission:Places:Search"));
            placesSearch.AddChild(GoogleApiModulePermissions.Places.Search.Find, L("Permission:Places:Search:Find"));
            placesSearch.AddChild(GoogleApiModulePermissions.Places.Search.NearBy, L("Permission:Places:Search:Nearby"));
            placesSearch.AddChild(GoogleApiModulePermissions.Places.Search.Text, L("Permission:Places:Search:Text"));

            //Search Permissions
            var googleSearch = apiGroup.AddPermission(GoogleApiModulePermissions.Search.Default, L("Permission:Search"));
            googleSearch.AddChild(GoogleApiModulePermissions.Search.Web, L("Permission:Search:Web"));
            googleSearch.AddChild(GoogleApiModulePermissions.Search.Image, L("Permission:Search:Image"));

            var googleVideoSearch = googleSearch.AddChild(GoogleApiModulePermissions.Search.Video.Default, L("Permission:Search:Video"));
            googleVideoSearch.AddChild(GoogleApiModulePermissions.Search.Video.Channels, L("Permission:Search:Video:Channels"));
            googleVideoSearch.AddChild(GoogleApiModulePermissions.Search.Video.Playlists, L("Permission:Search:Video:Playlists"));
            googleVideoSearch.AddChild(GoogleApiModulePermissions.Search.Video.Videos, L("Permission:Search:Video:Videos"));

            //Translate Permissions
            var translateGroup = apiGroup.AddPermission(GoogleApiModulePermissions.Translate.Default, L("Permissions:Translate"));
            translateGroup.AddChild(GoogleApiModulePermissions.Translate.Detect, L("Permissions:Translate:Detect"));
            translateGroup.AddChild(GoogleApiModulePermissions.Translate.Languages, L("Permissions:Translate:Languages"));
        }

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<GoogleApiModuleResource>(name);
    }
}
