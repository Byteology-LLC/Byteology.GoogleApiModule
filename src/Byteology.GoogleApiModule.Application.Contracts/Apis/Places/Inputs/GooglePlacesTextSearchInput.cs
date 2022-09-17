using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Common.Enums;
using GoogleApi.Entities.Places.Search.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Byteology.GoogleApiModule.Apis.Places.Inputs
{
    public class GooglePlacesTextSearchInput
    {
        //
        // Summary:
        //     Query — The text string on which to search, for example: "restaurant". The Google
        //     Places service will return candidate matches based on this string and order the
        //     results based on their perceived relevance.
        public virtual string Query { get; set; }

        //
        // Summary:
        //     The region code, specified as a ccTLD ("top-level domain") two-character value.
        //     Most ccTLD codes are identical to ISO 3166-1 codes, with some notable exceptions.
        //     For example, the United Kingdom's ccTLD is "uk" (.co.uk) while its ISO 3166-1
        //     code is "gb" (technically for the entity of "The United Kingdom of Great Britain
        //     and Northern Ireland").
        public virtual string Region { get; set; }

        //
        // Summary:
        //     opennow (optional). Returns only those places that are open for business at the
        //     time the query is sent. Places that do not specify opening hours in the Google
        //     Places database will not be returned if you include this parameter in your query.
        public virtual bool OpenNow { get; set; }

        //
        // Summary:
        //     (optional) The language in which to return results. See the supported list of
        //     domain languages. Note that we often update supported languages so this list
        //     may not be exhaustive. If language is not supplied, the Place service will attempt
        //     to use the native language of the domain from which the request is sent.
        public virtual Language Language { get; set; } = Language.English;


        //
        // Summary:
        //     Minprice (optional). Restricts results to only those places within the specified
        //     range. Valid values range between 0 (most affordable) to 4 (most expensive),
        //     inclusive. The exact amount indicated by a specific value will vary from region
        //     to region.
        public virtual PriceLevel? Minprice { get; set; }

        //
        // Summary:
        //     Maxprice (optional). Restricts results to only those places within the specified
        //     range. Valid values range between 0 (most affordable) to 4 (most expensive),
        //     inclusive. The exact amount indicated by a specific value will vary from region
        //     to region.
        public virtual PriceLevel? Maxprice { get; set; }

        //
        // Summary:
        //     Type (optional). Restricts the results to places matching the specified type.
        //     Only one type may be specified (if more than one type is provided, all types
        //     following the first entry are ignored).
        public virtual SearchPlaceType? Type { get; set; }

        //
        // Summary:
        //     Location (optional). The latitude/longitude around which to retrieve place information.
        //     If you specify a location parameter, you must also specify a radius parameter.
        public virtual Coordinate Location { get; set; }

        //
        // Summary:
        //     Radius (Radius). Defines the distance (in meters) within which to bias place
        //     results. The maximum allowed radius is 50 000 meters. Results inside of this
        //     region will be ranked higher than results outside of the search circle; however,
        //     prominent results from outside of the search radius may be included
        public virtual double? Radius { get; set; }

        //
        // Summary:
        //     pagetoken — Returns the next 20 results from a previously run search. Setting
        //     a pagetoken parameter will execute a search with the same parameters used previously
        //     — all parameters other than pagetoken will be ignored.
        public virtual string PageToken { get; set; }
    }
}
