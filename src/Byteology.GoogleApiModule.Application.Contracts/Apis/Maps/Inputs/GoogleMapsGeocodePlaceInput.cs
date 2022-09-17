using GoogleApi.Entities.Common.Enums;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Byteology.GoogleApiModule.Apis.Maps.Inputs
{
    public class GoogleMapsGeocodePlaceInput: GoogleMapsGeocodeBaseInput
    {
        /// <summary>
        /// PlaceId (required).
        /// The place ID of the place for which you wish to obtain the human-readable address.
        /// The place ID is a unique identifier that can be used with other Google APIs. For example, you can use the placeID returned by the Google Maps Roads API
        /// to get the address for a snapped point. For more information about place IDs, see the place ID overview.
        /// The place ID may only be specified if the request includes an API key or a Google Maps APIs Premium Plan client ID.
        /// </summary>
        [NotNull]
        public string PlaceId { get; set; }

        /// <summary>
        /// language (optional) — The language in which to return results.
        /// See the supported list of domain languages. Note that we often update supported languages so this list may not be exhaustive.
        /// If language is not supplied, the geocoder will attempt to use the native language of the domain from which the request is sent wherever possible.
        /// </summary>
        [CanBeNull]
        public Language Language { get; set; } = Language.English;
    }
}
