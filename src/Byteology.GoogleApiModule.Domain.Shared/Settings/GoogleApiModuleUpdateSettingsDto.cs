using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Auditing;
using System.ComponentModel.DataAnnotations;

namespace Byteology.GoogleApiModule.Settings
{
    public class GoogleApiModuleUpdateSettingsDto
    {
        [DisableAuditing]
        [DataType(DataType.Password)]
        public string ApiKey { get; set; }
        [DisableAuditing]
        [DataType(DataType.Password)]
        public string MapsApiKey { get; set; }
        [DisableAuditing]
        [DataType(DataType.Password)]
        public string PlacesApiKey { get; set; }
        [DisableAuditing]
        [DataType(DataType.Password)]
        public string SearchApiKey { get; set; }
        [DisableAuditing]
        [DataType(DataType.Password)]
        public string TranslateApiKey { get; set; }
        public string ClientId { get; set; }
        public bool? RequireGranularPermissions { get; set; }
        public bool? RequireAuthentication { get; set; }
        public string SearchEngineId { get; set; }
        public bool? IncludePremiumEndpoints { get; set; }
    }
}
