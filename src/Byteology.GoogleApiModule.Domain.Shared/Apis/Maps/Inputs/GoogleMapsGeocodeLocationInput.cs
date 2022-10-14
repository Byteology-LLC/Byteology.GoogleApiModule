using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Geocoding.Common.Enums;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Byteology.GoogleApiModule.Apis.Maps.Inputs
{
    public class GoogleMapsGeocodeLocationInput : GoogleMapsGeocodeBaseInput
    {
        /// <summary>
        /// Latlng (required).
        /// The textual latitude/longitude value for which you wish to obtain the closest, human-readable address.
        /// If you pass a latlng, the geocoder performs what is known as a reverse geocode.
        /// </summary>
        [NotNull]
        public Coordinate Location { get; set; }

        /// <summary>
        /// result_type — A filter of one or more address types, separated by a pipe (|).
        /// If the parameter contains multiple address types, the API returns all addresses that match any of the types.
        /// A note about processing: The result_type parameter does not restrict the search to the specified address type(s).
        /// Rather, the result_type acts as a post-search filter: the API fetches all results for the specified latlng,
        /// then discards those results that do not match the specified address type(s).
        /// Note: This parameter is available only for requests that include an API key or a client ID.
        /// </summary>
        [CanBeNull]
        public IEnumerable<PlaceLocationType> ResultTypes { get; set; } = default;

        /// <summary>
        /// location_type — A filter of one or more location types, separated by a pipe (|).
        /// If the parameter contains multiple location types, the API returns all addresses that match any of the types.
        /// A note about processing: The location_type parameter does not restrict the search to the specified location type(s).
        /// Rather, the location_type acts as a post-search filter: the API fetches all results for the specified latlng,
        /// then discards those results that do not match the specified location type(s).
        /// Note: This parameter is available only for requests that include an API key or a client ID.
        /// </summary>
        [CanBeNull]
        public IEnumerable<GeometryLocationType> LocationTypes { get; set; } = default;

        /// <summary>
        /// language (optional) — The language in which to return results.
        /// See the supported list of domain languages. Note that we often update supported languages so this list may not be exhaustive.
        /// If language is not supplied, the geocoder will attempt to use the native language of the domain from which the request is sent wherever possible.
        /// </summary>
        [CanBeNull]
        public Language Language { get; set; } = Language.English;
    }
}
