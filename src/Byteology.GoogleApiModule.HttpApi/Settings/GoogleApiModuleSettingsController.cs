using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Byteology.GoogleApiModule.Settings
{
    [Controller]
    [Area("googleapimodule")]
    [Route("api/google-apis/settings")]
    public class GoogleApiModuleSettingsController : AbpController, IGoogleApiModuleSettingAppService
    {
        private readonly IGoogleApiModuleSettingAppService AppService;

        
        public GoogleApiModuleSettingsController(IGoogleApiModuleSettingAppService appService)
        {
            AppService = appService;
        }

        [HttpGet]
        public Task<GoogleApiModuleSettingsDto> GetAsync()
        {
            return AppService.GetAsync();
        }

        [HttpPost]
        public Task UpdateAsync(GoogleApiModuleUpdateSettingsDto input)
        {
            return AppService.UpdateAsync(input);
        }
    }
}
