using GoogleApi.Entities.Maps.Directions.Request;
using GoogleApi.Entities.Maps.Directions.Response;
using GoogleApi.Entities.Maps.DistanceMatrix.Request;
using GoogleApi.Entities.Maps.DistanceMatrix.Response;
using GoogleApi.Entities.Maps.Elevation.Request;
using GoogleApi.Entities.Maps.Elevation.Response;
using GoogleApi.Entities.Maps.Geocoding;
using GoogleApi.Entities.Maps.Geocoding.Address.Request;
using GoogleApi.Entities.Maps.Geocoding.Location.Request;
using GoogleApi.Entities.Maps.Geocoding.Place.Request;
using GoogleApi.Entities.Maps.Geocoding.PlusCode.Request;
using GoogleApi.Entities.Maps.Geocoding.PlusCode.Response;
using GoogleApi.Entities.Maps.Geolocation.Request;
using GoogleApi.Entities.Maps.Geolocation.Response;
using GoogleApi.Entities.Maps.Roads.NearestRoads.Request;
using GoogleApi.Entities.Maps.Roads.NearestRoads.Response;
using GoogleApi.Entities.Maps.Roads.SnapToRoads.Request;
using GoogleApi.Entities.Maps.Roads.SnapToRoads.Response;
using GoogleApi.Entities.Maps.Roads.SpeedLimits.Request;
using GoogleApi.Entities.Maps.Roads.SpeedLimits.Response;
using GoogleApi.Entities.Maps.StaticMaps.Request;
using GoogleApi.Entities.Maps.StaticMaps.Response;
using GoogleApi.Entities.Maps.StreetView.Request;
using GoogleApi.Entities.Maps.StreetView.Response;
using GoogleApi.Entities.Maps.TimeZone.Request;
using GoogleApi.Entities.Maps.TimeZone.Response;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using static GoogleApi.GoogleMaps;
using Byteology.GoogleApiModule.Options;
using Byteology.GoogleApiModule.Localization;
using Byteology.GoogleApiModule.Permissions;
using Byteology.GoogleApiModule.Apis.Maps.Inputs;

namespace Byteology.GoogleApiModule.Apis.Maps
{
    public class GoogleMapsAppService: ApiBaseAppService, IGoogleMapsAppService
    {
        private readonly GoogleMapsManager Manager;

        public GoogleMapsAppService(IOptions<GoogleApiModuleOptions> options, IStringLocalizer<GoogleApiModuleResource> localizer,
             IServiceProvider serviceProvider, GoogleMapsManager manager)
            : base(options, localizer, serviceProvider, Enums.EndPointType.Maps)
        {
            Manager = manager;
        }

        public virtual async Task<DirectionsResponse> DirectionsAsync(GoogleMapsDirectionsInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Maps.Directions);

            return await Manager.DirectionsAsync(input);
        }

        public virtual async Task<DistanceMatrixResponse> DistanceAsync(GoogleMapsDistanceInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Maps.DistanceMatrix);

            return await Manager.DistanceAsync(input);
        }

        public virtual async Task<ElevationResponse> ElevationAsync(GoogleMapsElevationInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Maps.Elevation);

            return await Manager.ElevationAsync(input);
        }

        public virtual async Task<GeocodeResponse> GeocodeAddressAsync(GoogleMapsGeocodeAddressInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Maps.Geocode.Address);

            return await Manager.GeocodeAddressAsync(input);
        }

        public virtual async Task<GeocodeResponse> GeocodeLocationAsync(GoogleMapsGeocodeLocationInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Maps.Geocode.Location);

            return await Manager.GeocodeLocationAsync(input);
        }

        public virtual async Task<GeocodeResponse> GeocodePlaceAsync(GoogleMapsGeocodePlaceInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Maps.Geocode.Place);

            return await Manager.GeocodePlaceAsync(input);
        }

        public virtual async Task<PlusCodeGeocodeResponse> GeocodePlusCodeAsync(GoogleMapsGeocodePlusCodeInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Maps.Geocode.PlusCode);

            return await Manager.GeocodePlusCodeAsync(input);
        }

        public virtual async Task<GeolocationResponse> GeolocationAsync(GoogleMapsGeolocationInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Maps.Geolocation);

            return await Manager.GeolocationAsync(input);
        }

        public virtual async Task<NearestRoadsResponse> NearestRoadsAsync(GoogleMapsNearestRoadsInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Maps.Roads.NearestRoads);

            return await Manager.NearestRoadsAsync(input);
        }

        public virtual async Task<SnapToRoadsResponse> SnapToRoadsAsync(GoogleMapsSnapToRoadsInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Maps.Roads.SnapToRoads);

            return await Manager.SnapToRoadsAsync(input);
        }

        public virtual async Task<SpeedLimitsResponse> SpeedLimitsAsync(GoogleMapsRoadsSpeedLimitInput input)
        {
            //Speed limits is a premium endpoint, meaning it will throw HTTP 403 errors if you attempt to hit it with a trial key.
            //Instead of dealing with this in test, I am adding a flag to essentailly bypass the call if you disable premium endpoints
            //in the options.
            if (Options.IncludePremiumEndpoints)
            {
                await CheckAuthorizationAsync(GoogleApiModulePermissions.Maps.Roads.SpeedLimits);

                return await Manager.SpeedLimitsAsync(input);
            }
            else
                return new SpeedLimitsResponse();

        }

        public virtual async Task<StaticMapsResponse> StaticMapsAsync(GoogleMapsStaticMapsInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Maps.StaticMaps);

            return await Manager.StaticMapsAsync(input);
        }

        public async Task<StreetViewResponse> StreetViewAsync(GoogleMapsStreetViewInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Maps.StreetView);

            return await Manager.StreetViewAsync(input);
        }

        public async Task<TimeZoneResponse> TimeZoneAsync(GoogleMapsTimeZoneInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Maps.TimeZone);

            return await Manager.TimeZoneAsync(input);
        }
    }
}
