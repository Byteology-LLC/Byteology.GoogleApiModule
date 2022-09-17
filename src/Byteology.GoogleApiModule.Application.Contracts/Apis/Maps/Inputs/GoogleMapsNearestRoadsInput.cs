
using GoogleApi.Entities.Maps.Roads.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Byteology.GoogleApiModule.Apis.Maps.Inputs
{
    public class GoogleMapsNearestRoadsInput : GoogleMapsRoadsBaseInput
    {
        /// <summary>
        /// points — A list of latitude/longitude pairs. Latitude and longitude values should be separated by commas.
        /// Coordinates should be separated by the pipe character: "|".
        /// For example: points=60.170880,24.942795|60.170879,24.942796|60.170877,24.942796.
        /// </summary>
        [NotNull]
        public IEnumerable<Coordinate> Points { get; set; } = default;
    }
}
