
using GoogleApi.Entities.Maps.Roads.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Byteology.GoogleApiModule.Apis.Maps.Inputs
{
    public class GoogleMapsSnapToRoadsInput: GoogleMapsRoadsBaseInput
    {
        /// <summary>
        /// path — The path to be snapped (required). The path parameter accepts a list of latitude/longitude pairs. Latitude and longitude values should be separated by commas.
        /// Coordinates should be separated by the pipe character: "|". For example: path=60.170880,24.942795|60.170879,24.942796|60.170877,24.942796.
        /// </summary>
        [NotNull]
        public IEnumerable<Coordinate> Path { get; set; } = default;

        /// <summary>
        /// Interpolate — Whether to interpolate a path to include all points forming the full road-geometry.
        /// When true, additional interpolated points will also be returned, resulting in a path that smoothly follows the geometry of the road, even around corners and through tunnels.
        /// Interpolated paths will most likely contain more points than the original path. Defaults to false.
        /// </summary>
        public bool Interpolate { get; set; } = false;
    }
}
