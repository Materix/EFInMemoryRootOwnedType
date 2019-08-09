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

        protected bool Equals(TransliteratedString other)
        {
            return string.Equals(Value, other.Value) &&
                   string.Equals(OriginalValue, other.OriginalValue) &&
                   (string.IsNullOrEmpty(OriginalValue) || string.Equals(Language, other.Language));
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;

            return Equals((TransliteratedString)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Value != null ? Value.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (OriginalValue != null ? OriginalValue.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Language != null ? Language.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(TransliteratedString value, TransliteratedString other)
        {
            if (ReferenceEquals(value, other))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (value is null || other is null)
            {
                return false;
            }

            return string.Equals(value.Value, other.Value) &&
                   string.Equals(value.OriginalValue, other.OriginalValue) &&
                   (string.IsNullOrEmpty(value.OriginalValue) || string.Equals(value.Language, other.Language));
        }

        public static bool operator !=(TransliteratedString value, TransliteratedString other)
        {
            if (ReferenceEquals(value, other))
            {
                return false;
            }

            // If one is null, but not both, return false.
            if (value is null || other is null)
            {
                return true;
            }

            return !string.Equals(value.Value, other.Value) ||
                   !string.Equals(value.OriginalValue, other.OriginalValue) ||
                   !string.IsNullOrEmpty(value.OriginalValue) && !string.Equals(value.Language, other.Language);
        }

        public static bool IsNullOrEmpty(TransliteratedString value)
        {
            return value == null ||
                   string.IsNullOrEmpty(value.Value) &&
                   string.IsNullOrEmpty(value.OriginalValue);
        }
    }
}
