using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Byteology.GoogleApiModule.Options;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Common;
using Microsoft.Extensions.Options;
using Shouldly;
using Xunit;

namespace Byteology.GoogleApiModule.Apis.Maps
{
    public class GoogleMapsAppService_Tests : GoogleApiModuleApplicationTestBase
    {
        private readonly IGoogleMapsAppService googleMapsAppService;
        private readonly IOptions<GoogleApiModuleOptions> options;
        
        

        public GoogleMapsAppService_Tests()
        {
            options = GetRequiredService <IOptions<GoogleApiModuleOptions>>();
            googleMapsAppService = GetRequiredService<IGoogleMapsAppService>();
        }

        [Fact]
        public async Task Should_Get_Directions()
        {
            //Act
            var result = await googleMapsAppService.DirectionsAsync(new Inputs.GoogleMapsDirectionsInput
            {
                Origin = new LocationEx(Coordinates[TestLocation.GrandCanyon]),
                Destination = new LocationEx(Coordinates[TestLocation.MallOfAmerica]),
                TravelMode = GoogleApi.Entities.Maps.Common.Enums.TravelMode.Driving
            });

            //Assert
            result.Status.ShouldBe(GoogleApi.Entities.Common.Enums.Status.Ok);
            result.Routes.Count().ShouldBeGreaterThan(0);
            result.WayPoints.Count().ShouldBeGreaterThan(0);
            result.ErrorMessage.ShouldBeNull();
        }

        [Fact]
        public async Task Should_Get_Distance()
        {
            //Define
            List<LocationEx> origins = new();
            List<LocationEx> destinations = new ();

            origins.Add(new LocationEx(Coordinates[TestLocation.EmpireStateBuilding]));
            origins.Add(new LocationEx(Coordinates[TestLocation.WhiteHouse]));

            destinations.Add(new LocationEx(Coordinates[TestLocation.MountRushmore]));
            destinations.Add(new LocationEx(Coordinates[TestLocation.MallOfAmerica]));

            //Act
            var results = await googleMapsAppService.DistanceAsync(new Inputs.GoogleMapsDistanceInput
            {
                Origins = origins,
                Destinations = destinations
            });

            //Assert
            results.Status.ShouldBe(GoogleApi.Entities.Common.Enums.Status.Ok);
            results.DestinationAddresses.Count().ShouldBe(2);
            results.OriginAddresses.Count().ShouldBe(2);
        }

        [Fact]
        public async Task Should_Get_Elevation()
        {
            //Define
            var locations = new List<Coordinate>();
            locations.Add(Coordinates[TestLocation.MountRushmore]);
            locations.Add(Coordinates[TestLocation.GrandCanyon]);

            //Act
            var results = await googleMapsAppService.ElevationAsync(new Inputs.GoogleMapsElevationInput
            {
                Locations = locations
            });

            //Assert
            results.Status.ShouldBe(GoogleApi.Entities.Common.Enums.Status.Ok);
            results.Results.Count().ShouldBe(2);
        }

        [Fact]
        public async Task Should_Geocode_Address()
        {
            //Act
            var result = await googleMapsAppService.GeocodeAddressAsync(new Inputs.GoogleMapsGeocodeAddressInput
            {
                Address = WhiteHouseAddressString
            });

            //Assert
            result.Status.ShouldBe(GoogleApi.Entities.Common.Enums.Status.Ok);
            result.Results.Count().ShouldBe(1);
            result.Results.First().ShouldNotBeNull();
            result.Results.First().PlaceId.ShouldBe(WhiteHousePlaceId);

        }

