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
using Byteology.GoogleApiModule.Permissions;
using Byteology.GoogleApiModule.Apis.Places.Inputs;

namespace Byteology.GoogleApiModule.Apis.Places
{
    public class GooglePlacesAppService : ApiBaseAppService, IGooglePlacesAppService
    {
        public GooglePlacesAppService(IOptions<GoogleApiModuleOptions> options, IStringLocalizer<GoogleApiModuleResource> localizer, IServiceProvider serviceProvider) : base(options, localizer, serviceProvider, EndPointType.Places)
        {
        }

        public async Task<PlacesAutoCompleteResponse> AutoCompleteAsync(GooglePlacesAutoCompleteInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Places.AutoComplete);

            var _autocompleteApi = new GooglePlaces.AutoCompleteApi();

            var request = ObjectMapper.Map<GooglePlacesAutoCompleteInput, PlacesAutoCompleteRequest>(input);
            request.Key = Options.APIKey;

            var response = await _autocompleteApi.QueryAsync(request, GetCancellationToken());

            CheckResponse(response);

            return response;
        }


        public async Task<PlacesDetailsResponse> DetailsAsync(GooglePlacesDetailsInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Places.Details);

            var _detailsApi = new GooglePlaces.DetailsApi();

            var request = ObjectMapper.Map<GooglePlacesDetailsInput, PlacesDetailsRequest>(input);
            request.Key = Options.APIKey;
            request.SessionToken = GetSessionToken();

            var response = await _detailsApi.QueryAsync(request, GetCancellationToken());

            CheckResponse(response);

            return response;
        }


        public async Task<PlacesFindSearchResponse> FindAsync(GooglePlacesFindInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Places.Search.Find);

            var _findApi = new GooglePlaces.Search.FindSearchApi();

            var request = ObjectMapper.Map<GooglePlacesFindInput, PlacesFindSearchRequest>(input);
            request.Key = Options.APIKey;

            var response = await _findApi.QueryAsync(request, GetCancellationToken());

            CheckResponse(response);

            return response;
        }

        public async Task<PlacesNearbySearchResponse> FindNearbyAsync(GooglePlacesFindNearbyInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Places.Search.NearBy);

            var _nearbyApi = new GooglePlaces.Search.NearBySearchApi();

            var request = ObjectMapper.Map<GooglePlacesFindNearbyInput, PlacesNearBySearchRequest>(input);
            request.Key = Options.APIKey;

            var response = await _nearbyApi.QueryAsync(request, GetCancellationToken());

            CheckResponse(response);

            return response;
        }

        public async Task<PlacesPhotosResponse> PhotosAsync(GooglePlacesPhotosInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Places.Photos);

            var _photosApi = new GooglePlaces.PhotosApi();

            var request = ObjectMapper.Map<GooglePlacesPhotosInput, PlacesPhotosRequest>(input);
            request.Key = Options.APIKey;

            var response = await _photosApi.QueryAsync(request, GetCancellationToken());

            CheckResponse(response);

            return response;
        }

        public async Task<PlacesQueryAutoCompleteResponse> QueryAutoCompleteAsync(GooglePlacesQueryAutoCompleteInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Places.QueryAutoComplete);

            var _queryAutoCompleteApi = new GooglePlaces.QueryAutoCompleteApi();

            var request = ObjectMapper.Map<GooglePlacesQueryAutoCompleteInput, PlacesQueryAutoCompleteRequest>(input);
            request.Key = Options.APIKey;

            var response = await _queryAutoCompleteApi.QueryAsync(request, GetCancellationToken());

            CheckResponse(response);

            return response;
        }

        public async Task<PlacesTextSearchResponse> TextSearchAsync(GooglePlacesTextSearchInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Places.Search.Text);

            var _textSearchApi = new GooglePlaces.Search.TextSearchApi();

            var request = ObjectMapper.Map<GooglePlacesTextSearchInput, PlacesTextSearchRequest>(input);
            request.Key = Options.APIKey;

            var response = await _textSearchApi.QueryAsync(request, GetCancellationToken());

            CheckResponse(response);

            return response;
        }
    }
}
