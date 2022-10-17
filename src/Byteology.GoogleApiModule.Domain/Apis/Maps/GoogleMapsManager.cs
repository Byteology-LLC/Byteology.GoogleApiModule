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
using Byteology.GoogleApiModule.Apis.Maps.Inputs;
using Volo.Abp.Domain.Services;
using Volo.Abp.Users;
using Byteology.GoogleApiModule.Enums;
using Volo.Abp.ObjectMapping;
using Byteology.GoogleApiModule.Settings;
using Volo.Abp.DependencyInjection;

namespace Byteology.GoogleApiModule.Apis.Maps
{
    public class GoogleMapsManager: ApiManagerBase, ITransientDependency
    {

        public GoogleMapsManager(IStringLocalizer<GoogleApiModuleResource> localizer,
            IServiceProvider serviceProvider, ICurrentUser currentUser, IObjectMapper objectMapper, GoogleApiModuleSettingsManager settingsManager)
            : base(localizer, serviceProvider, currentUser, objectMapper, settingsManager, EndPointType.Maps)
        {
        }

        public virtual async Task<DirectionsResponse> DirectionsAsync(GoogleMapsDirectionsInput input)
        {
            var _directionsApi = new DirectionsApi();

            var request = ObjectMapper.Map<GoogleMapsDirectionsInput, DirectionsRequest>(input);
            request.Key = Settings.ApiKey;

            var response = await _directionsApi.QueryAsync(request);

            CheckResponse(response);

            return response;
        }

        public virtual async Task<DistanceMatrixResponse> DistanceAsync(GoogleMapsDistanceInput input)
        {
            var _distanceApi = new DistanceMatrixApi();

            var request = ObjectMapper.Map<GoogleMapsDistanceInput, DistanceMatrixRequest>(input);
            request.Key = Settings.ApiKey;

            var response = await _distanceApi.QueryAsync(request);

            CheckResponse(response);

            return response;
        }

        public virtual async Task<ElevationResponse> ElevationAsync(GoogleMapsElevationInput input)
        {
            var _elevationApi = new ElevationApi();

            var request = ObjectMapper.Map<GoogleMapsElevationInput, ElevationRequest>(input);
            request.Key = Settings.ApiKey;

            var response = await _elevationApi.QueryAsync(request);

            CheckResponse(response);

            return response;
        }

        public virtual async Task<GeocodeResponse> GeocodeAddressAsync(GoogleMapsGeocodeAddressInput input)
        {
            var _geocodeAddressApi = new Geocode.AddressGeocodeApi();

            var request = ObjectMapper.Map<GoogleMapsGeocodeAddressInput, AddressGeocodeRequest>(input);
            request.Key = Settings.ApiKey;

            var response = await _geocodeAddressApi.QueryAsync(request);

            CheckResponse(response);

            return response;
        }

        public virtual async Task<GeocodeResponse> GeocodeLocationAsync(GoogleMapsGeocodeLocationInput input)
        {
            var _geocodeLocationApi = new Geocode.LocationGeocodeApi();

            var request = ObjectMapper.Map<GoogleMapsGeocodeLocationInput, LocationGeocodeRequest>(input);
            request.Key = Settings.ApiKey;

            var response = await _geocodeLocationApi.QueryAsync(request);

            CheckResponse(response);

            return response;
        }

        public virtual async Task<GeocodeResponse> GeocodePlaceAsync(GoogleMapsGeocodePlaceInput input)
        {
            var _geocodePlaceApi = new Geocode.PlaceGeocodeApi();

            var request = ObjectMapper.Map<GoogleMapsGeocodePlaceInput, PlaceGeocodeRequest>(input);
            request.Key = Settings.ApiKey;

            var response = await _geocodePlaceApi.QueryAsync(request);

            CheckResponse(response);

            return response;
        }

