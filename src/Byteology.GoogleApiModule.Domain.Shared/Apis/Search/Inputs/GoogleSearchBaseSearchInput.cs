using GoogleApi.Entities.Search.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Byteology.GoogleApiModule.Apis.Search.Inputs
{
    public class GoogleSearchBaseSearchInput
    {
        /// <summary>
        /// Alt - Data format for the response. (only json supported)
        /// Valid values: json, atom
        /// Default value: json
        /// </summary>
        public AltType Alt => AltType.Json;

        /// <summary>
        /// Allowed values are web or image. If unspecified, results are limited to webpages.
        /// </summary>
        public SearchType SearchType { get; set; } = SearchType.Web;

        /// <summary>
        /// Required.
        /// Use the q query parameter to specify your search expression.
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Callback function.
        /// Name of the JavaScript callback function that handles the response.
        /// Used in JavaScript JSON-P requests
        /// </summary>
        public string Callback { get; set; }

        /// <summary>
        /// fields - Selector specifying a subset of fields to include in the response.
        /// For more information, see the partial response section in the Performance Tips document.
        /// Use for better performance. https://developers.google.com/custom-search/json-api/v1/performance#partial
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// PrettyPrint - Returns response with indentations and line breaks.
        /// Returns the response in a human-readable format if true.
        /// Default value: true.
        /// When this is false, it can reduce the response payload size, which might lead to better performance in some environments.
        /// </summary>
        public bool PrettyPrint { get; set; } = true;

        /// <summary>
        /// userIp IP address of the end user for whom the API call is being made.
        /// Lets you enforce per-user quotas when calling the API from a server-side application.
        /// Learn more about Capping API usage. https://support.google.com/cloud/answer/7035610
        /// </summary>
        public string UserIp { get; set; }

        /// <summary>
        /// quotaUser Alternative to userIp.
        /// Lets you enforce per-user quotas from a server-side application even in cases when the user's IP address is unknown. This can occur, for example, with applications that run cron jobs on App Engine on a user's behalf.
        /// You can choose any arbitrary string that uniquely identifies a user, but it is limited to 40 characters.
        /// Overrides userIp if both are provided.
        /// Learn more about Capping API usage. https://support.google.com/cloud/answer/7035610
        /// </summary>
        public string QuotaUser { get; set; }
    }
}
