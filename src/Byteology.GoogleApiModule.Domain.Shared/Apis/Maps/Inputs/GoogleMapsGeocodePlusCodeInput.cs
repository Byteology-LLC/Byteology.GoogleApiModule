using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Geocoding.PlusCode.Request;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Byteology.GoogleApiModule.Apis.Maps.Inputs
{
    public class GoogleMapsGeocodePlusCodeInput: GoogleMapsGeocodeBaseInput
    {
        /// <summary>
        /// The Address.
        /// The address to encode. This can be any of the following (if the ekey parameter is also provided):
        /// - A latitude/longitude
        /// - A street address
        /// - A global code
        /// - A local code and locality
        /// </summary>
        [NotNull]
        public Location Address { get; set; }

        /// <summary>
        /// language (optional) — The language in which to return results.
        /// See the supported list of domain languages. Note that we often update supported languages so this list may not be exhaustive.
        /// If language is not supplied, the geocoder will attempt to use the native language of the domain from which the request is sent wherever possible.
        /// </summary>
        [CanBeNull]
        public Language Language { get; set; } = Language.English;

        /// <summary>
        /// Email.
        /// Provide an email address that can be used to contact you.
        /// </summary>
        [CanBeNull]
        public string Email { get; set; }

        /// <summary>
        /// Use Encrypted Key.
        /// The request will send the 'ekey' parameter instead of 'key'.
        /// See https://github.com/google/open-location-code/wiki/Plus-codes-API#securing-your-api-key
        /// </summary>
        [CanBeNull]
        public bool UseEncryptedKey { get; set; } = false;

    }
}
