using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using GoogleApi.Entities.Places.AutoComplete.Response;
using GoogleApi.Entities.Places.QueryAutoComplete.Response;
using GoogleApi.Entities.Places.Photos.Response;
using GoogleApi.Entities.Places.Details.Response;
using GoogleApi.Entities.Places.Search.Find.Response;
using GoogleApi.Entities.Places.Search.NearBy.Response;
using GoogleApi.Entities.Places.Search.Text.Response;
using Byteology.GoogleApiModule.Apis.Places.Inputs;

namespace Byteology.GoogleApiModule.Apis.Places
{
    public interface IGooglePlacesAppService: IApplicationService
    {
        Task<PlacesAutoCompleteResponse> AutoCompleteAsync(GooglePlacesAutoCompleteInput input);
        Task<PlacesQueryAutoCompleteResponse> QueryAutoCompleteAsync(GooglePlacesQueryAutoCompleteInput input);

        Task<PlacesPhotosResponse> PhotosAsync(GooglePlacesPhotosInput input);

        Task<PlacesDetailsResponse> DetailsAsync(GooglePlacesDetailsInput input);

        Task<PlacesFindSearchResponse> FindAsync(GooglePlacesFindInput input);

        Task<PlacesNearbySearchResponse> FindNearbyAsync(GooglePlacesFindNearbyInput input);

        Task<PlacesTextSearchResponse> TextSearchAsync(GooglePlacesTextSearchInput input);
    }
}
