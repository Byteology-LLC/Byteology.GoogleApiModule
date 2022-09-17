using Volo.Abp.Application.Services;
using GoogleApi.Entities.Search.Video.Channels.Response;
using GoogleApi.Entities.Search.Video.Playlists.Response;
using GoogleApi.Entities.Search.Video.Videos.Response;
using GoogleApi.Entities.Search;
using Byteology.GoogleApiModule.Apis.Search.Inputs;
using System.Threading.Tasks;

namespace Byteology.GoogleApiModule.Apis.Search
{
    public interface IGoogleSearchAppService: IApplicationService
    {
        Task<BaseSearchResponse> ImageSearchAsync(GoogleSearchImageSearchInput input);
        Task<BaseSearchResponse> WebSearchAsync(GoogleSearchWebSearchInput input);
        Task<ChannelSearchResponse> VideoChannelSearchAsync(GoogleSearchVideoSearchInput input);
        Task<PlaylistSearchResponse> VideoPlaylistSearchAsync(GoogleSearchVideoPlaylistSearchInput input);
        Task<VideoSearchResponse> VideoSearchAsync(GoogleSearchVideoSearchInput input);
    }
}
