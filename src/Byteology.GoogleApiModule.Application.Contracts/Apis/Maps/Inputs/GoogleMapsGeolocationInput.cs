using GoogleApi.Entities.Maps.Geolocation.Request;
using GoogleApi.Entities.Maps.Geolocation.Request.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Byteology.GoogleApiModule.Apis.Maps.Inputs
{
    public class GoogleMapsGeolocationInput
    {
        /// <summary>
        /// The carrier name.
        /// </summary>
        public string Carrier { get; set; }

        /// <summary>
        /// The mobile country code (MCC) for the device's home network.
        /// </summary>
        public string HomeMobileCountryCode { get; set; }

        /// <summary>
        /// The mobile network code (MNC) for the device's home network.
        /// </summary>
        public string HomeMobileNetworkCode { get; set; }

        /// <summary>
        /// The mobile radio type.
        /// Supported values are lte, gsm, cdma, and wcdma. While this field is optional, it should be included if a value is available,
        /// for more accurate results.
        /// </summary>
        public RadioType? RadioType { get; set; } = null;

        /// <summary>
        /// Specifies whether to fall back to IP geolocation if wifi and cell tower signals are not available.
        /// Note that the IP address in the request header may not be the IP of the device.
        /// Defaults to true.
        /// Set considerIp to false to disable fallback.
        /// </summary>
        public bool ConsiderIp { get; set; } = true;

        /// <summary>
        /// An array of cell tower objects. See <see cref="CellTower"/>.
        /// </summary>
        public IEnumerable<CellTower> CellTowers { get; set; } = default;

        /// <summary>
        /// An array of WiFi access point objects. See  <see cref="WifiAccessPoint"/>.
        /// </summary>
        public IEnumerable<WifiAccessPoint> WifiAccessPoints { get; set; } = default;
    }
}
