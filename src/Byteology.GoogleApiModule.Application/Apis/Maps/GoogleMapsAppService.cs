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
        public GoogleMapsAppService(IOptions<GoogleApiModuleOptions> options, IStringLocalizer<GoogleApiModuleResource> localizer,
             IServiceProvider serviceProvider)
            : base(options, localizer, serviceProvider, Enums.EndPointType.Maps)
        {

        }

        public virtual async Task<DirectionsResponse> DirectionsAsync(GoogleMapsDirectionsInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Maps.Directions);

            var _directionsApi = new DirectionsApi();

            var request = ObjectMapper.Map<GoogleMapsDirectionsInput, DirectionsRequest>(input);
            request.Key = Options.APIKey;

            var response = await _directionsApi.QueryAsync(request, GetCancellationToken());

            CheckResponse(response);

            return response;
        }

        public virtual async Task<DistanceMatrixResponse> DistanceAsync(GoogleMapsDistanceInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Maps.DistanceMatrix);

            var _distanceApi = new DistanceMatrixApi();

            var request = ObjectMapper.Map<GoogleMapsDistanceInput, DistanceMatrixRequest>(input);
            request.Key = Options.APIKey;

            var response = await _distanceApi.QueryAsync(request, GetCancellationToken());

            CheckResponse(response);

            return response;
        }

        public virtual async Task<ElevationResponse> ElevationAsync(GoogleMapsElevationInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Maps.Elevation);

            var _elevationApi = new ElevationApi();

            var request = ObjectMapper.Map<GoogleMapsElevationInput, ElevationRequest>(input);
            request.Key = Options.APIKey;

            var response = await _elevationApi.QueryAsync(request, GetCancellationToken());

            CheckResponse(response);

            return response;
        }

        public virtual async Task<GeocodeResponse> GeocodeAddressAsync(GoogleMapsGeocodeAddressInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Maps.Geocode.Address);

            var _geocodeAddressApi = new Geocode.AddressGeocodeApi();

            var request = ObjectMapper.Map<GoogleMapsGeocodeAddressInput, AddressGeocodeRequest>(input);
            request.Key = Options.APIKey;

            var response = await _geocodeAddressApi.QueryAsync(request, GetCancellationToken());

            CheckResponse(response);

            return response;
        }

        public virtual async Task<GeocodeResponse> GeocodeLocationAsync(GoogleMapsGeocodeLocationInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Maps.Geocode.Location);

            var _geocodeLocationApi = new Geocode.LocationGeocodeApi();

            var request = ObjectMapper.Map<GoogleMapsGeocodeLocationInput, LocationGeocodeRequest>(input);
            request.Key = Options.APIKey;

            var response = await _geocodeLocationApi.QueryAsync(request, GetCancellationToken());

            CheckResponse(response);

            return response;
        }

        public virtual async Task<GeocodeResponse> GeocodePlaceAsync(GoogleMapsGeocodePlaceInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Maps.Geocode.Place);

            var _geocodePlaceApi = new Geocode.PlaceGeocodeApi();

            var request = ObjectMapper.Map<GoogleMapsGeocodePlaceInput, PlaceGeocodeRequest>(input);
            request.Key = Options.APIKey;

            var response = await _geocodePlaceApi.QueryAsync(request, GetCancellationToken());

            CheckResponse(response);

            return response;
        }

        public virtual async Task<PlusCodeGeocodeResponse> GeocodePlusCodeAsync(GoogleMapsGeocodePlusCodeInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Maps.Geocode.PlusCode);

            var _geocodePlusCodeApi = new Geocode.PlusCodeGeocodeApi();

            var request = ObjectMapper.Map<GoogleMapsGeocodePlusCodeInput, PlusCodeGeocodeRequest>(input);
            request.Key = Options.APIKey;

            var response = await _geocodePlusCodeApi.QueryAsync(request, GetCancellationToken());

            CheckResponse(response);

            return response;
        }

        public virtual async Task<GeolocationResponse> GeolocationAsync(GoogleMapsGeolocationInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Maps.Geolocation);

            var _geolocationApi = new GeolocationApi();

            var request = ObjectMapper.Map<GoogleMapsGeolocationInput, GeolocationRequest>(input);
            request.Key = Options.APIKey;

            var response = await _geolocationApi.QueryAsync(request, GetCancellationToken());

            CheckResponse(response);

            return response;
        }

        public virtual async Task<NearestRoadsResponse> NearestRoadsAsync(GoogleMapsNearestRoadsInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Maps.Roads.NearestRoads);

            var _nearestRoadsApi = new Roads.NearestRoadsApi();

            var request = ObjectMapper.Map<GoogleMapsNearestRoadsInput, NearestRoadsRequest>(input);
            request.Key = Options.APIKey;

            var response = await _nearestRoadsApi.QueryAsync(request, GetCancellationToken());

            CheckResponse(response);

            return response;
        }

        public virtual async Task<SnapToRoadsResponse> SnapToRoadsAsync(GoogleMapsSnapToRoadsInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Maps.Roads.SnapToRoads);

            var _snapToRoadApi = new Roads.SnapToRoadApi();

            var request = ObjectMapper.Map<GoogleMapsSnapToRoadsInput, SnapToRoadsRequest>(input);
            request.Key = Options.APIKey;

            var response = await _snapToRoadApi.QueryAsync(request, GetCancellationToken());

            CheckResponse(response);

            return response;
        }

        public virtual async Task<SpeedLimitsResponse> SpeedLimitsAsync(GoogleMapsRoadsSpeedLimitInput input)
        {
            //Speed limits is a premium endpoint, meaning it will throw HTTP 403 errors if you attempt to hit it with a trial key.
            //Instead of dealing with this in test, I am adding a flag to essentailly bypass the call if you disable premium endpoints
            //in the options.
            if (Options.IncludePremiumEndpoints)
            {
                await CheckAuthorizationAsync(GoogleApiModulePermissions.Maps.Roads.SpeedLimits);

                var _speedLimitsApi = new Roads.SpeedLimitsApi();

                var request = ObjectMapper.Map<GoogleMapsRoadsSpeedLimitInput, SpeedLimitsRequest>(input);
                request.Key = Options.APIKey;

                var response = await _speedLimitsApi.QueryAsync(request, GetCancellationToken());

                CheckResponse(response);

                return response;
            }
            else
                return new SpeedLimitsResponse();

        }

        public virtual async Task<StaticMapsResponse> StaticMapsAsync(GoogleMapsStaticMapsInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Maps.StaticMaps);

            var _staticMapsApi = new StaticMapsApi();

            var request = ObjectMapper.Map<GoogleMapsStaticMapsInput, StaticMapsRequest>(input);
            request.Key = Options.APIKey;

            var response = await _staticMapsApi.QueryAsync(request, GetCancellationToken());

            CheckResponse(response);

            return response;
        }

        public async Task<StreetViewResponse> StreetViewAsync(GoogleMapsStreetViewInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Maps.StreetView);

            var _streetViewApi = new StreetViewApi();

            var request = ObjectMapper.Map<GoogleMapsStreetViewInput, StreetViewRequest>(input);
            request.Key = Options.APIKey;

            var response = await _streetViewApi.QueryAsync(request, GetCancellationToken());

            CheckResponse(response);

            return response;
        }

        public async Task<TimeZoneResponse> TimeZoneAsync(GoogleMapsTimeZoneInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Maps.TimeZone);

            var _timeZoneApi = new TimeZoneApi();

            var request = ObjectMapper.Map<GoogleMapsTimeZoneInput, TimeZoneRequest>(input);
            request.Key = Options.APIKey;

            var response = await _timeZoneApi.QueryAsync(request, GetCancellationToken());

            CheckResponse(response);

            return response;
        }
    }
}
