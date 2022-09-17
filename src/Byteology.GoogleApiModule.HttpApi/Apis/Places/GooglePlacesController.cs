using Byteology.GoogleApiModule.Apis.Places.Inputs;
using GoogleApi.Entities.Places.AutoComplete.Response;
using GoogleApi.Entities.Places.Details.Response;
using GoogleApi.Entities.Places.Photos.Response;
using GoogleApi.Entities.Places.QueryAutoComplete.Response;
using GoogleApi.Entities.Places.Search.Find.Response;
using GoogleApi.Entities.Places.Search.NearBy.Response;
using GoogleApi.Entities.Places.Search.Text.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
namespace Byteology.GoogleApiModule.Apis.Places
{
    [RemoteService(Name = "GooglePlaces")]
    [Area("googlePlaces")]
    [ControllerName("GooglePlaces")]
    [Route("api/google-apis/google-places")]
    public class GooglePlacesController : AbpController, IGooglePlacesAppService
    {
        private readonly IGooglePlacesAppService _googlePlacesAppService;

        public GooglePlacesController(IGooglePlacesAppService googlePlacesAppService)
        {
            _googlePlacesAppService = googlePlacesAppService;
        }

        [HttpPost("auto-complete")]
        public async Task<PlacesAutoCompleteResponse> AutoCompleteAsync(GooglePlacesAutoCompleteInput input)
        {
            return await _googlePlacesAppService.AutoCompleteAsync(input);
        }

        [HttpPost("details/{placeId}")]
        public async Task<PlacesDetailsResponse> DetailsAsync(GooglePlacesDetailsInput input)
        {
            return await _googlePlacesAppService.DetailsAsync(input);
        }

        [HttpPost("find")]
        public async Task<PlacesFindSearchResponse> FindAsync(GooglePlacesFindInput input)
        {
            return await _googlePlacesAppService.FindAsync(input);
        }

        [HttpPost("find-nearby")]
        public async Task<PlacesNearbySearchResponse> FindNearbyAsync(GooglePlacesFindNearbyInput input)
        {
            return await _googlePlacesAppService.FindNearbyAsync(input);
        }

        [HttpPost("photos")]
        public async Task<PlacesPhotosResponse> PhotosAsync(GooglePlacesPhotosInput input)
        {
            return await _googlePlacesAppService.PhotosAsync(input);
        }

        [HttpGet("photo/{photoReference}")]
        public async Task<ActionResult> GetPhotoAsync(string photoReference, [FromQuery] int? maxHeight = null, int? maxWidth = null)
        {
            var photo = await _googlePlacesAppService.PhotosAsync(new GooglePlacesPhotosInput
            {
                PhotoReference = photoReference,
                MaxHeight = maxHeight,
                MaxWidth = maxWidth
            });

            return File(photo.Buffer, "image/png");
        }

        [HttpPost("query-auto-complete")]
        public async Task<PlacesQueryAutoCompleteResponse> QueryAutoCompleteAsync(GooglePlacesQueryAutoCompleteInput input)
        {
            return await _googlePlacesAppService.QueryAutoCompleteAsync(input);
        }

        [HttpPost("text-search")]
        public async Task<PlacesTextSearchResponse> TextSearchAsync(GooglePlacesTextSearchInput input)
        {
            return await _googlePlacesAppService.TextSearchAsync(input);
        }
    }
}
