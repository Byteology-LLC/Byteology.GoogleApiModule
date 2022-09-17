using Byteology.GoogleApiModule.Apis.Search.Inputs;
using GoogleApi.Entities.Search;
using GoogleApi.Entities.Search.Video.Channels.Response;
using GoogleApi.Entities.Search.Video.Playlists.Response;
using GoogleApi.Entities.Search.Video.Videos.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Byteology.GoogleApiModule.Apis.Search
{
    [RemoteService(Name = "GoogleSearch")]
    [Area("googleSearch")]
    [ControllerName("GoogleSearch")]
    [Route("api/google-apis/google-search")]
    public class GoogleSearchController : AbpController, IGoogleSearchAppService
    {
        private readonly IGoogleSearchAppService _googleSearchAppService;

        public GoogleSearchController(IGoogleSearchAppService googleSearchAppService)
        {
            _googleSearchAppService = googleSearchAppService;
        }

        [HttpPost("image-search")]
        public Task<BaseSearchResponse> ImageSearchAsync(GoogleSearchImageSearchInput input)
        {
            return _googleSearchAppService.ImageSearchAsync(input);
        }

        [HttpPost("video-search/channel")]
        public Task<ChannelSearchResponse> VideoChannelSearchAsync(GoogleSearchVideoSearchInput input)
        {
            return _googleSearchAppService.VideoChannelSearchAsync(input);
        }

        [HttpPost("video-search/playlist")]
        public Task<PlaylistSearchResponse> VideoPlaylistSearchAsync(GoogleSearchVideoPlaylistSearchInput input)
        {
            return _googleSearchAppService.VideoPlaylistSearchAsync(input);
        }

        [HttpPost("video-search")]
        public Task<VideoSearchResponse> VideoSearchAsync(GoogleSearchVideoSearchInput input)
        {
            return _googleSearchAppService.VideoSearchAsync(input);
        }

        [HttpPost("web-search")]
        public Task<BaseSearchResponse> WebSearchAsync(GoogleSearchWebSearchInput input)
        {
            return _googleSearchAppService.WebSearchAsync(input);
        }
    }
}
