using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Microsoft.Extensions.Options;
using Volo.Abp;
using Byteology.GoogleApiModule.Options;

namespace Byteology.GoogleApiModule.Apis.Search
{
    public class GoogleSearchAppService_Tests : GoogleApiModuleApplicationTestBase
    {
        private readonly IGoogleSearchAppService googleSearchAppService;
        private readonly IOptions<GoogleApiModuleOptions> options;

        public GoogleSearchAppService_Tests()
        {
            this.options = GetRequiredService<IOptions<GoogleApiModuleOptions>>();
            this.googleSearchAppService = GetRequiredService<IGoogleSearchAppService>();
        }

        [Fact]
        public async Task Should_Create_Exception()
        {
            //Act
            var oldId = options.Value.SearchEngineId;
            options.Value.SearchEngineId = null;

            var exception = await Assert.ThrowsAsync<UserFriendlyException>(async () =>
            {
                await googleSearchAppService.WebSearchAsync(
                    new Inputs.GoogleSearchWebSearchInput
                    {
                        Query = "Kittens"
                    }
                );
            });
            
            options.Value.SearchEngineId = oldId;
            exception.Message.ShouldContain("A custom search engine id is required");
        }


        [Fact]
        public async Task Search_For_Images()
        {
            //Act
            var results = await googleSearchAppService.ImageSearchAsync(new Inputs.GoogleSearchImageSearchInput
            {
                Query = "Nerd Stuff",
                ImageOptions = new GoogleApi.Entities.Search.Common.SearchImageOptions
                {
                    ImageType = GoogleApi.Entities.Search.Common.Enums.ImageType.Photo,
                    ImageSize = GoogleApi.Entities.Search.Common.Enums.ImageSize.Medium
                }
            });

            //Assert
            results.Status.ShouldBe(GoogleApi.Entities.Common.Enums.Status.Ok);
            results.ErrorMessage.ShouldBeNull();
            results.Items.Count().ShouldBeGreaterThan(1);
            results.Items.Where(w => !w.MimeType.Contains("image")).ToList().Count().ShouldBe(0);
        }

        [Fact]
        public async Task Search_Video_Channels()
        {
            //Act
            var results = await googleSearchAppService.VideoChannelSearchAsync(new Inputs.GoogleSearchVideoSearchInput
            {
                Query = "Rick and Morty",
                ChannelType = GoogleApi.Entities.Search.Video.Common.Enums.ChannelType.Any,
                Options = new GoogleApi.Entities.Search.Video.Videos.Request.VideoOptions
                {
                    VideoLicense = GoogleApi.Entities.Search.Video.Videos.Request.Enums.VideoLicenseType.CreativeCommon
                }
            });

            //Assert
            results.Status.ShouldBe(GoogleApi.Entities.Common.Enums.Status.Ok);
            results.ErrorMessage.ShouldBeNull();
            results.Items.Count().ShouldBeGreaterThan(1);
            results.Items.Where(w => w.Snippet.Title.Contains("Rick")).ToList().Count().ShouldBeGreaterThanOrEqualTo(1);
            results.Items.Where(w => w.Snippet.Title.Contains("Morty")).ToList().Count().ShouldBeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public async Task Search_Video_Playlists()
        {
            //Act
            var results = await googleSearchAppService.VideoPlaylistSearchAsync(new Inputs.GoogleSearchVideoPlaylistSearchInput
            {
                Query = "Neebs Gaming",
                PrettyPrint = false
            });

            //Assert
            results.Status.ShouldBe(GoogleApi.Entities.Common.Enums.Status.Ok);
            results.ErrorMessage.ShouldBeNull();
            results.Items.Count().ShouldBeGreaterThan(1);
            results.Items.Where(w => w.Snippet.Title.Contains("Neebs")).ToList().Count().ShouldBeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public async Task Search_Videos()
        {
            //Act
            var results = await googleSearchAppService.VideoSearchAsync(new Inputs.GoogleSearchVideoSearchInput
            {
                Query = "GTA",
                ChannelId = "UCiufyZv8iRPTafTw0D4CvnQ"
            });

            //Assert
            results.Status.ShouldBe(GoogleApi.Entities.Common.Enums.Status.Ok);
            results.ErrorMessage.ShouldBeNull();
            results.Items.Count().ShouldBeGreaterThan(1);
            var titles = results.Items.Select(w => w.Snippet.ChannelTitle).Distinct().ToList();
            titles.Count().ShouldBe(1); //should all be the same channel title since we limited it to a single channelId in the search
        }

        [Fact]
        public async Task Search_The_Web()
        {
            //Act
            var results = await googleSearchAppService.WebSearchAsync(new Inputs.GoogleSearchWebSearchInput
            {
                Query = "Byteology",
                Options = new GoogleApi.Entities.Search.Common.SearchOptions
                {
                    DateRestrict = new GoogleApi.Entities.Search.Common.DateRestrict
                    {
                        Type = GoogleApi.Entities.Search.Common.Enums.DateRestrictType.Years,
                        Number = 1
                    }
                }
            });

            //Assert
            results.Status.ShouldBe(GoogleApi.Entities.Common.Enums.Status.Ok);
            results.ErrorMessage.ShouldBeNull();
            results.Items.Count().ShouldBeGreaterThan(1);
        }
    }
}
