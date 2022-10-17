using Byteology.GoogleApiModule.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace Byteology.GoogleApiModule.Settings;

public class GoogleApiModuleSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        /* Define module settings here.
         * Use names from GoogleApiModuleSettings class.
         */

        context.Add(new SettingDefinition(GoogleApiModuleSettings.APIKey,
            displayName: new LocalizableString(typeof(GoogleApiModuleResource), "Settings:APIKey"),
            description: new LocalizableString(typeof(GoogleApiModuleResource), "Settings:APIKey:Description"),
            isVisibleToClients: false,
            isEncrypted: true));

        context.Add(new SettingDefinition(GoogleApiModuleSettings.MapsApiKey,
            displayName: new LocalizableString(typeof(GoogleApiModuleResource), "Settings:MapsApiKey"),
            description: new LocalizableString(typeof(GoogleApiModuleResource), "Settings:MapsApiKey:Description"),
            isVisibleToClients: false,
            isEncrypted: true));

        context.Add(new SettingDefinition(GoogleApiModuleSettings.PlacesApiKey,
            displayName: new LocalizableString(typeof(GoogleApiModuleResource), "Settings:PlacesApiKey"),
            description: new LocalizableString(typeof(GoogleApiModuleResource), "Settings:PlacesApiKey:Description"),
            isVisibleToClients: false,
            isEncrypted: true));

        context.Add(new SettingDefinition(GoogleApiModuleSettings.SearchApiKey,
            displayName: new LocalizableString(typeof(GoogleApiModuleResource), "Settings:SearchApiKey"),
            description: new LocalizableString(typeof(GoogleApiModuleResource), "Settings:SearchApiKey:Description"),
            isVisibleToClients: false,
            isEncrypted: true));

        context.Add(new SettingDefinition(GoogleApiModuleSettings.TranslateApiKey,
            displayName: new LocalizableString(typeof(GoogleApiModuleResource), "Settings:TranslateApiKey"),
            description: new LocalizableString(typeof(GoogleApiModuleResource), "Settings:TranslateApiKey:Description"),
            isVisibleToClients: false,
            isEncrypted: true));

        context.Add(new SettingDefinition(GoogleApiModuleSettings.ClientId,
            displayName: new LocalizableString(typeof(GoogleApiModuleResource), "Settings:ClientId"),
            description: new LocalizableString(typeof(GoogleApiModuleResource),"Settings:ClientId:Description"),
            isVisibleToClients: false,
            isEncrypted: false));

        context.Add(new SettingDefinition(GoogleApiModuleSettings.RequireGranularPermissions,
            displayName: new LocalizableString(typeof(GoogleApiModuleResource), "Settings:RequireGranularPermissions"),
            description: new LocalizableString(typeof(GoogleApiModuleResource), "Settings:RequireGranularPermissions:Description"),
            isVisibleToClients: false,
            isEncrypted: false,
            defaultValue: "false"));

        context.Add(new SettingDefinition(GoogleApiModuleSettings.RequireAuthentication,
            displayName: new LocalizableString(typeof(GoogleApiModuleResource), "Settings:RequireAuthentication"),
            description: new LocalizableString(typeof(GoogleApiModuleResource), "Settings:RequireAuthentication:Description"),
            isVisibleToClients: false,
            isEncrypted: false,
            defaultValue: "true"));

        context.Add(new SettingDefinition(GoogleApiModuleSettings.SearchEngineId,
            displayName: new LocalizableString(typeof(GoogleApiModuleResource), "Settings:SearchEngineId"),
            description: new LocalizableString(typeof(GoogleApiModuleResource), "Settings:SearchEngineId:Description"),
            isVisibleToClients: false,
            isEncrypted: false));

        context.Add(new SettingDefinition(GoogleApiModuleSettings.IncludePremiumEndpoints,
            displayName: new LocalizableString(typeof(GoogleApiModuleResource), "Settings:IncludePremiumEndpoints"),
            description: new LocalizableString(typeof(GoogleApiModuleResource), "Settings:IncludePremiumEndpoints:Description"),
            isVisibleToClients: false,
            isEncrypted: false,
            defaultValue: "true"));
    }
}
