using Byteology.GoogleApiModule.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Security.Encryption;
using Volo.Abp.SettingManagement;
using Volo.Abp.Settings;

namespace Byteology.GoogleApiModule.Settings
{
    [Authorize(GoogleApiModulePermissions.Settings)]
    public class GoogleApiModuleSettingAppService : SettingManagementAppServiceBase, IGoogleApiModuleSettingAppService
    {
        protected GoogleApiModuleSettingsManager SettingManager { get; }

        public GoogleApiModuleSettingAppService(GoogleApiModuleSettingsManager settingManager)
        {
            SettingManager = settingManager;
        }

        public virtual async Task<GoogleApiModuleSettingsDto> GetAsync()
        {
            
            return await SettingManager.GetAsync();
        }
        
        public virtual async Task UpdateAsync(GoogleApiModuleUpdateSettingsDto input)
        {
            await SettingManager.UpdateAsync(input);
        }
    }
}
