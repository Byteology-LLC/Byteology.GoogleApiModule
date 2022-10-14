using GoogleApi.Entities.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using GoogleApi.Entities.Places.Details.Request.Enums;
using JetBrains.Annotations;

namespace Byteology.GoogleApiModule.Apis.Places.Inputs
{
    public class GooglePlacesDetailsInput
    {
        /// <summary>
        /// A textual identifier that uniquely identifies a place, returned from a Place Search.
        /// </summary>
        [NotNull]
        public string PlaceId { get; set; }

        /// <summary>
        /// The region code, specified as a ccTLD ("top-level domain") two-character value.
        /// Most ccTLD codes are identical to ISO 3166-1 codes, with some notable exceptions.
        /// For example, the United Kingdom's ccTLD is "uk" (.co.uk) while its ISO 3166-1 code is "gb"
        /// (technically for the entity of "The United Kingdom of Great Britain and Northern Ireland").
        /// </summary>
        [CanBeNull]
        public string Region { get; set; } = null;

        /// <summary>
        /// Language (optional) — The language code, indicating in which language the results should be returned, if possible.
        /// See the list of supported languages and their codes: https://developers.google.com/maps/faq#languagesupport
        /// Note that we often update supported languages so this list may not be exhaustive.
        /// </summary>
        [CanBeNull]
        public Language Language { get; set; } = Language.English;

        /// <summary>
        /// Fields (optional).
        /// Defaults to 'Basic'.
        /// One or more fields, specifying the types of place data to return, separated by a comma.
        /// Fields correspond to Place Details results, and are divided into three billing categories: Basic, Contact, and Atmosphere.
        /// Basic fields are billed at base rate, and incur no additional charges.Contact and Atmosphere fields are billed at a higher rate.
        /// See the pricing sheet for more information. Attributions (html_attributions) are always returned with every call, regardless of whether it has been requested.
        /// </summary>
        [CanBeNull]
        public FieldTypes Fields { get; set; } = FieldTypes.Basic;

    }
}
