using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.StaticMaps.Request;
using GoogleApi.Entities.Maps.StaticMaps.Request.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Byteology.GoogleApiModule.Apis.Maps.Inputs
{
    public class GoogleMapsStaticMapsInput : BaseChannelInput
    {
        /// <summary>
        /// center (required if markers not present) defines the center of the map, equidistant from all edges of the map.
        /// This parameter takes a location as either a comma-separated {latitude,longitude} pair (e.g. "40.714728,-73.998672") or a string address (e.g. "city hall, new york, ny")
        /// identifying a unique location on the face of the earth. For more information, see Locations below.
        /// </summary>
        public Location Center { get; set; }

        /// <summary>
        /// Zoom (required if markers not present) defines the zoom level of the map, which determines the magnification level of the map.
        /// This parameter takes a numerical value corresponding to the zoom level of the region desired. For more information, see zoom levels below.
        /// Maps on Google Maps have an integer 'zoom level' which defines the resolution of the current view.
        /// Zoom levels between 0 (the lowest zoom level, in which the entire world can be seen on one map) and 21+ (down to streets and individual buildings)
        /// are possible within the default roadmap view. Building outlines, where available, appear on the map around zoom level 17.
        /// This value differs from area to area and can change over time as the data evolves.
        /// Google Maps sets zoom level 0 to encompass the entire earth.Each succeeding zoom level doubles the precision in both horizontal and vertical dimensions.
        /// Note: not all zoom levels appear at all locations on the earth.
        /// Zoom levels vary depending on location, as data in some parts of the globe is more granular than in other locations.
        /// If you send a request for a zoom level at which no map tiles are available, the Google Static Maps API will return a map showing the maximum zoom level available
        /// at that location. The following list shows the approximate level of detail you can expect to see at each zoom level:
        /// - 1: World
        /// - 5: Landmass/continent
        /// - 10: City
        /// - 15: Streets
        /// - 20: Buildings
        /// </summary>
        public byte? ZoomLevel { get; set; }

        /// <summary>
        /// Size (required) defines the rectangular dimensions of the map image.
        /// This parameter takes a string of the form {horizontal_value}x{vertical_value}. For example, 500x400 defines a map 500 pixels wide by 400 pixels high.
        /// Maps smaller than 180 pixels in width will display a reduced-size Google logo.
        /// This parameter is affected by the scale parameter, described below; the final output size is the product of the size and scale values.
        /// </summary>
        public MapSize Size { get; set; } = new(640, 640);

        /// <summary>
        /// Defines the type of map to construct. There are several possible
        /// maptype values, including roadmap, satellite, hybrid, and terrain. (optional)
        /// </summary>
        /// <remarks>http://code.google.com/apis/maps/documentation/staticmaps/#MapTypes</remarks>
        public MapType Type { get; set; } = MapType.Roadmap;

        /// <summary>
        /// Scale (optional) affects the number of pixels that are returned. scale=2 returns twice as many pixels as scale=1 while retaining the same coverage area and
        /// level of detail (i.e. the contents of the map don't change). This is useful when developing for high-resolution displays, or when generating a map for printing.
        /// The default value is 1. Accepted values are 2 and 4 (4 is only available to Google Maps APIs Premium Plan customers.)
        /// See Scale Values for more information: https://developers.google.com/maps/documentation/static-maps/intro#scale_values
        /// </summary>
        public MapScale Scale { get; set; } = MapScale.Normal;

        /// <summary>
        /// Format (optional) defines the format of the resulting image. By default, the Google Static Maps API creates PNG images.
        /// There are several possible formats including GIF, JPEG and PNG types. Which format you use depends on how you intend to present the image.
        /// JPEG typically provides greater compression, while GIF and PNG provide greater detail. For more information, see Image Formats.
        /// greater compression, while GIF and PNG provide greater detail. (optional)
        /// </summary>
        public ImageFormat Format { get; set; } = ImageFormat.Png;

        /// <summary>
        /// Language (optional) defines the language to use for display of labels on map tiles.
        /// Note that this parameter is only supported for some country tiles; if the specific language requested is not supported for the tile set,
        /// then the default language for that tileset will be used.
        /// </summary>
        public Language Language { get; set; } = Language.English;

        /// <summary>
        /// region (optional) defines the appropriate borders to display, based on geo-political sensitivities.
        /// Accepts a region code specified as a two-character ccTLD ('top-level domain') value
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Paths (optional) defines a single path of two or more connected points to overlay on the image at specified locations.
        /// This parameter takes a string of point definitions separated by the pipe character (|), or an encoded polyline using the enc: prefix within
        /// the location declaration of the path. You may supply additional paths by adding additional path parameters.
        /// Note that if you supply a path for a map, you do not need to specify the (normally required) center and zoom parameters.
        /// For more information, see Google Static Maps API Paths below. https://developers.google.com/maps/documentation/static-maps/intro#Paths
        /// </summary>
        public IEnumerable<MapPath> Paths { get; set; } = default;

        /// <summary>
        /// Style (optional) defines a custom style to alter the presentation of specific features (roads, parks, and other features) of the map.
        /// This parameter takes features and element arguments identifying the features to style, and a set of style operations to apply to the selected features.
        /// You can supply multiple styles by adding additional style parameters.
        /// For more information, see the guide to styled maps.
        /// </summary>
        public IEnumerable<MapStyle> Styles { get; set; } = default;

        /// <summary>
        /// Visibles (optional) specifies one or more locations that should remain visible on the map, though no markers or other indicators will be displayed.
        /// Use this parameter to ensure that certain features or map locations are shown on the Google Static Maps API.
        /// </summary>
        public IEnumerable<Location> Visibles { get; set; } = default;

        /// <summary>
        /// Markers (optional) define one or more markers to attach to the image at specified locations.
        /// This parameter takes a single marker definition with parameters separated by the pipe character (|).
        /// Multiple markers may be placed within the same markers parameter as long as they exhibit the same style;
        /// you may add additional markers of differing styles by adding additional markers parameters. Note that if you supply markers for a map,
        /// you do not need to specify the (normally required) center and zoom parameters.
        /// For more information, see Google Static Maps API Markers below. https://developers.google.com/maps/documentation/static-maps/intro#Markers
        /// </summary>
        public IEnumerable<MapMarker> Markers { get; set; } = default;
    }
}
