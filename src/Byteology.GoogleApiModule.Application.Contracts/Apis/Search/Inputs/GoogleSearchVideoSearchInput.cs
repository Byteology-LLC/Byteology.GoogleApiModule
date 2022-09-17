using GoogleApi.Entities.Search.Video.Common.Enums;
using GoogleApi.Entities.Search.Common.Enums;
using GoogleApi.Entities.Search.Video.Videos.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Byteology.GoogleApiModule.Apis.Search.Inputs
{
    public class GoogleSearchVideoSearchInput: GoogleSearchBaseVideoSearchInput
    {
        /// <summary>
        /// The channelId parameter indicates that the API response should only contain resources created by the channel.
        /// Note: Search results are constrained to a maximum of 500 videos if your request specifies a value for the channelId parameter and
        /// sets the type parameter value to video, but it does not also set one of the forContentOwner, forDeveloper, or forMine filters.
        /// </summary>
        public string ChannelId { get; set; }

        /// <summary>
        /// The relatedToVideoId parameter retrieves a list of videos that are related to the video that the parameter value identifies.
        /// The parameter value must be set to a YouTube video ID and, if you are using this parameter, the type parameter must be set to video.
        /// NOTE, that if the relatedToVideoId parameter is set, the only other supported parameters are
        /// - part,
        /// - maxResults,
        /// - pageToken,
        /// - regionCode,
        /// - relevanceLanguage,
        /// - safeSearch,
        /// - type (which must be set to video),
        /// - and fields.
        /// </summary>
        public string RelatedToVideoId { get; set; }

        /// <summary>
        /// The eventType parameter restricts a search to broadcast events.
        /// If you specify a value for this parameter, you must also set the type parameter's value to video.
        /// </summary>
        public EventType? EventType { get; set; }

        /// <summary>
        /// The channelType parameter lets you restrict a search to a particular type of channel.
        /// </summary>
        public ChannelType? ChannelType { get; set; }

        /// <summary>
        /// Options.
        /// Additional video options.
        /// </summary>
        public VideoOptions Options { get; set; } = new();

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public GoogleSearchVideoSearchInput()
        {
            this.SearchType = SearchType.Video;
        }
    }
}
