using GoogleApi.Entities.Common.Enums;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Byteology.GoogleApiModule.Apis.Maps.Inputs
{
    public class GoogleMapsGeocodeAddressInput : GoogleMapsGeocodeBaseInput
    {
        /// <summary>
        /// Address (required).
        /// The street address or plus code that you want to geocode.
        /// Specify addresses in accordance with the format used by the national postal service of the country concerned.
        /// Additional address elements such as business names and unit, suite or floor numbers should be avoided
        /// </summary>
        [NotNull]
        public string Address { get; set; }

        /// <summary>
        /// language (optional) — The language in which to return results.
        /// See the supported list of domain languages. Note that we often update supported languages so this list may not be exhaustive.
        /// If language is not supplied, the geocoder will attempt to use the native language of the domain from which the request is sent wherever possible.
        /// </summary>
        [CanBeNull]
        public Language Language { get; set; } = Language.English;
    }
}
