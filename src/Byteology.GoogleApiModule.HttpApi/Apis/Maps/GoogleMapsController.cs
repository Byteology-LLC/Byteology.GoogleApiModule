using Byteology.GoogleApiModule.Apis.Maps.Inputs;
using GoogleApi.Entities.Maps.Directions.Response;
using GoogleApi.Entities.Maps.DistanceMatrix.Response;
using GoogleApi.Entities.Maps.Elevation.Response;
using GoogleApi.Entities.Maps.Geocoding;
using GoogleApi.Entities.Maps.Geocoding.PlusCode.Response;
using GoogleApi.Entities.Maps.Geolocation.Response;
using GoogleApi.Entities.Maps.Roads.NearestRoads.Response;
using GoogleApi.Entities.Maps.Roads.SnapToRoads.Response;
using GoogleApi.Entities.Maps.Roads.SpeedLimits.Response;
using GoogleApi.Entities.Maps.StaticMaps.Response;
using GoogleApi.Entities.Maps.StreetView.Response;
using GoogleApi.Entities.Maps.TimeZone.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Byteology.GoogleApiModule.Apis.Maps
{
    [RemoteService(Name = "GoogleMaps")]
    [Area("googleMaps")]
    [ControllerName("GoogleMaps")]
    [Route("api/google-apis/google-maps")]
    public class GoogleMapsController : AbpController, IGoogleMapsAppService
    {
        private readonly IGoogleMapsAppService _googleMapsAppService;

        public GoogleMapsController(IGoogleMapsAppService googleMapsAppService)
        {
            _googleMapsAppService = googleMapsAppService;
        }

        [HttpPost("directions")]
        public Task<DirectionsResponse> DirectionsAsync(GoogleMapsDirectionsInput input)
        {
            return _googleMapsAppService.DirectionsAsync(input);
        }
        
        [HttpPost("distance")]
        public Task<DistanceMatrixResponse> DistanceAsync(GoogleMapsDistanceInput input)
        {
            return _googleMapsAppService.DistanceAsync(input);
        }

        [HttpPost("elevation")]
        public Task<ElevationResponse> ElevationAsync(GoogleMapsElevationInput input)
        {
            return _googleMapsAppService.ElevationAsync(input);
        }

        [HttpPost("geocode/address")]
        public Task<GeocodeResponse> GeocodeAddressAsync(GoogleMapsGeocodeAddressInput input)
        {
            return _googleMapsAppService.GeocodeAddressAsync(input);
        }

        [HttpPost("geocode/location")]
        public Task<GeocodeResponse> GeocodeLocationAsync(GoogleMapsGeocodeLocationInput input)
        {
            return _googleMapsAppService.GeocodeLocationAsync(input);
        }

        [HttpPost("geocode/place")]
        public Task<GeocodeResponse> GeocodePlaceAsync(GoogleMapsGeocodePlaceInput input)
        {
            return _googleMapsAppService.GeocodePlaceAsync(input);
        }

        [HttpPost("geocode/plus-code")]
        public Task<PlusCodeGeocodeResponse> GeocodePlusCodeAsync(GoogleMapsGeocodePlusCodeInput input)
        {
            return _googleMapsAppService.GeocodePlusCodeAsync(input);
        }

        [HttpPost("geolocation")]
        public Task<GeolocationResponse> GeolocationAsync(GoogleMapsGeolocationInput input)
        {
            return _googleMapsAppService.GeolocationAsync(input);
        }

        [HttpPost("roads/nearest-roads")]
        public Task<NearestRoadsResponse> NearestRoadsAsync(GoogleMapsNearestRoadsInput input)
        {
            return _googleMapsAppService.NearestRoadsAsync(input);
        }

        [HttpPost("roads/snap-to-roads")]
        public Task<SnapToRoadsResponse> SnapToRoadsAsync(GoogleMapsSnapToRoadsInput input)
        {
            return _googleMapsAppService.SnapToRoadsAsync(input);
        }

        [HttpPost("speed-limits")]
        public Task<SpeedLimitsResponse> SpeedLimitsAsync(GoogleMapsRoadsSpeedLimitInput input)
        {
            return _googleMapsAppService.SpeedLimitsAsync(input);
        }

        [HttpPost("static-maps")]
        public Task<StaticMapsResponse> StaticMapsAsync(GoogleMapsStaticMapsInput input)
        {
            return _googleMapsAppService.StaticMapsAsync(input);
        }

        [HttpPost("street-view")]
        public Task<StreetViewResponse> StreetViewAsync(GoogleMapsStreetViewInput input)
        {
            return _googleMapsAppService.StreetViewAsync(input);
        }

        [HttpPost("time-zone")]
        public Task<TimeZoneResponse> TimeZoneAsync(GoogleMapsTimeZoneInput input)
        {
            return _googleMapsAppService.TimeZoneAsync(input);
        }
    }
}
