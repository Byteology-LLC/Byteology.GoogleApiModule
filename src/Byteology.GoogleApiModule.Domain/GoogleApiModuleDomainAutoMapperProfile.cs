using AutoMapper;
using Byteology.GoogleApiModule.Apis.Maps.Inputs;
using Byteology.GoogleApiModule.Apis.Places.Inputs;
using Byteology.GoogleApiModule.Apis.Search.Inputs;
using Byteology.GoogleApiModule.Apis.Translate.Inputs;
using Byteology.GoogleApiModule.Extensions;
using GoogleApi.Entities.Maps.Directions.Request;
using GoogleApi.Entities.Maps.DistanceMatrix.Request;
using GoogleApi.Entities.Maps.Elevation.Request;
using GoogleApi.Entities.Maps.Geocoding.Address.Request;
using GoogleApi.Entities.Maps.Geocoding.Location.Request;
using GoogleApi.Entities.Maps.Geocoding.Place.Request;
using GoogleApi.Entities.Maps.Geocoding.PlusCode.Request;
using GoogleApi.Entities.Maps.Geolocation.Request;
using GoogleApi.Entities.Maps.Roads.NearestRoads.Request;
using GoogleApi.Entities.Maps.Roads.SnapToRoads.Request;
using GoogleApi.Entities.Maps.Roads.SpeedLimits.Request;
using GoogleApi.Entities.Maps.StaticMaps.Request;
using GoogleApi.Entities.Maps.StreetView.Request;
using GoogleApi.Entities.Maps.TimeZone.Request;
using GoogleApi.Entities.Places.AutoComplete.Request;
using GoogleApi.Entities.Places.Details.Request;
using GoogleApi.Entities.Places.Photos.Request;
using GoogleApi.Entities.Places.QueryAutoComplete.Request;
using GoogleApi.Entities.Places.Search.Find.Request;
using GoogleApi.Entities.Places.Search.NearBy.Request;
using GoogleApi.Entities.Places.Search.Text.Request;
using GoogleApi.Entities.Search.Image.Request;
using GoogleApi.Entities.Search.Video.Channels.Request;
using GoogleApi.Entities.Search.Video.Playlists.Request;
using GoogleApi.Entities.Search.Video.Videos.Request;
using GoogleApi.Entities.Search.Web.Request;
using GoogleApi.Entities.Translate.Detect.Request;
using GoogleApi.Entities.Translate.Languages.Request;
using GoogleApi.Entities.Translate.Translate.Request;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.AutoMapper;

namespace Byteology.GoogleApiModule
{


    public class GoogleApiModuleDomainAutoMapperProfile : Profile
    {
        public GoogleApiModuleDomainAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            //Google Maps
            CreateMap<GoogleMapsDirectionsInput, DirectionsRequest>().IgnoreOptionedValues();
            CreateMap<GoogleMapsDistanceInput, DistanceMatrixRequest>().IgnoreOptionedValues();
            CreateMap<GoogleMapsElevationInput, ElevationRequest>().IgnoreOptionedValues();
            CreateMap<GoogleMapsGeocodeAddressInput, AddressGeocodeRequest>().IgnoreOptionedValues();
            CreateMap<GoogleMapsGeocodeLocationInput, LocationGeocodeRequest>().IgnoreOptionedValues();
            CreateMap<GoogleMapsGeocodePlaceInput, PlaceGeocodeRequest>().IgnoreOptionedValues();
            CreateMap<GoogleMapsGeocodePlusCodeInput, PlusCodeGeocodeRequest>().IgnoreOptionedValues();
            CreateMap<GoogleMapsGeolocationInput, GeolocationRequest>().IgnoreOptionedValues();
            CreateMap<GoogleMapsNearestRoadsInput, NearestRoadsRequest>().IgnoreOptionedValues();
            CreateMap<GoogleMapsRoadsSpeedLimitInput, SpeedLimitsRequest>().IgnoreOptionedValues();
            CreateMap<GoogleMapsSnapToRoadsInput, SnapToRoadsRequest>().IgnoreOptionedValues();
            CreateMap<GoogleMapsStaticMapsInput, StaticMapsRequest>().IgnoreOptionedValues();
            CreateMap<GoogleMapsStreetViewInput, StreetViewRequest>().IgnoreOptionedValues();
            CreateMap<GoogleMapsTimeZoneInput, TimeZoneRequest>().IgnoreOptionedValues();

            //Google Places
            CreateMap<GooglePlacesAutoCompleteInput, PlacesAutoCompleteRequest>().IgnoreOptionedValues().Ignore(x => x.SessionToken);
            CreateMap<GooglePlacesDetailsInput, PlacesDetailsRequest>().IgnoreOptionedValues().Ignore(x => x.SessionToken);
            CreateMap<GooglePlacesFindInput, PlacesFindSearchRequest>().IgnoreOptionedValues();
            CreateMap<GooglePlacesFindNearbyInput, PlacesNearBySearchRequest>().IgnoreOptionedValues();
            CreateMap<GooglePlacesPhotosInput, PlacesPhotosRequest>().IgnoreOptionedValues();
            CreateMap<GooglePlacesTextSearchInput, PlacesTextSearchRequest>().IgnoreOptionedValues();
            CreateMap<GooglePlacesQueryAutoCompleteInput, PlacesQueryAutoCompleteRequest>().IgnoreOptionedValues();

            //Google Search
            CreateMap<GoogleSearchWebSearchInput, WebSearchRequest>().IgnoreOptionedValues().Ignore(x => x.SearchEngineId);
            CreateMap<GoogleSearchImageSearchInput, ImageSearchRequest>().IgnoreOptionedValues().Ignore(x => x.SearchEngineId);
            CreateMap<GoogleSearchVideoSearchInput, VideoSearchRequest>().IgnoreOptionedValues();
            CreateMap<GoogleSearchVideoPlaylistSearchInput, PlaylistSearchRequest>().IgnoreOptionedValues();
            CreateMap<GoogleSearchVideoSearchInput, ChannelSearchRequest>().IgnoreOptionedValues();

            //Google Translate
            CreateMap<GoogleTranslateDetectInput, DetectRequest>().IgnoreOptionedValues();
            CreateMap<GoogleTranslateLanguagesInput, LanguagesRequest>().IgnoreOptionedValues();
            CreateMap<GoogleTranslateInput, TranslateRequest>().IgnoreOptionedValues();
        }
    }
}
