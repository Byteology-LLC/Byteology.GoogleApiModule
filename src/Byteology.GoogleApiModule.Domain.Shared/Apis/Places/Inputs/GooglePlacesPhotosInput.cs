using System;
using System.Collections.Generic;
using System.Text;

namespace Byteology.GoogleApiModule.Apis.Places.Inputs
{
    public class GooglePlacesPhotosInput
    {
        //
        // Summary:
        //     maxwidth — Specifies the maximum desired width, in pixels, of the image returned
        //     by the Place Photos service. If the image is smaller than the values specified,
        //     the original image will be returned. If the image is larger in either dimension,
        //     it will be scaled to match the smaller of the two dimensions, restricted to its
        //     original aspect ratio. Both the maxwidth properties accept an integer between
        //     1 and 1600.
        public virtual int? MaxWidth { get; set; } = 800;

        //
        // Summary:
        //     maxheight — Specifies the maximum desired height, in pixels, of the image returned
        //     by the Place Photos service. If the image is smaller than the values specified,
        //     the original image will be returned. If the image is larger in either dimension,
        //     it will be scaled to match the smaller of the two dimensions, restricted to its
        //     original aspect ratio. Both the maxheight properties accept an integer between
        //     1 and 1600.
        public virtual int? MaxHeight { get; set; } = 600;

        //
        // Summary:
        //     photoreference (required) — A string identifier that uniquely identifies a photo.
        //     Photo references are returned from either a Place Search or Place Details request.
        public virtual string PhotoReference { get; set; }
    }
}
