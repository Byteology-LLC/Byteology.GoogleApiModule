using Byteology.GoogleApiModule.Apis.Search.Inputs;
using Byteology.GoogleApiModule.Enums;
using Byteology.GoogleApiModule.Localization;
using Byteology.GoogleApiModule.Options;
using Byteology.GoogleApiModule.Permissions;
using GoogleApi.Entities.Search;
using GoogleApi.Entities.Search.Image.Request;
using GoogleApi.Entities.Search.Video.Channels.Request;
using GoogleApi.Entities.Search.Video.Channels.Response;
using GoogleApi.Entities.Search.Video.Playlists.Request;
using GoogleApi.Entities.Search.Video.Playlists.Response;
using GoogleApi.Entities.Search.Video.Videos.Request;
using GoogleApi.Entities.Search.Video.Videos.Response;
using GoogleApi.Entities.Search.Web.Request;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using Volo.Abp;

namespace Byteology.GoogleApiModule.Apis.Search
{
    public class GoogleSearchAppService : ApiBaseAppService, IGoogleSearchAppService
    {
        public GoogleSearchAppService(IOptions<GoogleApiModuleOptions> options, IStringLocalizer<GoogleApiModuleResource> localizer, IServiceProvider serviceProvider, EndPointType type) : base(options, localizer, serviceProvider, type)
        {
        }

        public async Task<BaseSearchResponse> ImageSearchAsync(GoogleSearchImageSearchInput input)
        {
            var _imageSearchApi = new GoogleApi.GoogleSearch.ImageSearchApi();
            if (Options.SearchEngineId == null)
            {
                throw new UserFriendlyException(Localizer["Error:MissingSearchEngineId"]);
            }


            await CheckAuthorizationAsync(GoogleApiModulePermissions.Search.Image);

            var request = ObjectMapper.Map<GoogleSearchImageSearchInput, ImageSearchRequest>(input);
            request.Key = Options.APIKey;
            request.SearchEngineId = Options.SearchEngineId;

            var response = await _imageSearchApi.QueryAsync(request, GetCancellationToken());

            CheckResponse(response);

            return response;
        }

        public async Task<ChannelSearchResponse> VideoChannelSearchAsync(GoogleSearchVideoSearchInput input)
        {
            var _videoSearchChannelApi = new GoogleApi.GoogleSearch.VideoSearch.ChannelsApi();

            await CheckAuthorizationAsync(GoogleApiModulePermissions.Search.Video.Channels);

            var request = ObjectMapper.Map<GoogleSearchVideoSearchInput, ChannelSearchRequest>(input);
            request.Key = Options.APIKey;

            var response = await _videoSearchChannelApi.QueryAsync(request, GetCancellationToken());

            CheckResponse(response);

            return response;
        }

        public async Task<PlaylistSearchResponse> VideoPlaylistSearchAsync(GoogleSearchVideoPlaylistSearchInput input)
        {
            var _videoSearchPlaylistsApi = new GoogleApi.GoogleSearch.VideoSearch.PlaylistsApi();

            await CheckAuthorizationAsync(GoogleApiModulePermissions.Search.Video.Playlists);

            var request = ObjectMapper.Map<GoogleSearchVideoPlaylistSearchInput, PlaylistSearchRequest>(input);
            request.Key = Options.APIKey;

            var response = await _videoSearchPlaylistsApi.QueryAsync(request, GetCancellationToken());

            CheckResponse(response);

            return response;
        }

        public async Task<VideoSearchResponse> VideoSearchAsync(GoogleSearchVideoSearchInput input)
        {
            var _videoSearchVideosApi = new GoogleApi.GoogleSearch.VideoSearch.VideosApi();

            await CheckAuthorizationAsync(GoogleApiModulePermissions.Search.Video.Videos);

            var request = ObjectMapper.Map<GoogleSearchVideoSearchInput, VideoSearchRequest>(input);
            request.Key = Options.APIKey;

            var response = await _videoSearchVideosApi.QueryAsync(request, GetCancellationToken());

            CheckResponse(response);

            return response;
        }

        public async Task<BaseSearchResponse> WebSearchAsync(GoogleSearchWebSearchInput input)
        {
            var _webSearchApi = new GoogleApi.GoogleSearch.WebSearchApi();

            if (Options.SearchEngineId == null)
            {
                throw new UserFriendlyException(Localizer["Error:MissingSearchEngineId"]);
            }

            await CheckAuthorizationAsync(GoogleApiModulePermissions.Search.Web);

            var request = ObjectMapper.Map<GoogleSearchWebSearchInput, WebSearchRequest>(input);
            request.Key = Options.APIKey;
            request.SearchEngineId = Options.SearchEngineId;

            var response = await _webSearchApi.QueryAsync(request, GetCancellationToken());

            CheckResponse(response);

            return response;
        }
    }
}
