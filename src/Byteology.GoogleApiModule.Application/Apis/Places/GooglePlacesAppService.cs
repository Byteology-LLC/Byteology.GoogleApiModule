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
using Byteology.GoogleApiModule.Apis.Maps;
using Byteology.GoogleApiModule.Settings;

namespace Byteology.GoogleApiModule.Apis.Places
{
    public class GooglePlacesAppService : ApiBaseAppService, IGooglePlacesAppService
    {
        private readonly GooglePlacesManager Manager;
        public GooglePlacesAppService(GoogleApiModuleSettingsManager settingsManager, IStringLocalizer<GoogleApiModuleResource> localizer,
            IServiceProvider serviceProvider, GooglePlacesManager manager) : base(settingsManager, localizer, serviceProvider, Enums.EndPointType.Places)
        {
            Manager = manager;
        }

        public async Task<PlacesAutoCompleteResponse> AutoCompleteAsync(GooglePlacesAutoCompleteInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Places.AutoComplete);

            return await Manager.AutoCompleteAsync(input);
        }


        public async Task<PlacesDetailsResponse> DetailsAsync(GooglePlacesDetailsInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Places.Details);

            return await Manager.DetailsAsync(input);
        }


        public async Task<PlacesFindSearchResponse> FindAsync(GooglePlacesFindInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Places.Search.Find);

            return await Manager.FindAsync(input);
        }

        public async Task<PlacesNearbySearchResponse> FindNearbyAsync(GooglePlacesFindNearbyInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Places.Search.NearBy);

            return await Manager.FindNearbyAsync(input);
        }

        public async Task<PlacesPhotosResponse> PhotosAsync(GooglePlacesPhotosInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Places.Photos);

            return await Manager.PhotosAsync(input);
        }

        public async Task<PlacesQueryAutoCompleteResponse> QueryAutoCompleteAsync(GooglePlacesQueryAutoCompleteInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Places.QueryAutoComplete);

            return await Manager.QueryAutoCompleteAsync(input);
        }

        public async Task<PlacesTextSearchResponse> TextSearchAsync(GooglePlacesTextSearchInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Places.Search.Text);

            return await Manager.TextSearchAsync(input);
        }
    }
}
