using Byteology.GoogleApiModule.Apis.Search.Inputs;
using Byteology.GoogleApiModule.Enums;
using Byteology.GoogleApiModule.Localization;
using Byteology.GoogleApiModule.Options;
using Byteology.GoogleApiModule.Settings;
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
using Volo.Abp.ObjectMapping;
using Volo.Abp.Users;

namespace Byteology.GoogleApiModule.Apis.Search
{
    public class GoogleSearchManager: ApiManagerBase
    {
        public GoogleSearchManager(IOptions<GoogleApiModuleOptions> options, IStringLocalizer<GoogleApiModuleResource> localizer, 
            IServiceProvider serviceProvider, ICurrentUser currentUser, IObjectMapper objectMapper, GoogleApiModuleSettingsManager settingsManager) 
            : base(localizer, serviceProvider, currentUser, objectMapper, settingsManager, EndPointType.Search)
        {

        }

        public async Task<BaseSearchResponse> ImageSearchAsync(GoogleSearchImageSearchInput input)
        {
            var _imageSearchApi = new GoogleApi.GoogleSearch.ImageSearchApi();
            if (Settings.SearchEngineId == null)
            {
                throw new UserFriendlyException(Localizer["Error:MissingSearchEngineId"]);
            }

            var request = ObjectMapper.Map<GoogleSearchImageSearchInput, ImageSearchRequest>(input);
            request.Key = Settings.ApiKey;
            request.SearchEngineId = Settings.SearchEngineId;

            var response = await _imageSearchApi.QueryAsync(request);

            CheckResponse(response);

            return response;
        }

        public async Task<ChannelSearchResponse> VideoChannelSearchAsync(GoogleSearchVideoSearchInput input)
        {
            var _videoSearchChannelApi = new GoogleApi.GoogleSearch.VideoSearch.ChannelsApi();


            var request = ObjectMapper.Map<GoogleSearchVideoSearchInput, ChannelSearchRequest>(input);
            request.Key = Settings.ApiKey;

            var response = await _videoSearchChannelApi.QueryAsync(request);

            CheckResponse(response);

            return response;
        }

        public async Task<PlaylistSearchResponse> VideoPlaylistSearchAsync(GoogleSearchVideoPlaylistSearchInput input)
        {
            var _videoSearchPlaylistsApi = new GoogleApi.GoogleSearch.VideoSearch.PlaylistsApi();


            var request = ObjectMapper.Map<GoogleSearchVideoPlaylistSearchInput, PlaylistSearchRequest>(input);
            request.Key = Settings.ApiKey;

            var response = await _videoSearchPlaylistsApi.QueryAsync(request);

            CheckResponse(response);

            return response;
        }

        public async Task<VideoSearchResponse> VideoSearchAsync(GoogleSearchVideoSearchInput input)
        {
            var _videoSearchVideosApi = new GoogleApi.GoogleSearch.VideoSearch.VideosApi();


            var request = ObjectMapper.Map<GoogleSearchVideoSearchInput, VideoSearchRequest>(input);
            request.Key = Settings.ApiKey;

            var response = await _videoSearchVideosApi.QueryAsync(request);

            CheckResponse(response);

            return response;
        }

        public async Task<BaseSearchResponse> WebSearchAsync(GoogleSearchWebSearchInput input)
        {
            var _webSearchApi = new GoogleApi.GoogleSearch.WebSearchApi();

            if (Settings.SearchEngineId == null)
            {
                throw new UserFriendlyException(Localizer["Error:MissingSearchEngineId"]);
            }


            var request = ObjectMapper.Map<GoogleSearchWebSearchInput, WebSearchRequest>(input);
            request.Key = Settings.ApiKey;
            request.SearchEngineId = Settings.SearchEngineId;

            var response = await _webSearchApi.QueryAsync(request);

            CheckResponse(response);

            return response;
        }
    }
}
