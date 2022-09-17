using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Microsoft.Extensions.Options;
using GoogleApi.Entities.Translate.Detect.Response;
using GoogleApi.Entities.Translate.Translate.Response;
using Byteology.GoogleApiModule.Options;

namespace Byteology.GoogleApiModule.Apis.Translate
{
    public class GoogleTranslateAppService_Tests : GoogleApiModuleApplicationTestBase
    {
        private readonly IGoogleTranslateAppService googleTranslateAppService;
        private readonly IOptions<GoogleApiModuleOptions> options;

        public GoogleTranslateAppService_Tests()
        {
            this.options = GetRequiredService<IOptions<GoogleApiModuleOptions>>();
            this.googleTranslateAppService = GetRequiredService <IGoogleTranslateAppService>();
        }

        [Fact]
        public async Task Should_Detect_Languages()
        {
            //Act
            var results = await googleTranslateAppService.DetectAsync(new Inputs.GoogleTranslateDetectInput
            {
                Qs = new List<string>
                {
                    "The quick brown fox jumps over the lazy dog",
                    "La Verdad Adelgaza, pero No Quiebra",
                    "Il ne faut rien laisser au hasard."
                }
            });

            //Assert
            results.Status.ShouldBe(GoogleApi.Entities.Common.Enums.Status.Ok);
            results.ErrorMessage.ShouldBeNull();
            results.Data.Detections.Count().ShouldBe(3);
            (results.Data.Detections.ToList()[0][0] as Detection).Language.ShouldBe(GoogleApi.Entities.Translate.Common.Enums.Language.English);
            (results.Data.Detections.ToList()[1][0] as Detection).Language.ShouldBe(GoogleApi.Entities.Translate.Common.Enums.Language.Spanish);
            (results.Data.Detections.ToList()[2][0] as Detection).Language.ShouldBe(GoogleApi.Entities.Translate.Common.Enums.Language.French);

        }

        [Fact]
        public async Task Should_Get_Language_List()
        {
            //Act
            var results = await googleTranslateAppService.LanguagesAsync(new Inputs.GoogleTranslateLanguagesInput
            {
                //Target = GoogleApi.Entities.Translate.Common.Enums.Language.English
            });

            //Assert
            results.Status.ShouldBe(GoogleApi.Entities.Common.Enums.Status.Ok);
            results.ErrorMessage.ShouldBeNull();
            results.Data.Languages.Count().ShouldBeGreaterThan(1);
        }

        [Fact]
        public async Task Should_Translate()
        {
            //Act
            var results = await googleTranslateAppService.TranslateAsync(new Inputs.GoogleTranslateInput
            {
                Source = GoogleApi.Entities.Translate.Common.Enums.Language.English,
                Target = GoogleApi.Entities.Translate.Common.Enums.Language.Russian,
                Qs = new List<string>
                {
                    "My favorite word in Russian is Bicycle."
                }
            });

            //Assert
            results.Status.ShouldBe(GoogleApi.Entities.Common.Enums.Status.Ok);
            results.ErrorMessage.ShouldBeNull();
            results.Data.Translations.Count().ShouldBe(1);
            (results.Data.Translations.ToList()[0] as Translation).TranslatedText.ShouldNotBeNullOrEmpty();
        }
    }
}
