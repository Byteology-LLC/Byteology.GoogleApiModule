using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.StreetView.Request.Enums;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Byteology.GoogleApiModule.Apis.Maps.Inputs
{
    public class GoogleMapsStreetViewInput : BaseChannelInput
    {
        /// <summary>
        /// location can be either a text string (such as Chagrin Falls, OH) or a lat/lng value (40.457375,-80.009353).
        /// The Google Street View Image API will snap to the panorama photographed closest to this location.
        /// When an address text string is provided, the API may use a different camera location to better display the specified location. When a lat/lng is provided,
        /// the API searches a 50 meter radius for a photograph closest to this location.
        /// Because Street View imagery is periodically refreshed, and photographs may be taken from slightly different positions each time,
        /// it's possible that your location may snap to a different panorama when imagery is updated.
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// Pano is a specific panorama ID. These are generally stable
        /// Either Address, Location or Pano is required.
        /// </summary>
        public string PanoramaId { get; set; }

        /// <summary>
        /// Size specifies the output size of the image in pixels. Required.
        /// Size is specified as {width}x{height} - for example, size=600x400 returns an image 600 pixels wide, and 400 high.
        /// </summary>
        [NotNull]
        public MapSize Size { get; set; } = new(600, 400);

        /// <summary>
        /// Pitch (default is 0) specifies the up or down angle of the camera relative to the Street View vehicle.
        /// This is often, but not always, flat horizontal. Positive values angle the camera up (with 90 degrees indicating straight up);
        /// negative values angle the camera down (with -90 indicating straight down).
        /// </summary>
        public short Pitch { get; set; } = 0;

        /// <summary>
        /// Heading indicates the compass heading of the camera.
        /// Accepted values are from 0 to 360 (both values indicating North, with 90 indicating East, and 180 South).
        /// If no heading is specified, a value will be calculated that directs the camera towards the specified location,
        /// from the point at which the closest photograph was taken.
        /// </summary>
        public short? Heading { get; set; } = null;

        /// <summary>
        /// Fov (default is 90) determines the horizontal field of view of the image.
        /// The field of view is expressed in degrees, with a maximum allowed value of 120.
        /// When dealing with a fixed-size viewport, as with a Street View image of a set size,
        /// field of view in essence represents zoom, with smaller numbers indicating a higher level of zoom.
        /// </summary>
        public short FieldOfView { get; set; } = 90;

        /// <summary>
        /// radius(default is 50) sets a radius, specified in meters, in which to search for a panorama,
        /// centered on the given latitude and longitude.Valid values are non-negative integers.
        /// </summary>
        public int Radius { get; set; } = 50;

        /// <summary>
        /// return_error_code indicates whether the API should return an error code when no image is found(404 NOT FOUND),
        /// or in response to an invalid request(400 BAD REQUEST). Valid values are true and false.
        /// If set to true, an error message is returned in place of the generic gray image.
        /// This eliminates the need to make a separate call to check for image availability.
        /// </summary>
        public bool ReturnErrorCode { get; set; }

        /// <summary>
        /// source (default is default) limits Street View searches to selected sources. Valid values are:
        /// Default: uses the default sources for Street View; searches are not limited to specific sources.
        /// Outdoor: limits searches to outdoor collections. Indoor collections are not included in search results. 
        ///          Note that outdoor panoramas may not exist for the specified location. Also note that the search only 
        ///          returns panoramas where it's possible to determine whether they're indoors or outdoors. For example, 
        ///          PhotoSpheres are not returned because it's unknown whether they are indoors or outdoors.
        /// </summary>
        public Source Source { get; set; } = Source.Default;
    }
}
