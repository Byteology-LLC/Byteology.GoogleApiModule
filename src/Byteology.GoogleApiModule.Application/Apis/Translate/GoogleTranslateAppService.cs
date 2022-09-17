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
        public GoogleTranslateAppService(IOptions<GoogleApiModuleOptions> options, IStringLocalizer<GoogleApiModuleResource> localizer, IServiceProvider serviceProvider) : base(options, localizer, serviceProvider, EndPointType.Translate)
        {
        }

        public async Task<DetectResponse> DetectAsync(GoogleTranslateDetectInput input)
        {
            var _detectApi = new GoogleTranslate.DetectApi();

            await CheckAuthorizationAsync(GoogleApiModulePermissions.Translate.Detect);

            var request = ObjectMapper.Map<GoogleTranslateDetectInput, DetectRequest>(input);
            request.Key = Options.APIKey;

            var response = await _detectApi.QueryAsync(request, GetCancellationToken());

            CheckResponse(response);

            return response;
        }

        public async Task<LanguagesResponse> LanguagesAsync(GoogleTranslateLanguagesInput input)
        {
            var _languagesApi = new GoogleTranslate.LanguagesApi();

            await CheckAuthorizationAsync(GoogleApiModulePermissions.Translate.Languages);

            var request = ObjectMapper.Map<GoogleTranslateLanguagesInput, LanguagesRequest>(input);
            request.Key = Options.APIKey;

            var response = await _languagesApi.QueryAsync(request, GetCancellationToken());

            CheckResponse(response);

            return response;
        }

        public async Task<TranslateResponse> TranslateAsync(GoogleTranslateInput input)
        {
            var _translateApi = new GoogleTranslate.TranslateApi();

            await CheckAuthorizationAsync(GoogleApiModulePermissions.Translate.Default);

            var request = ObjectMapper.Map<GoogleTranslateInput, TranslateRequest>(input);
            request.Key = Options.APIKey;

            var response = await _translateApi.QueryAsync(request, GetCancellationToken());

            CheckResponse(response);

            return response;
        }
    }
}
