using Byteology.GoogleApiModule.Enums;
using Byteology.GoogleApiModule.Localization;
using Byteology.GoogleApiModule.Options;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using GoogleApi;
using GoogleApi.Entities.Places.AutoComplete.Response;
using GoogleApi.Entities.Places.Details.Response;
using GoogleApi.Entities.Places.Photos.Response;
using GoogleApi.Entities.Places.QueryAutoComplete.Response;
using GoogleApi.Entities.Places.Search.Find.Response;
using GoogleApi.Entities.Places.Search.NearBy.Response;
using GoogleApi.Entities.Places.Search.Text.Response;
using System;
using System.Threading.Tasks;
using GoogleApi.Entities.Places.Search.Find.Request;
using GoogleApi.Entities.Places.Photos.Request;
using GoogleApi.Entities.Places.Search.NearBy.Request;
using GoogleApi.Entities.Places.Details.Request;
using GoogleApi.Entities.Places.Search.Text.Request;
using GoogleApi.Entities.Places.AutoComplete.Request;
using GoogleApi.Entities.Places.QueryAutoComplete.Request;
using Byteology.GoogleApiModule.Apis.Places.Inputs;
using Volo.Abp.Users;
using Volo.Abp.ObjectMapping;
using Byteology.GoogleApiModule.Settings;

namespace Byteology.GoogleApiModule.Apis.Places
{
    public class GooglePlacesManager : ApiManagerBase
    {
        public GooglePlacesManager(IOptions<GoogleApiModuleOptions> options, IStringLocalizer<GoogleApiModuleResource> localizer,
            IServiceProvider serviceProvider, ICurrentUser currentUser, IObjectMapper objectMapper, GoogleApiModuleSettingsManager settingsManager)
            : base(localizer, serviceProvider, currentUser, objectMapper, settingsManager, EndPointType.Places)
        {
        }

        public async Task<PlacesAutoCompleteResponse> AutoCompleteAsync(GooglePlacesAutoCompleteInput input)
        {
            var _autocompleteApi = new GooglePlaces.AutoCompleteApi();

            var request = ObjectMapper.Map<GooglePlacesAutoCompleteInput, PlacesAutoCompleteRequest>(input);
            request.Key = Settings.ApiKey;
            request.SessionToken = GetSessionToken();

            var response = await _autocompleteApi.QueryAsync(request);

            CheckResponse(response);

            return response;
        }


        public async Task<PlacesDetailsResponse> DetailsAsync(GooglePlacesDetailsInput input)
        {
            var _detailsApi = new GooglePlaces.DetailsApi();

            var request = ObjectMapper.Map<GooglePlacesDetailsInput, PlacesDetailsRequest>(input);
            request.Key = Settings.ApiKey;
            request.SessionToken = GetSessionToken();

            var response = await _detailsApi.QueryAsync(request);

            CheckResponse(response);

            return response;
        }


        public async Task<PlacesFindSearchResponse> FindAsync(GooglePlacesFindInput input)
        {

            var _findApi = new GooglePlaces.Search.FindSearchApi();

            var request = ObjectMapper.Map<GooglePlacesFindInput, PlacesFindSearchRequest>(input);
            request.Key = Settings.ApiKey;

            var response = await _findApi.QueryAsync(request);

            CheckResponse(response);

            return response;
        }

        public async Task<PlacesNearbySearchResponse> FindNearbyAsync(GooglePlacesFindNearbyInput input)
        {

            var _nearbyApi = new GooglePlaces.Search.NearBySearchApi();

            var request = ObjectMapper.Map<GooglePlacesFindNearbyInput, PlacesNearBySearchRequest>(input);
            request.Key = Settings.ApiKey;

            var response = await _nearbyApi.QueryAsync(request);

            CheckResponse(response);

            return response;
        }

        public async Task<PlacesPhotosResponse> PhotosAsync(GooglePlacesPhotosInput input)
        {

            var _photosApi = new GooglePlaces.PhotosApi();

            var request = ObjectMapper.Map<GooglePlacesPhotosInput, PlacesPhotosRequest>(input);
            request.Key = Settings.ApiKey;

            var response = await _photosApi.QueryAsync(request);

            CheckResponse(response);

            return response;
        }

        public async Task<PlacesQueryAutoCompleteResponse> QueryAutoCompleteAsync(GooglePlacesQueryAutoCompleteInput input)
        {

            var _queryAutoCompleteApi = new GooglePlaces.QueryAutoCompleteApi();

            var request = ObjectMapper.Map<GooglePlacesQueryAutoCompleteInput, PlacesQueryAutoCompleteRequest>(input);
            request.Key = Settings.ApiKey;

            var response = await _queryAutoCompleteApi.QueryAsync(request);

            CheckResponse(response);

            return response;
        }

        public async Task<PlacesTextSearchResponse> TextSearchAsync(GooglePlacesTextSearchInput input)
        {

            var _textSearchApi = new GooglePlaces.Search.TextSearchApi();

            var request = ObjectMapper.Map<GooglePlacesTextSearchInput, PlacesTextSearchRequest>(input);
            request.Key = Settings.ApiKey;

            var response = await _textSearchApi.QueryAsync(request);

            CheckResponse(response);

            return response;
        }
    }
}
