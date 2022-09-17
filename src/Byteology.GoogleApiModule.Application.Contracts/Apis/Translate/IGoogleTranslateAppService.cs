using GoogleApi.Entities.Translate.Translate.Response;
using GoogleApi.Entities.Translate.Detect.Response;
using GoogleApi.Entities.Translate.Languages.Response;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Byteology.GoogleApiModule.Apis.Translate.Inputs;

namespace Byteology.GoogleApiModule.Apis.Translate
{
    public interface IGoogleTranslateAppService: IApplicationService
    {
        Task<TranslateResponse> TranslateAsync(GoogleTranslateInput input);
        Task<LanguagesResponse> LanguagesAsync(GoogleTranslateLanguagesInput input);
        Task<DetectResponse> DetectAsync(GoogleTranslateDetectInput input);
    }
}
