using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Common.Enums;
using GoogleApi.Entities.Places.Search.Common.Enums;
using GoogleApi.Entities.Places.Search.NearBy.Request.Enums;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Byteology.GoogleApiModule.Apis.Places.Inputs
{
    public class GooglePlacesFindNearbyInput
    {
        // Summary:
        //     Location (optional). The latitude/longitude around which to retrieve place information.
        //     If you specify a location parameter, you must also specify a radius parameter.
        public Coordinate Location { get; set; }

        // Summary:
        //     name — One or more terms to be matched against the names of places, separated
        //     with a space character. Results will be restricted to those containing the passed
        //     name values. Note that a place may have additional names associated with it,
        //     beyond its listed name. The API will try to match the passed name value against
        //     all of these names. As a result, places may be returned in the results whose
        //     listed names do not match the search term, but whose associated names do.
        public string Name { get; set; }

        // Summary:
        //     keyword — A term to be matched against all content that Google has indexed for
        //     this place, including but not limited to name, type, and address, as well as
        //     customer reviews and other third-party content.
        public string Keyword { get; set; } = null;

        // Summary:
        //     (optional) The language in which to return results. See the supported list of
        //     domain languages. Note that we often update supported languages so this list
        //     may not be exhaustive. If language is not supplied, the Place service will attempt
        //     to use the native language of the domain from which the request is sent.
        public Language Language { get; set; } = Language.English;

        // Summary:
        //     Maxprice (optional). Restricts results to only those places within the specified
        //     range. Valid values range between 0 (most affordable) to 4 (most expensive),
        //     inclusive. The exact amount indicated by a specific value will vary from region
        //     to region.
        public PriceLevel? MaxPrice { get; set; } = null;

        // Summary:
        //     Minprice (optional). Restricts results to only those places within the specified
        //     range. Valid values range between 0 (most affordable) to 4 (most expensive),
        //     inclusive. The exact amount indicated by a specific value will vary from region
        //     to region.
        public PriceLevel? MinPrice { get; set; } = null;

        // Summary:
        //     opennow (optional). Returns only those places that are open for business at the
        //     time the query is sent. Places that do not specify opening hours in the Google
        //     Places database will not be returned if you include this parameter in your query.
        public bool OpenNow { get; set; } = false;

        // Summary:
        //     pagetoken — Returns the next 20 results from a previously run search. Setting
        //     a pagetoken parameter will execute a search with the same parameters used previously
        //     — all parameters other than pagetoken will be ignored.
        public string Pagetoken { get; set; } = null;

        // Summary:
        //     Radius (Radius). Defines the distance (in meters) within which to bias place
        //     results. The maximum allowed radius is 50 000 meters. Results inside of this
        //     region will be ranked higher than results outside of the search circle; however,
        //     prominent results from outside of the search radius may be included
        public double? Radius { get; set; } = null;

        // Summary:
        //     rankby — Specifies the order in which results are listed. Possible values are:
        //     - prominence (default). This option sorts results based on their importance.
        //     Ranking will favor prominent places within the specified area. - Prominence,
        //     can be affected by a place's ranking in Google's index, global popularity, and
        //     other factors. - Distance. This option biases search results in ascending order
        //     by their distance from the specified location. When distance is specified, one
        //     or more of keyword, name, or types is required. If rankby=distance is specified,
        //     then one or more of keyword, name, or types is required.
        public Ranking RankBy { get; set; } = Ranking.Prominence;

        // Summary:
        //     Type (optional). Restricts the results to places matching the specified type.
        //     Only one type may be specified (if more than one type is provided, all types
        //     following the first entry are ignored).
        public SearchPlaceType? Type { get; set; } = null;
    }
}
