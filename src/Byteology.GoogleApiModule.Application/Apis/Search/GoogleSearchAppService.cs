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
        private readonly GoogleSearchManager Manager;
        public GoogleSearchAppService(IOptions<GoogleApiModuleOptions> options, IStringLocalizer<GoogleApiModuleResource> localizer, 
            IServiceProvider serviceProvider, GoogleSearchManager manager) : base(options, localizer, serviceProvider, EndPointType.Search)
        {
            Manager = manager;
        }

        public async Task<BaseSearchResponse> ImageSearchAsync(GoogleSearchImageSearchInput input)
        {
            if (Options.SearchEngineId == null)
            {
                throw new UserFriendlyException(Localizer["Error:MissingSearchEngineId"]);
            }


            await CheckAuthorizationAsync(GoogleApiModulePermissions.Search.Image);

            return await Manager.ImageSearchAsync(input);
        }

        public async Task<ChannelSearchResponse> VideoChannelSearchAsync(GoogleSearchVideoSearchInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Search.Video.Channels);

            return await Manager.VideoChannelSearchAsync(input);
        }

        public async Task<PlaylistSearchResponse> VideoPlaylistSearchAsync(GoogleSearchVideoPlaylistSearchInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Search.Video.Playlists);

            return await Manager.VideoPlaylistSearchAsync(input);
        }

        public async Task<VideoSearchResponse> VideoSearchAsync(GoogleSearchVideoSearchInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Search.Video.Videos);

            return await Manager.VideoSearchAsync(input);
        }

        public async Task<BaseSearchResponse> WebSearchAsync(GoogleSearchWebSearchInput input)
        {
            if (Options.SearchEngineId == null)
            {
                throw new UserFriendlyException(Localizer["Error:MissingSearchEngineId"]);
            }

            await CheckAuthorizationAsync(GoogleApiModulePermissions.Search.Web);

            return await Manager.WebSearchAsync(input);
        }
    }
}
