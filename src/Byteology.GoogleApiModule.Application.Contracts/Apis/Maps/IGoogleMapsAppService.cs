using Volo.Abp.Application.Services;
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
using System.Threading.Tasks;
using Byteology.GoogleApiModule.Apis.Maps.Inputs;

namespace Byteology.GoogleApiModule.Apis.Maps
{
    public interface IGoogleMapsAppService : IApplicationService
    {
        Task<DirectionsResponse> DirectionsAsync(GoogleMapsDirectionsInput input);
        Task<DistanceMatrixResponse> DistanceAsync(GoogleMapsDistanceInput input);
        Task<ElevationResponse> ElevationAsync(GoogleMapsElevationInput input);
        Task<GeocodeResponse> GeocodeAddressAsync(GoogleMapsGeocodeAddressInput input);
        Task<GeocodeResponse> GeocodeLocationAsync(GoogleMapsGeocodeLocationInput input);
        Task<GeocodeResponse> GeocodePlaceAsync(GoogleMapsGeocodePlaceInput input);
        Task<PlusCodeGeocodeResponse> GeocodePlusCodeAsync(GoogleMapsGeocodePlusCodeInput input);
        Task<GeolocationResponse> GeolocationAsync(GoogleMapsGeolocationInput input);
        Task<NearestRoadsResponse> NearestRoadsAsync(GoogleMapsNearestRoadsInput input);
        Task<SnapToRoadsResponse> SnapToRoadsAsync(GoogleMapsSnapToRoadsInput input);
        Task<SpeedLimitsResponse> SpeedLimitsAsync(GoogleMapsRoadsSpeedLimitInput input);
        Task<StaticMapsResponse> StaticMapsAsync(GoogleMapsStaticMapsInput input);
        Task<StreetViewResponse> StreetViewAsync(GoogleMapsStreetViewInput input);
        Task<TimeZoneResponse> TimeZoneAsync(GoogleMapsTimeZoneInput input);
    }
}
