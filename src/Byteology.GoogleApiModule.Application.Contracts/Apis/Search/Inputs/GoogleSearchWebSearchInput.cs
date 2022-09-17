using GoogleApi.Entities.Search.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Byteology.GoogleApiModule.Apis.Search.Inputs
{
    public class GoogleSearchWebSearchInput : GoogleSearchBaseSearchInput
    {
        /// <summary>
        /// Define properties of your search, like the search expression, number of results, language etc.
        /// </summary>
        public SearchOptions Options { get; set; } = new();
    }
}
