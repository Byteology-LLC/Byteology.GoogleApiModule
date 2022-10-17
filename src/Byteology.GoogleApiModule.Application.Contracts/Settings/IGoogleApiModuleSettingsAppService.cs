using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Byteology.GoogleApiModule.Settings
{
    public interface IGoogleApiModuleSettingAppService : IApplicationService, ITransientDependency
    {
        Task<GoogleApiModuleSettingsDto> GetAsync();
        Task UpdateAsync(GoogleApiModuleUpdateSettingsDto input);
    }
}
