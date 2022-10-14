using System;
using System.Collections.Generic;
using System.Text;
using GoogleApi.Entities.Translate.Common.Enums;

namespace Byteology.GoogleApiModule.Apis.Translate.Inputs
{
    public class GoogleTranslateLanguagesInput
    {
        /// <summary>
        /// The target language code for the results.If specified, then the language names are returned in the name field of the response,
        /// localized in the target language.If you do not supply a target language, then the name field is omitted from the response and only
        /// the language codes are returned.
        /// </summary>
        public Language? Target { get; set; }
    }
}
