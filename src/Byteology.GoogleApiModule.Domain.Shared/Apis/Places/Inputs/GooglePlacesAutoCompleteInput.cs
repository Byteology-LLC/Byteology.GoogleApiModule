using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.AutoComplete.Request.Enums;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Byteology.GoogleApiModule.Apis.Places.Inputs
{
    public class GooglePlacesAutoCompleteInput
    {
        /// <summary>
        /// The text string on which to search. The Place service will return candidate matches based on this string and order results based on their perceived relevance.
        /// </summary>
        [NotNull]
        public string Input { get; set; }

        /// <summary>
        /// The character position in the input term at which the service uses text for predictions.
        /// For example, if the input is 'Googl' and the completion point is 3, the service will match on 'Goo'.
        /// The offset should generally be set to the position of the text caret. If no offset is supplied, the service will use the entire term.
        /// </summary>
        [CanBeNull]
        public string Offset { get; set; } = null;

        /// <summary>
        /// The point around which you wish to retrieve Place information.
        /// </summary>
        [CanBeNull]
        public Coordinate Location { get; set; } = null;

        /// <summary>
        /// The origin point from which to calculate straight-line distance to the destination (returned as distance_meters).
        /// If this value is omitted, straight-line distance will not be returned.
        /// Must be specified as latitude,longitude.
        /// </summary>
        [CanBeNull]
        public Coordinate Origin { get; set; } = null;

        /// <summary>
        /// The distance (in meters) within which to return Place results.
        /// Note that setting a radius biases results to the indicated area, but may not fully restrict results to the specified area.
        /// See Location Biasing below.
        /// </summary>
        [CanBeNull]
        public double? Radius { get; set; } = null;

        /// <summary>
        /// Strictbounds.
        /// Returns only those places that are strictly within the region defined by location and radius.
        /// This is a restriction, rather than a bias, meaning that results outside this region will not be returned even if they match the user input.
        /// </summary>
        [CanBeNull]
        public bool StrictBounds { get; set; } = false;

        /// <summary>
        /// The language in which to return results. See the supported list of domain languages.
        /// Note that we often update supported languages so this list may not be exhaustive.
        /// If language is not supplied, the Place service will attempt to use the native language of the domain from which the request is sent.
        /// </summary>
        [CanBeNull]
        public Language Language { get; set; } = Language.English;

        /// <summary>
        /// The types of Place results to return. See Place Types below. If no type is specified, all types will be returned.
        /// https://developers.google.com/places/supported_types#table3
        /// </summary>
        [CanBeNull]
        public IEnumerable<RestrictPlaceType> Types { get; set; } = null;

        /// <summary>
        /// The component filters, separated by a pipe (|).
        /// Each component filter consists of a component:value pair and will fully restrict the results from the geocoder.
        /// For more information see Component Filtering.
        /// </summary>
        [CanBeNull]
        public IEnumerable<KeyValuePair<Component, string>> Components { get; set; } = null;
    }
}
