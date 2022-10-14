using System;
using System.Collections.Generic;
using System.Text;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Search.Find.Request.Enums;
using JetBrains.Annotations;

namespace Byteology.GoogleApiModule.Apis.Places.Inputs
{
    public class GooglePlacesFindInput
    {
        /// <summary>
        /// Input.
        /// The text input specifying which place to search for (for example, a name, address, or phone number)
        /// </summary>
        [NotNull]
        public string Input { get; set; }

        /// <summary>
        /// Type.
        /// The type of input.This can be one of either textquery or phonenumber.
        /// </summary>
        [CanBeNull]
        public InputType Type { get; set; } = InputType.TextQuery;

        /// <summary>
        /// Language (optional).
        /// The language code, indicating in which language the results should be returned, if possible.
        /// Searches are also biased to the selected language; results in the selected language may be given a higher ranking.
        /// See the list of supported languages and their codes: https://developers.google.com/maps/faq#languagesupport
        /// Note that we often update supported languages so this list may not be exhaustive.
        /// </summary>
        [CanBeNull]
        public Language Language { get; set; } = Language.English;

        /// <summary>
        /// Fields (optional).
        /// Defaults to 'place_id'.
        /// The fields specifying the types of place data to return, separated by a comma.
        /// Note, if you omit the fields parameter from a Find Place request, only the place_id for the result will be returned.
        /// </summary>
        [CanBeNull]
        public FieldTypes Fields { get; set; } = FieldTypes.Basic;

        /// <summary>
        /// Radius (optional).
        /// Defines the radius of cirkular location bias.
        /// Ignored if <see cref="Location"/> is null.
        /// </summary>
        [CanBeNull]
        public int? Radius { get; set; } = null;

        /// <summary>
        /// Bounds (optional).
        /// Sets the bias to the defined bounds. 'rectangle:south, west|north, east.'
        /// Note that east/west values are wrapped to the range -180, 180, and north/south values are clamped to the range -90, 90.
        /// Ignored if <see cref="Location "/> is not null.
        /// </summary>
        [CanBeNull]
        public ViewPort Bounds { get; set; } = default;

        /// <summary>
        /// Location (optional).
        /// The results are biased based on th location (point). If <see cref="Radius"/> is specified as well, the bias is a circle having the center on the location
        /// and the radius in size.
        /// - A single lat/lng coordinate.Use the following format: 'point:lat, lng'
        /// - Circular: A string specifying radius in meters, plus lat/lng in decimal degrees. Format: 'circle:radius @lat, lng.'
        /// </summary>
        [CanBeNull]
        public Coordinate Location { get; set; } = default;

    }
}
