using Atomiv.Core.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Atomiv.Template.Core.Domain.Customers
{
    public class CustomerReferenceNumber
    {
        public const char Code = 'C';

        private const string Separator = "-";
        private const string TimestampFormat = "yyyyMMddHHmm";
        private static readonly IFormatProvider TimestampFormatProvider = CultureInfo.InvariantCulture;
        private const DateTimeStyles TimestampDateTimeStyles = DateTimeStyles.None;

        private const int CodeIndex = 0;
        private const int TimestampIndex = 1;
        private const int AlphaNumericIndex = 2;

        private const int NumberSegments = 3;

        private const int AlphaNumericLength = 5;

        private const string AlphaNumericFormat = "^[A-Z0-9]*$";

        private CustomerReferenceNumber(DateTime timestamp, string alphaNumeric, bool skipValidation)
        {
            if(!skipValidation)
            {
                if(!IsValidTimestamp(timestamp))
                {
                    throw new DomainException($"Invalid timestamp segment: {timestamp}");
                }

                if(!IsValidAlphanumeric(alphaNumeric))
                {
                    throw new DomainException($"Invalid alphanumeric segment: {alphaNumeric}");
                }
            }

            Timestamp = timestamp;
            AlphaNumeric = alphaNumeric;
        }

        public CustomerReferenceNumber(DateTime timestamp, string alphaNumeric)
            : this(timestamp, alphaNumeric, false) { }

        public DateTime Timestamp { get; }

        public string AlphaNumeric { get; }

        public override string ToString()
        {
            var timestampStr = Timestamp.ToString(TimestampFormat, TimestampFormatProvider);

            return $"{Code}{Separator}{timestampStr}{Separator}{AlphaNumeric}";
        }

        public static CustomerReferenceNumber Parse(string value)
        {
            var canParse = TryParse(value, out CustomerReferenceNumber result);

            if(!canParse)
            {
                throw new DomainException($"{value} is not valid");
            }

            return result;
        }

        public static bool TryParse(string value, out CustomerReferenceNumber result)
        {
            var segments = value
                .Split(Separator);

            if (segments.Length != NumberSegments)
            {
                result = null;
                return false;
            }

            var codeValue = segments[CodeIndex];
            var timestampValue = segments[TimestampIndex];
            var alphaNumeric = segments[AlphaNumericIndex];

            if (!TryParseCode(codeValue, out char code)
                || !TryParseTimestamp(timestampValue, out DateTime timestamp))
            {
                result = null;
                return false;
            }

            if (!IsValidCode(code)
                || !IsValidTimestamp(timestamp)
                || !IsValidAlphanumeric(alphaNumeric))
            {
                result = null;
                return false;
            }

            result = new CustomerReferenceNumber(timestamp, alphaNumeric);
            return true;
        }

        private static bool TryParseCode(string value, out char result)
        {
            return char.TryParse(value, out result);
        }

        private static bool TryParseTimestamp(string value, out DateTime result)
        {
            return DateTime.TryParseExact(value, 
                TimestampFormat, 
                TimestampFormatProvider, 
                TimestampDateTimeStyles, 
                out result);
        }

        private static bool IsValidCode(char value)
        {
            return value == Code;
        }

        private static bool IsValidTimestamp(DateTime value)
        {
            return value != DateTime.MinValue;
        }

        private static bool IsValidAlphanumeric(string value)
        {
            return value != null
                && value.Length == AlphaNumericLength
                && Regex.IsMatch(value, AlphaNumericFormat);
        }

    }
}
