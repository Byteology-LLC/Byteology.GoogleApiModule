using GoogleApi.Entities.Search.Common;
using GoogleApi.Entities.Search.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Byteology.GoogleApiModule.Apis.Search.Inputs
{
    public class GoogleSearchImageSearchInput : GoogleSearchWebSearchInput
    {
        /// <summary>
        /// Search Image Options.
        /// </summary>
        public virtual SearchImageOptions ImageOptions { get; set; } = new();

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public GoogleSearchImageSearchInput() => this.SearchType = SearchType.Image;
    }
}
