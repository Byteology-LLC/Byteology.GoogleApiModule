namespace Byteology.GoogleApiModule.Settings;

public static class GoogleApiModuleSettings
{
    public const string GroupName = "GoogleApiModule";

    /* Add constants for setting names. Example:
     * public const string MySettingName = GroupName + ".MySettingName";
     */

    public const string APIKey = GroupName + ".APIKey";
    public const string MapsApiKey = GroupName + ".MapsApiKey";
    public const string PlacesApiKey = GroupName + ".PlacesApiKey";
    public const string SearchApiKey = GroupName + ".SearchApiKey";
    public const string TranslateApiKey = GroupName + ".TranslateApiKey";
    public const string ClientId = GroupName + ".ClientId";
    public const string RequireGranularPermissions = GroupName + ".RequireGranularPermissions";
    public const string RequireAuthentication = GroupName + ".RequireAuthentication";
    public const string SearchEngineId = GroupName + ".SearchEngineId";
    public const string IncludePremiumEndpoints = GroupName + ".IncludePremiumEndpoints";
}
