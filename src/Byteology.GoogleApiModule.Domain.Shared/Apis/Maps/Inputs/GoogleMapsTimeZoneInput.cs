using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Byteology.GoogleApiModule.Apis.Maps.Inputs
{
    public class GoogleMapsTimeZoneInput : BaseChannelInput
    {
        /// <summary>
        /// A comma-separated lat,lng tuple (eg. location=-33.86,151.20), representing the location to look up
        /// </summary>
        [NotNull]
        public Coordinate Location { get; set; }

        /// <summary>
        /// Timestamp specifies the desired time as seconds since midnight, January 1, 1970 UTC.
        /// The Time Zone API uses the timestamp to determine whether or not Daylight Savings should be applied.
        /// Times before 1970 can be expressed as negative values.
        /// </summary>
        [NotNull]
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// The language in which to return results. See the list of supported domain languages.
        /// Note that we often update supported languages so this list may not be exhaustive. Defaults to en.
        /// </summary>
        [CanBeNull]
        public Language Language { get; set; } = Language.English;
    }
}
