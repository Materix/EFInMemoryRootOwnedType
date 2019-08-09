using System;
using System.Collections.Generic;
using System.Text;

namespace EFInMemoryRootOwnedType.Model
{
    public class TransliteratedString
    {
        public TransliteratedString() { }

        public TransliteratedString(string value, string originalValue = null, string language = null)
        {
            Value = value;
            OriginalValue = originalValue;
            Language = language;
        }

        public string Value { get; set; }

        public string OriginalValue { get; set; }

        public string Language { get; set; }
    }
}
