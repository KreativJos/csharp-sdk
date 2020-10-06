namespace PAYNLSDK.Converters
{
    public class DMYConverter : DateConverter
    {
        private const string _format = "dd-MM-yyyy";
        private static readonly string[] _parseFormats =
        {
            // - argument.
            "d-M-yyyy", "dd-MM-yyyy",
            // Slash argument.
            "d/M/yyyy", "dd/MM/yyyy"
        };

        public DMYConverter()
            : base(_format, _parseFormats)
        { }
    }
}
