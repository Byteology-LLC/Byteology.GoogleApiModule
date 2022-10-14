using GoogleApi.Entities.Search.Video.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Byteology.GoogleApiModule.Apis.Search.Inputs
{
    public class GoogleSearchVideoPlaylistSearchInput: GoogleSearchBaseVideoSearchInput
    {
        /// <summary>
        /// The channelId parameter indicates that the API response should only contain resources created by the channel.
        /// Note: Search results are constrained to a maximum of 500 videos if your request specifies a value for the channelId parameter and
        /// sets the type parameter value to video, but it does not also set one of the forContentOwner, forDeveloper, or forMine filters.
        /// </summary>
        public string ChannelId { get; set; }

        /// <summary>
        /// The channelType parameter lets you restrict a search to a particular type of channel.
        /// </summary>
        public ChannelType ChannelType { get; set; } = ChannelType.Any;
    }
}
