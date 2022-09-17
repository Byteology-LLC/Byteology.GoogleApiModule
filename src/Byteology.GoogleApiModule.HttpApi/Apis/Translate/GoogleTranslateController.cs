using Byteology.GoogleApiModule.Apis.Translate.Inputs;
using GoogleApi.Entities.Translate.Detect.Response;
using GoogleApi.Entities.Translate.Languages.Response;
using GoogleApi.Entities.Translate.Translate.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Byteology.GoogleApiModule.Apis.Translate
{
    [RemoteService(Name = "GoogleTranslate")]
    [Area("googleTranslate")]
    [ControllerName("GoogleTranslate")]
    [Route("api/google-apis/google-translate")]
    public class GoogleTranslateController : AbpController, IGoogleTranslateAppService
    {
        private readonly IGoogleTranslateAppService _appService;

        public GoogleTranslateController(IGoogleTranslateAppService appService)
        {
            _appService = appService;
        }

        [HttpPost("detect")]
        public Task<DetectResponse> DetectAsync(GoogleTranslateDetectInput input)
        {
            return _appService.DetectAsync(input);
        }

        [HttpPost("languages")]
        public Task<LanguagesResponse> LanguagesAsync(GoogleTranslateLanguagesInput input)
        {
            return _appService.LanguagesAsync(input);
        }

        [HttpPost("translate")]
        public Task<TranslateResponse> TranslateAsync(GoogleTranslateInput input)
        {
            return _appService.TranslateAsync(input);
        }
    }
}
