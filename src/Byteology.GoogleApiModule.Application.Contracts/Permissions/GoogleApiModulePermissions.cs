using Volo.Abp.Reflection;

namespace Byteology.GoogleApiModule.Permissions;

public class GoogleApiModulePermissions
{
    public const string GroupName = "GoogleApiModule";
    public const string Settings = GroupName + ".Settings";

    public class Maps
    {
        public const string Default = GroupName + ".Maps";
        public const string Directions = Default + ".Directions";
        public const string DistanceMatrix = Default + ".DistanceMatrix";
        public const string Elevation = Default + ".Elevation";

        public class Geocode
        {
            public const string Default = Maps.Default + ".Geocode";
            public const string Place = Default + ".Place";
            public const string Address = Default + ".Address";
            public const string PlusCode = Default + ".PlusCode";
            public const string Location = Default + ".Location";
        }

        public const string Geolocation = Default + ".Geolocation";

        public class Roads
        {
            public const string Default = Maps.Default + ".Roads";
            public const string NearestRoads = Default + ".NearestRoads";
            public const string SnapToRoads = Default + ".SnapToRoads";
            public const string SpeedLimits = Default + ".SpeedLimits";
        }

        public const string TimeZone = Default + ".TimeZone";
        public const string StreetView = Default + ".StreetView";
        public const string StaticMaps = Default + ".StaticMaps";

    }

    public class Places
    {
        public const string Default = GroupName + ".Places";

        public class Search
        {
            public const string Default = Places.Default + ".Search";
            public const string Find = Default + ".Find";
            public const string NearBy = Default + ".NearBy";
            public const string Text = Default + ".Text";
        }

        public const string Details = Default + ".Details";
        public const string Photos = Default + ".Photos";
        public const string AutoComplete = Default + ".AutoComplete";
        public const string QueryAutoComplete = Default + ".QueryAutoComplete";
    }

    public class Search
    {
        public const string Default = GroupName + ".Search";
        public const string Web = Default + ".Web";
        public const string Image = Default + ".Image";
        public class Video
        {
            public const string Default = Search.Default + ".Video";
            public const string Channels = Default + ".Channels";
            public const string Playlists = Default + ".Playlists";
            public const string Videos = Default + ".Videos";
        }
    }

    public class Translate
    {
        public const string Default = GroupName + ".Translate";
        public const string Detect = Default + ".Detect";
        public const string Languages = Default + ".Languages";
    }

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(GoogleApiModulePermissions));
    }
}
