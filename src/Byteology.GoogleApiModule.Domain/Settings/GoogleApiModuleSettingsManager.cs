using Byteology.GoogleApiModule.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core.CustomTypeProviders;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Services;
using Volo.Abp.Security.Encryption;
using Volo.Abp.SettingManagement;
using Volo.Abp.Settings;

namespace Byteology.GoogleApiModule.Settings
{
    public class GoogleApiModuleSettingsManager: DomainService, ITransientDependency
    {
        protected GoogleApiModuleOptions Options { get; }
        protected ISettingProvider SettingProvider { get; }
        protected IStringEncryptionService StringEncryptionService { get; }
        protected IConfiguration Configuration { get; }
        protected ISettingManager SettingManager { get; }

        public GoogleApiModuleSettingsManager(IConfiguration configuration, IStringEncryptionService stringEncryptionService, ISettingProvider settingProvider,
            IOptions<GoogleApiModuleOptions> options, ISettingManager settingManager)
        {
            Configuration = configuration;
            StringEncryptionService = stringEncryptionService;
            SettingProvider = settingProvider;
            Options = options.Value;
            SettingManager = settingManager;
        }

        /// <summary>
        /// Gets the settings. Fails back to configuration if settings aren't available and Option values if configuration isn't available.
        /// </summary>
        /// <returns></returns>
        public virtual async Task<GoogleApiModuleSettingsDto> GetAsync()
        {

            var settings = new GoogleApiModuleSettingsDto();

            //if no setting is present, fall back to Configuration, then Defaults to Option value


            settings.ApiKey = await GetString(GoogleApiModuleSettings.APIKey, true, Options.APIKey);
            settings.MapsApiKey = await GetString(GoogleApiModuleSettings.MapsApiKey, true, Options.MapsApiKey);
            settings.PlacesApiKey = await GetString(GoogleApiModuleSettings.PlacesApiKey, true, Options.PlacesApiKey);
            settings.SearchApiKey = await GetString(GoogleApiModuleSettings.SearchApiKey, true, Options.SearchApiKey);
            settings.TranslateApiKey = await GetString(GoogleApiModuleSettings.TranslateApiKey, true, Options.TranslateApiKey);
            settings.ClientId = await GetString(GoogleApiModuleSettings.ClientId, false, Options.ClientId);
            settings.RequireGranularPermissions = await SettingProvider.GetAsync<bool>(GoogleApiModuleSettings.RequireGranularPermissions, defaultValue: Options.RequireGranularPermissions);
            settings.RequireAuthentication = await SettingProvider.GetAsync<bool>(GoogleApiModuleSettings.RequireAuthentication, defaultValue: Options.RequireAuthentication);
            settings.SearchEngineId = await GetString(GoogleApiModuleSettings.SearchEngineId, false, Options.SearchEngineId);
            settings.IncludePremiumEndpoints = await SettingProvider.GetAsync<bool>(GoogleApiModuleSettings.IncludePremiumEndpoints, defaultValue: Options.IncludePremiumEndpoints);

            return settings;
        }

        public virtual async Task UpdateAsync(GoogleApiModuleUpdateSettingsDto input)
        {
            await UpdateSetting(GoogleApiModuleSettings.APIKey, input.ApiKey);
            await UpdateSetting(GoogleApiModuleSettings.MapsApiKey, input.MapsApiKey);
            await UpdateSetting(GoogleApiModuleSettings.PlacesApiKey, input.PlacesApiKey);
            await UpdateSetting(GoogleApiModuleSettings.SearchApiKey, input.SearchApiKey);
            await UpdateSetting(GoogleApiModuleSettings.TranslateApiKey, input.TranslateApiKey);
            await UpdateSetting(GoogleApiModuleSettings.ClientId, input.ClientId);
            await UpdateSetting(GoogleApiModuleSettings.SearchEngineId, input.SearchEngineId);


            if (input.RequireGranularPermissions.HasValue)
            {
                await UpdateSetting(GoogleApiModuleSettings.RequireGranularPermissions, input.RequireGranularPermissions == true ? "True" : "False");
            }

            if (input.RequireAuthentication.HasValue)
            {
                await UpdateSetting(GoogleApiModuleSettings.RequireAuthentication, input.RequireAuthentication == true ? "True" : "False");
            }

            if (input.IncludePremiumEndpoints.HasValue)
            {
                await UpdateSetting(GoogleApiModuleSettings.IncludePremiumEndpoints, input.IncludePremiumEndpoints == true ? "True" : "False");
            }
        }

        private async Task UpdateSetting(string settingName, string settingValue)
        {
            if (!string.IsNullOrWhiteSpace(settingValue))
            {
                await SettingManager.SetGlobalAsync(settingName, settingValue);
            }
        }

        public async Task<string> GetString(string settingName, bool isEncrypted = false, string defaultValue = null)
        {
            var settingsValue = await SettingProvider.GetOrNullAsync(settingName);

            if (!string.IsNullOrWhiteSpace(settingsValue))
                return settingsValue;

            var config = Configuration.GetSection("Settings");
            var value = config.GetValue<string>(settingName);

            if (!string.IsNullOrEmpty(value))
            {
                
                if(isEncrypted)
                {
                    //check encryption
                    try
                    {
                        var decrypt = StringEncryptionService.Decrypt(value);
                        return decrypt;
                    }
                    catch (FormatException ex)
                    {
                        //will catch here if the string is there but NOT encrypted.
                        return value;
                    }
                }                

                //will fall out here if the string decrypts successfully or if isEncrypted is set to false, so we can return the original encrypted string.
                return value;
            }
            else
            {
                //if both the Config and the Settings are set to null, return the default value (ideally the Options value)
                return defaultValue;
            }
        }
    }
}
