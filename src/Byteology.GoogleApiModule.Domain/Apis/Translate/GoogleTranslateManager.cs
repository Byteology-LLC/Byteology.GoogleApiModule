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
using Volo.Abp.Users;
using Volo.Abp.ObjectMapping;

namespace Byteology.GoogleApiModule.Apis.Translate
{
    public class GoogleTranslateManager : ApiManagerBase
    {
        public GoogleTranslateManager(IOptions<GoogleApiModuleOptions> options, IStringLocalizer<GoogleApiModuleResource> localizer, 
            IServiceProvider serviceProvider, ICurrentUser currentUser, IObjectMapper objectMapper) 
            : base(options, localizer, serviceProvider, currentUser, objectMapper, EndPointType.Translate)
        {
        }

        public async Task<DetectResponse> DetectAsync(GoogleTranslateDetectInput input)
        {
            var _detectApi = new GoogleTranslate.DetectApi();


            var request = ObjectMapper.Map<GoogleTranslateDetectInput, DetectRequest>(input);
            request.Key = Options.APIKey;

            var response = await _detectApi.QueryAsync(request);

            CheckResponse(response);

            return response;
        }

        public async Task<LanguagesResponse> LanguagesAsync(GoogleTranslateLanguagesInput input)
        {
            var _languagesApi = new GoogleTranslate.LanguagesApi();


            var request = ObjectMapper.Map<GoogleTranslateLanguagesInput, LanguagesRequest>(input);
            request.Key = Options.APIKey;

            var response = await _languagesApi.QueryAsync(request);

            CheckResponse(response);

            return response;
        }

        public async Task<TranslateResponse> TranslateAsync(GoogleTranslateInput input)
        {
            var _translateApi = new GoogleTranslate.TranslateApi();


            var request = ObjectMapper.Map<GoogleTranslateInput, TranslateRequest>(input);
            request.Key = Options.APIKey;

            var response = await _translateApi.QueryAsync(request);

            CheckResponse(response);

            return response;
        }
    }
}
