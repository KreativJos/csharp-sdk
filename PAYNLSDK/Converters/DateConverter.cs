using System;
using System.Globalization;

using Newtonsoft.Json;

using PAYNLSDK.Utilities;

namespace PAYNLSDK.Converters
{
    public abstract class DateConverter : JsonConverter
    {
        public string Format { get; protected set; }
        public string[] ParseFormats { get; protected set; }

        protected DateConverter() { }
        protected DateConverter(string format, string[] parseFormats)
        {
            Format = format;
            ParseFormats = parseFormats;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is DateTime dateTime)
            {
                if (dateTime.Kind == DateTimeKind.Unspecified)
                    throw new JsonSerializationException("Cannot convert date time with an unspecified kind");

                var convertedDateTime = dateTime.ToString(Format);

                writer.WriteValue(convertedDateTime);
            }
            else
            {
                throw new JsonSerializationException("Expected value of type 'DateTime'.");
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            if (reader.TokenType == JsonToken.Date)
            {
                var dateTime = (DateTime)reader.Value;

                if (dateTime.Kind == DateTimeKind.Unspecified)
                    throw new JsonSerializationException("Parsed date time is not in the expected RFC3339 format");

                return dateTime;
            }

            if (reader.TokenType == JsonToken.String)
            {
                /*string[] formats = { "yyyy/M/d", "yyyy/MM/dd", "yyyy-M-d", "yyyy-MM-dd" };*/
                var timeString = (string)reader.Value;

                if (!ParameterValidator.IsEmpty(timeString)
                    && DateTime.TryParseExact(timeString, ParseFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime))
                {
                    // Gelukt we kunnen doorgaan
                    return dateTime;
                }

                // De opgegeven timeString is niet juist.
                return null;
            }

            throw new JsonSerializationException(string.Format("Unexpected token '{0}' when parsing date.", reader.TokenType));
        }

        public override bool CanConvert(Type objectType)
        {
            Type t = Reflection.IsNullable(objectType)
               ? Nullable.GetUnderlyingType(objectType)
               : objectType;

            return t == typeof(DateTime);
        }
    }
}