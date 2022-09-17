using System;
using System.Collections.Generic;
using System.Text;

namespace Byteology.GoogleApiModule.Options
{
    public class GoogleApiModuleOptions
    {
        /// <summary>
        /// Your application's API key (required). This assumes that the API has access to all necessary endpoints (maps, places, search, and translate)
        /// This key identifies your application for purposes of quota management and so that Places added from your application are made immediately available to your app.
        /// Visit the APIs Console to create an API Project and obtain your key.
        /// https://developers.google.com/maps/api-key-best-practices
        /// </summary>
        public string APIKey { get; set; }

        /// <summary>
        /// Your application's API key for access Google Maps endpoints. If this is not set, the system fails over to using the general APIKey value;
        /// This key identifies your application for purposes of quota management and so that Places added from your application are made immediately available to your app.
        /// Visit the APIs Console to create an API Project and obtain your key.
        /// https://developers.google.com/maps/api-key-best-practices
        /// </summary>
        public string MapsApiKey { get; set; }

        /// <summary>
        /// Your application's API key for access Google Places endpoints. If this is not set, the system fails over to using the general APIKey value;
        /// This key identifies your application for purposes of quota management and so that Places added from your application are made immediately available to your app.
        /// Visit the APIs Console to create an API Project and obtain your key.
        /// https://developers.google.com/maps/api-key-best-practices
        /// </summary>
        public string PlacesApiKey { get; set; }

        /// <summary>
        /// Your application's API key for access Google Search endpoints. If this is not set, the system fails over to using the general APIKey value;
        /// This key identifies your application for purposes of quota management and so that Places added from your application are made immediately available to your app.
        /// Visit the APIs Console to create an API Project and obtain your key.
        /// https://developers.google.com/maps/api-key-best-practices
        /// </summary>
        public string SearchApiKey { get; set; }

        /// <summary>
        /// Your application's API key for access Google Translate endpoints. If this is not set, the system fails over to using the general APIKey value;
        /// This key identifies your application for purposes of quota management and so that Places added from your application are made immediately available to your app.
        /// Visit the APIs Console to create an API Project and obtain your key.
        /// https://developers.google.com/maps/api-key-best-practices
        /// </summary>
        public string TranslateApiKey { get; set; }


        /// <summary>
        /// The client ID provided to you by Google Enterprise Support, or null to disable URL signing.
        /// All client IDs begin with a "gme-" prefix.
        /// </summary>
        public string ClientId { get; set; } = null;

        /// <summary>
        /// Require granular permissions to be granted in order to use the API, as opposed to only requiring authentication. Defaults to false.
        /// </summary>
        public bool RequireGranularPermissions { get; set; } = false;

        /// <summary>
        /// Require calls to the API to come from authenticated users onle. Defaults to true;
        /// </summary>
        public bool RequireAuthentication { get; set; } = true;

        // Summary:
        //     Required for google search requests.
        //     Search engine created for a site with the Google Control Panel To create
        //     a Google Custom Search engine that searches the entire web: 1. From the Google
        //     Custom Search homepage (http://www.google.com/cse), click Create a Custom Search
        //     Engine. 2. Type a name and description for your search engine. 3. Under Define
        //     your search engine, in the Sites to Search box, enter at least one valid URL
        //     (For now, just put www.anyurl.com to get past this screen.More on this later).
        //     4. Select the CSE edition you want and accept the Terms of Service, then click
        //     Next.Select the layout option you want, and then click Next. 5. Click any of
        //     the links under the Next steps section to navigate to your Control panel. 6.
        //     In the left-hand menu, under Control Panel, click Basics. 7. In the Search Preferences
        //     section, select Search the entire web but emphasize included sites. 8. Click
        //     Save Changes. 9. In the left-hand menu, under Control Panel, click Sites. 10.
        //     Delete the site you entered during the initial setup process. 11. Now your custom
        //     search engine will search the entire web.
        public string SearchEngineId { get; set; } = null;

        /// <summary>
        /// Google APIs have some premium endpoints that are not available for trial use. Set this to false 
        /// in order to avoid exceptions caused by triggering a premium endpoint while usiong a trial license.
        /// </summary>
        public bool IncludePremiumEndpoints { get; set; } = true;
    }
}