        public virtual async Task<PlusCodeGeocodeResponse> GeocodePlusCodeAsync(GoogleMapsGeocodePlusCodeInput input)
        {
            var _geocodePlusCodeApi = new Geocode.PlusCodeGeocodeApi();

            var request = ObjectMapper.Map<GoogleMapsGeocodePlusCodeInput, PlusCodeGeocodeRequest>(input);
            request.Key = Settings.ApiKey;

            var response = await _geocodePlusCodeApi.QueryAsync(request);

            CheckResponse(response);

            return response;
        }

        public virtual async Task<GeolocationResponse> GeolocationAsync(GoogleMapsGeolocationInput input)
        {
            var _geolocationApi = new GeolocationApi();

            var request = ObjectMapper.Map<GoogleMapsGeolocationInput, GeolocationRequest>(input);
            request.Key = Settings.ApiKey;

            var response = await _geolocationApi.QueryAsync(request);

            CheckResponse(response);

            return response;
        }

        public virtual async Task<NearestRoadsResponse> NearestRoadsAsync(GoogleMapsNearestRoadsInput input)
        {
            var _nearestRoadsApi = new Roads.NearestRoadsApi();

            var request = ObjectMapper.Map<GoogleMapsNearestRoadsInput, NearestRoadsRequest>(input);
            request.Key = Settings.ApiKey;

            var response = await _nearestRoadsApi.QueryAsync(request);

            CheckResponse(response);

            return response;
        }

        public virtual async Task<SnapToRoadsResponse> SnapToRoadsAsync(GoogleMapsSnapToRoadsInput input)
        {
            var _snapToRoadApi = new Roads.SnapToRoadApi();

            var request = ObjectMapper.Map<GoogleMapsSnapToRoadsInput, SnapToRoadsRequest>(input);
            request.Key = Settings.ApiKey;

            var response = await _snapToRoadApi.QueryAsync(request);

            CheckResponse(response);

            return response;
        }

        public virtual async Task<SpeedLimitsResponse> SpeedLimitsAsync(GoogleMapsRoadsSpeedLimitInput input)
        {
            //Speed limits is a premium endpoint, meaning it will throw HTTP 403 errors if you attempt to hit it with a trial key.
            //Instead of dealing with this in test, I am adding a flag to essentailly bypass the call if you disable premium endpoints
            //in the options.
            if (Settings.IncludePremiumEndpoints)
            {

                var _speedLimitsApi = new Roads.SpeedLimitsApi();

                var request = ObjectMapper.Map<GoogleMapsRoadsSpeedLimitInput, SpeedLimitsRequest>(input);
                request.Key = Settings.ApiKey;

                var response = await _speedLimitsApi.QueryAsync(request);

                CheckResponse(response);

                return response;
            }
            else
                return new SpeedLimitsResponse();

        }

        public virtual async Task<StaticMapsResponse> StaticMapsAsync(GoogleMapsStaticMapsInput input)
        {
            var _staticMapsApi = new StaticMapsApi();

            var request = ObjectMapper.Map<GoogleMapsStaticMapsInput, StaticMapsRequest>(input);
            request.Key = Settings.ApiKey;

            var response = await _staticMapsApi.QueryAsync(request);

            CheckResponse(response);

            return response;
        }

        public async Task<StreetViewResponse> StreetViewAsync(GoogleMapsStreetViewInput input)
        {
            var _streetViewApi = new StreetViewApi();

            var request = ObjectMapper.Map<GoogleMapsStreetViewInput, StreetViewRequest>(input);
            request.Key = Settings.ApiKey;

            var response = await _streetViewApi.QueryAsync(request);

            CheckResponse(response);

            return response;
        }

        public async Task<TimeZoneResponse> TimeZoneAsync(GoogleMapsTimeZoneInput input)
        {
            var _timeZoneApi = new TimeZoneApi();

            var request = ObjectMapper.Map<GoogleMapsTimeZoneInput, TimeZoneRequest>(input);
            request.Key = Settings.ApiKey;

            var response = await _timeZoneApi.QueryAsync(request);

            CheckResponse(response);

            return response;
        }
    }
}
