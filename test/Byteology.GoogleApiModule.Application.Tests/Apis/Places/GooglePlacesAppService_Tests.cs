using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Byteology.GoogleApiModule.Options;

namespace Byteology.GoogleApiModule.Apis.Places
{
    public class GooglePlacesAppService_Tests : GoogleApiModuleApplicationTestBase
    {
        private readonly IGooglePlacesAppService googlePlacesAppService;
        private readonly IOptions<GoogleApiModuleOptions> options;

        public GooglePlacesAppService_Tests()
        {
            this.options = GetRequiredService<IOptions<GoogleApiModuleOptions>>();
            this.googlePlacesAppService = GetRequiredService<IGooglePlacesAppService>();
        }

        

        [Fact]
        public async Task Should_Return_AutoComplete_Results()
        {
            //Define
            var whiteHouse = Coordinates[TestLocation.WhiteHouse];

            //Act
            var results = await googlePlacesAppService.AutoCompleteAsync(new Inputs.GooglePlacesAutoCompleteInput
            {
                Input = "1600 Penns",
                Origin = new GoogleApi.Entities.Common.Coordinate(whiteHouse.Latitude,whiteHouse.Longitude),
                Radius = 1000
            });

            //Assert
            results.Status.ShouldBe(GoogleApi.Entities.Common.Enums.Status.Ok);
            results.ErrorMessage.ShouldBeNull();
            results.Predictions.Count().ShouldBeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public async Task Should_Get_Details_Async()
        {
            //Act
            var result = await googlePlacesAppService.DetailsAsync(new Inputs.GooglePlacesDetailsInput
            {
                PlaceId = WhiteHousePlaceId
            });

            //Assert
            result.Status.ShouldBe(GoogleApi.Entities.Common.Enums.Status.Ok);
            result.ErrorMessage.ShouldBeNull();
            result.Result.Name.ShouldBe("The White House",StringCompareShould.IgnoreCase);
            result.Result.Photos.Count().ShouldBeGreaterThan(0);

        }

        [Fact]
        public async Task Should_Find_A_Place()
        {
            //Act
            var results = await googlePlacesAppService.FindAsync(new Inputs.GooglePlacesFindInput
            {
                Input = "The Statue of Liberty",
                Type = GoogleApi.Entities.Places.Search.Find.Request.Enums.InputType.TextQuery
            });

            //Assert
            results.Status.ShouldBe(GoogleApi.Entities.Common.Enums.Status.Ok);
            results.ErrorMessage.ShouldBeNull();
            results.Candidates.Count().ShouldBeGreaterThanOrEqualTo(1);
            results.Candidates.FirstOrDefault(f => f.PlaceId == "ChIJPTacEpBQwokRKwIlDXelxkA").ShouldNotBeNull();
        }

        [Fact]
        public async Task Should_Find_Places_Nearby()
        {
            //Define
            var empireState = Coordinates[TestLocation.EmpireStateBuilding];

            //Act
            var results = await googlePlacesAppService.FindNearbyAsync(new Inputs.GooglePlacesFindNearbyInput
            {
                Location = new GoogleApi.Entities.Common.Coordinate(empireState.Latitude, empireState.Longitude),
                Radius = 1000,
                Keyword = "Hilton"
            });

            //Assert
            results.Status.ShouldBe(GoogleApi.Entities.Common.Enums.Status.Ok);
            results.ErrorMessage.ShouldBeNull();
            results.Results.Count().ShouldBeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public async Task Should_Get_Photos()
        {
            //Act
            var whiteHouseDetails = await googlePlacesAppService.DetailsAsync(new Inputs.GooglePlacesDetailsInput
            {
                PlaceId = WhiteHousePlaceId
            });

            whiteHouseDetails.Result.Photos.ShouldNotBeEmpty();

            var photo = whiteHouseDetails.Result.Photos.First();

            var result = await googlePlacesAppService.PhotosAsync(new Inputs.GooglePlacesPhotosInput
            {
                PhotoReference = photo.PhotoReference
            });

            //Assert
            result.Status.ShouldBe(GoogleApi.Entities.Common.Enums.Status.Ok);
            result.ErrorMessage.ShouldBeNull();
            result.Status.ShouldBe(GoogleApi.Entities.Common.Enums.Status.Ok);
            result.Buffer.ShouldNotBeNull();
            result.Stream.ShouldNotBeNull();
        }

        [Fact]
        public async Task Should_Query_AutoComplete()
        {
            //Act
            var results = await googlePlacesAppService.QueryAutoCompleteAsync(new Inputs.GooglePlacesQueryAutoCompleteInput
            {
                Input = "The White H"
            });

            //Assert
            results.Status.ShouldBe(GoogleApi.Entities.Common.Enums.Status.Ok);
            results.ErrorMessage.ShouldBeNull();
            results.Predictions.Where(w => w.Description.Contains("The White House", StringComparison.InvariantCultureIgnoreCase)).ToList().Count().ShouldBeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public async Task Should_Search_By_Text()
        {
            //Act
            var results = await googlePlacesAppService.TextSearchAsync(new Inputs.GooglePlacesTextSearchInput
            {
                Query = "Casinos in Las Vegas"
            });

            //Assert
            results.Status.ShouldBe(GoogleApi.Entities.Common.Enums.Status.Ok);
            results.ErrorMessage.ShouldBeNull();
            results.Results.Count().ShouldBeGreaterThan(1);
            results.Results.Where(w => w.Name.Contains("Caesars Palace", StringComparison.InvariantCultureIgnoreCase)).ToList().ShouldNotBeEmpty();
        }
    }
}