        [Fact]
        public async Task Should_Geocode_Location()
        {
            //Act
            var result = await googleMapsAppService.GeocodeLocationAsync(new Inputs.GoogleMapsGeocodeLocationInput
            {
                Location = Coordinates[TestLocation.WhiteHouse]
            });

            //Assert
            result.Status.ShouldBe(GoogleApi.Entities.Common.Enums.Status.Ok);
            result.Results.Count().ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task Should_Geocode_Place()
        {
            //Act
            var result = await googleMapsAppService.GeocodePlaceAsync(new Inputs.GoogleMapsGeocodePlaceInput
            {
                PlaceId = WhiteHousePlaceId
            });

            //Assert
            result.Status.ShouldBe(GoogleApi.Entities.Common.Enums.Status.Ok);
            result.Results.Count().ShouldBe(1);
        }

        [Fact]
        public async Task Should_Get_PlusCode()
        {
            //there is an issue with this test when you have your API key restricted to specific IPs. I am getting responses that that the request is coming from 
            //a google IP address, so need to dive deeper into the base API and update the test or AppService to address that before I can uncomment
            /*
            //Define
            var location = new GoogleApi.Entities.Maps.Geocoding.PlusCode.Request.Location(WhiteHouseAddress);

            //Act
            var result = await googleMapsAppService.GeocodePlusCodeAsync(new Inputs.GoogleMapsGeocodePlusCodeInput
            {
                Address = location,
                
            });

            //Assert
            result.Status.ShouldBe(GoogleApi.Entities.Common.Enums.Status.Ok);
            result.PlusCode.GlobalCode.ShouldBe(WhiteHouseGlobalPlusCode);
            result.PlusCode.LocalCode.ShouldBe(WhiteHouseLocalPlusCode);*/
        }

        [Fact]
        public async Task Should_Do_Geolocation()
        {
            //Act
            var result = await googleMapsAppService.GeolocationAsync(new Inputs.GoogleMapsGeolocationInput
            {
                ConsiderIp = true
            });

            //Assert
            result.Status.ShouldBe(GoogleApi.Entities.Common.Enums.Status.Ok);
        }

        [Fact]
        public async Task Should_Get_Nearest_Roads()
        {
            //Define
            var empireState = Coordinates[TestLocation.EmpireStateBuilding];
            var grandCanyon = Coordinates[TestLocation.GrandCanyon];
            var points = new List<GoogleApi.Entities.Maps.Roads.Common.Coordinate>();
            points.Add(new GoogleApi.Entities.Maps.Roads.Common.Coordinate(empireState.Latitude, empireState.Longitude));
            points.Add(new GoogleApi.Entities.Maps.Roads.Common.Coordinate(grandCanyon.Latitude, grandCanyon.Longitude));

            //Act
            var results = await googleMapsAppService.NearestRoadsAsync(new Inputs.GoogleMapsNearestRoadsInput
            {
                Points = points
            });

            //Assert
            results.Status.ShouldBe(GoogleApi.Entities.Common.Enums.Status.Ok);
            results.SnappedPoints.Count().ShouldBeGreaterThanOrEqualTo(2);
        }

        [Fact]
        public async Task Should_Get_Snapped_Roads()
        {
            //Define
            //using points available in the google api documentation: 60.170880,24.942795|60.170879,24.942796|60.170877,24.942796
            var points = new List<GoogleApi.Entities.Maps.Roads.Common.Coordinate>();
            points.Add(new GoogleApi.Entities.Maps.Roads.Common.Coordinate(60.170880, 24.942795));
            points.Add(new GoogleApi.Entities.Maps.Roads.Common.Coordinate(60.170879, 24.942796));
            points.Add(new GoogleApi.Entities.Maps.Roads.Common.Coordinate(60.170877, 24.942796));

            //Act
            var results = await googleMapsAppService.SnapToRoadsAsync(new Inputs.GoogleMapsSnapToRoadsInput
            {
                Path = points,
                Interpolate = true
            });

            //Assert
            results.Status.ShouldBe(GoogleApi.Entities.Common.Enums.Status.Ok);
            results.SnappedPoints.Count().ShouldBeGreaterThanOrEqualTo(3);
        }

        [Fact]
        public async Task Should_Get_Speed_Limits()
        {
            if(options.Value.IncludePremiumEndpoints)
            {
                //Define
                //using points available in the google api documentation: 60.170880,24.942795|60.170879,24.942796|60.170877,24.942796
                var points = new List<GoogleApi.Entities.Maps.Roads.Common.Coordinate>();
                points.Add(new GoogleApi.Entities.Maps.Roads.Common.Coordinate(60.170880, 24.942795));
                points.Add(new GoogleApi.Entities.Maps.Roads.Common.Coordinate(60.170879, 24.942796));
                points.Add(new GoogleApi.Entities.Maps.Roads.Common.Coordinate(60.170877, 24.942796));

                //Act
                var results = await googleMapsAppService.SpeedLimitsAsync(new Inputs.GoogleMapsRoadsSpeedLimitInput
                {
                    Path = points
                });

                //Assert
                results.Status.ShouldBe(GoogleApi.Entities.Common.Enums.Status.Ok);
                results.SpeedLimits.Count().ShouldBeGreaterThanOrEqualTo(3);
            }            
        }

        [Fact]
        public async Task Should_Get_Static_Map()
        {
            //Act
            var result = await googleMapsAppService.StaticMapsAsync(new Inputs.GoogleMapsStaticMapsInput
            {
                Center = new Location(WhiteHouseAddress),
                ZoomLevel = 16
            });

            //Assert
            result.Status.ShouldBe(GoogleApi.Entities.Common.Enums.Status.Ok);
            result.ErrorMessage.ShouldBeNull();
            result.Stream.ShouldNotBeNull();
            result.Buffer.ShouldNotBeNull();
        }

        [Fact]
        public async Task Should_Get_Street_View()
        {
            //Act
            var result = await googleMapsAppService.StreetViewAsync(new Inputs.GoogleMapsStreetViewInput
            {
                Location = new Location(WhiteHouseAddress),
                Size = new MapSize(800,600)
            });

            //Assert
            result.Status.ShouldBe(GoogleApi.Entities.Common.Enums.Status.Ok);
            result.ErrorMessage.ShouldBeNull();
            result.Stream.ShouldNotBeNull();
            result.Buffer.ShouldNotBeNull();
        }

        [Fact]
        public async Task Should_Get_TimeZone()
        {
            //Define
            var grandCanyon = Coordinates[TestLocation.GrandCanyon];

            //Act
            var result = await googleMapsAppService.TimeZoneAsync(new Inputs.GoogleMapsTimeZoneInput
            {
                Location = new Coordinate(grandCanyon.Latitude, grandCanyon.Longitude),
                TimeStamp = DateTime.UtcNow
            });

            //Assert
            result.Status.ShouldBe(GoogleApi.Entities.Common.Enums.Status.Ok);
            result.ErrorMessage.ShouldBeNull();
            result.TimeZoneId.ShouldBe("America/Phoenix");

        }
    }

    
}
