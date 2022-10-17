using System;
using System.Collections.Generic;
using System.Text;

namespace Byteology.GoogleApiModule.Settings
{
    public class GoogleApiModuleSettingsDto
    {
        public string ApiKey { get; set; } 
        public string MapsApiKey { get; set; }
        public string PlacesApiKey { get; set; }
        public string SearchApiKey { get; set; }
        public string TranslateApiKey { get; set; }
        public string ClientId { get; set; }
        public bool RequireGranularPermissions { get; set; } = true;
        public bool RequireAuthentication { get; set; } = true;
        public string SearchEngineId { get; set; }
        public bool IncludePremiumEndpoints { get; set; } = false;
    }
}
