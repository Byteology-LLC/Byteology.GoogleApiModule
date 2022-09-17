using System;
using System.Collections.Generic;
using System.Text;
using GoogleApi.Entities.Translate.Common.Enums;
using GoogleApi.Entities.Translate.Translate.Request.Enums;

namespace Byteology.GoogleApiModule.Apis.Translate.Inputs
{
    public class GoogleTranslateInput
    {
        /// <summary>
        /// The language of the source text, set to one of the language codes listed in Language Support.
        /// If the source language is not specified, the API will attempt to detect the source language automatically and
        /// return it within the response.
        /// </summary>
        public Language? Source { get; set; }

        /// <summary>
        /// Required. The language to use for translation of the input text,
        /// set to one of the language codes listed in Language Support.
        /// </summary>
        public Language? Target { get; set; }

        /// <summary>
        /// Required. The input text to translate.
        /// Repeat this parameter to perform translation operations on multiple text inputs.
        /// </summary>
        public IEnumerable<string> Qs { get; set; }

        /// <summary>
        /// The translation model.
        /// Can be either base to use the Phrase-Based Machine Translation (PBMT) model,
        /// or nmt to use the Neural Machine Translation (NMT) model. If omitted, then nmt is used.
        /// If the model is nmt, and the requested language translation pair is not supported for the NMT model,
        /// then the request is translated using the base model.
        /// Languages supported by the NMT model can only be translated to or from English(en).
        /// </summary>
        public Model Model { get; set; } = Model.Base;

        /// <summary>
        /// The format of the source text, in either HTML (default) or plain-text.
        /// A value of html indicates HTML and a value of text indicates plain-text.
        /// Default: format=html.
        /// </summary>
        public Format Format { get; set; } = Format.Html;
    }
}
