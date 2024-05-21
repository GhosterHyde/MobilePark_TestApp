using MobilePark_TestApp.Enums;

namespace MobilePark_TestApp.Converters
{
    /// <summary>
    /// SearchIn to String converter class
    /// </summary>
    public static class SearchInToStringConverter
    {
        /// <summary>
        /// Convert Enum SearchIn value to String
        /// </summary>
        public static string Convert(SearchIn searchIn) =>
            searchIn.ToString();
    }
}
