using Byteology.GoogleApiModule.Enums;
using Byteology.GoogleApiModule.Localization;
using Byteology.GoogleApiModule.Options;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using GoogleApi;
using GoogleApi.Entities.Translate.Detect.Request;
using GoogleApi.Entities.Translate.Detect.Response;
using GoogleApi.Entities.Translate.Languages.Request;
using GoogleApi.Entities.Translate.Languages.Response;
using GoogleApi.Entities.Translate.Translate.Request;
using GoogleApi.Entities.Translate.Translate.Response;
using System;
using System.Threading.Tasks;
using Byteology.GoogleApiModule.Apis.Translate.Inputs;
using Byteology.GoogleApiModule.Permissions;

namespace Byteology.GoogleApiModule.Apis.Translate
{
    public class GoogleTranslateAppService : ApiBaseAppService, IGoogleTranslateAppService
    {
        private readonly GoogleTranslateManager Manager;
        public GoogleTranslateAppService(IOptions<GoogleApiModuleOptions> options, IStringLocalizer<GoogleApiModuleResource> localizer, 
            IServiceProvider serviceProvider, GoogleTranslateManager manager) : base(options, localizer, serviceProvider, EndPointType.Translate)
        {
            Manager = manager;
        }

        public async Task<DetectResponse> DetectAsync(GoogleTranslateDetectInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Translate.Detect);

            return await Manager.DetectAsync(input);
        }

        public async Task<LanguagesResponse> LanguagesAsync(GoogleTranslateLanguagesInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Translate.Languages);

            return await Manager.LanguagesAsync(input);
        }

        public async Task<TranslateResponse> TranslateAsync(GoogleTranslateInput input)
        {
            await CheckAuthorizationAsync(GoogleApiModulePermissions.Translate.Default);

            return await Manager.TranslateAsync(input);
        }
    }
}
