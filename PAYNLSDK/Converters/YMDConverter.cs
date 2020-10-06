namespace PAYNLSDK.Converters
{
    public class YMDConverter : DateConverter
    {
        private const string _format = "yyyy-MM-dd";
        private static readonly string[] _parseFormats =
        {
            // - argument.
            "yyyy-M-d", "yyyy-MM-dd",
            // Slash argument.
            "yyyy/M/d", "yyyy/MM/dd"
        };

        public YMDConverter()
            : base(_format, _parseFormats)
        { }
    }
}
