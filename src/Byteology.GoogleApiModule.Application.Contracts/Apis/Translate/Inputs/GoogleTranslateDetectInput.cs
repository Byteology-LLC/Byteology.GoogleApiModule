using System;
using System.Collections.Generic;
using System.Text;

namespace Byteology.GoogleApiModule.Apis.Translate.Inputs
{
    public class GoogleTranslateDetectInput
    {
        /// <summary>
        /// Required. The input text upon which to perform language detection.
        /// Repeat this parameter to perform language detection on multiple text inputs.
        /// </summary>
        public IEnumerable<string> Qs { get; set; }
    }
}
