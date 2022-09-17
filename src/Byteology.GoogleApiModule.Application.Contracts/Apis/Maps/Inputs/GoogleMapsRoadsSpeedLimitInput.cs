
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Roads.Common;
using GoogleApi.Entities.Maps.Roads.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Byteology.GoogleApiModule.Apis.Maps.Inputs
{
    public class GoogleMapsRoadsSpeedLimitInput: GoogleMapsRoadsBaseInput
    {
        /// <summary>
        /// path — The path to be snapped (required or PlaceIds).
        /// The path parameter accepts a list of latitude/longitude pairs.
        /// Latitude and longitude values should be separated by commas.
        /// Coordinates should be separated by the pipe character: "|". For example: path=60.170880,24.942795|60.170879,24.942796|60.170877,24.942796.
        /// </summary>
        public IEnumerable<Coordinate> Path { get; set; } = default;

        /// <summary>
        /// placeId — The place ID of the road segment.
        /// Place IDs are returned by the snapToRoads method. You can pass up to 100 placeIds with each request.
        /// </summary>
        public IEnumerable<Place> Places { get; set; } = default;

        /// <summary>
        /// units (optional) — Whether to return speed limits in kilometers or miles per hour. This can be set to either KPH or MPH. Defaults to MPH.
        /// </summary>
        public Units Unit { get; set; } = Units.Mph;
    }
}
