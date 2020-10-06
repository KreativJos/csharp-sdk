namespace PAYNLSDK.Converters
{
    public class YMDHISConverter : DateConverter
    {
        private const string _format = "yyyy-MM-dd HH:ii:ss";
        private static readonly string[] _parseFormats =
        {
            // - argument.
            "yyyy-M-d h:mm:ss tt", "yyyy-M-d h:mm tt",
            "yyyy-MM-dd hh:mm:ss", "yyyy-M-d h:mm:ss",
            "yyyy-M-d hh:mm tt", "yyyy-M-d hh tt",
            "yyyy-M-d h:mm", "yyyy-M-d h:mm",
            "yyyy-MM-dd hh:mm", "yyyy-M-dd hh:mm",
            // Slash argument.
            "yyyy/M/d h:mm:ss tt", "yyyy/M/d h:mm tt",
            "yyyy/MM/dd hh:mm:ss", "yyyy/M/d h:mm:ss",
            "yyyy/M/d hh:mm tt", "yyyy/M/d hh tt",
            "yyyy/M/d h:mm", "yyyy/M/d h:mm",
            "yyyy/MM/dd hh:mm", "yyyy/M/dd hh:mm"
        };

        public YMDHISConverter()
            : base(_format, _parseFormats)
        { }
    }
}
