using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Byteology.GoogleApiModule.Apis.Maps.Inputs
{
    public class GoogleMapsGeocodeBaseInput : BaseChannelInput
    {
        /// <summary>
        /// Region (optional) — The region code, specified as a ccTLD ("top-level domain") two-character value. (For more information see Region Biasing below.)
        /// The bounds and region parameters will only influence, not fully restrict, results from the geocoder.
        /// </summary>
        [CanBeNull]
        public virtual string Region { get; set; }

        /// <summary>
        /// Bounds (optional) — The bounding box of the viewport within which to bias geocode results more prominently. (For more information see Viewport Biasing below.)
        /// The bounds and region parameters will only influence, not fully restrict, results from the geocoder.
        /// For more information see: https://developers.google.com/maps/documentation/geocoding/intro#Viewports
        /// </summary>
        [CanBeNull]
        public virtual ViewPort Bounds { get; set; }

        /// <summary>
        /// Components. The component filters, separated by a pipe (|).
        /// Each component filter consists of a component:value pair and will fully restrict the results from the geocoder.
        /// For more information see Component Filtering: https://developers.google.com/maps/documentation/geocoding/intro#ComponentFiltering
        /// </summary>
        [CanBeNull]
        public virtual IEnumerable<KeyValuePair<Component, string>> Components { get; set; } = default;
    }
}
