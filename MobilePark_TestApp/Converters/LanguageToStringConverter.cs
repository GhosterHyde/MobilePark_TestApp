using MobilePark_TestApp.Enums;

namespace MobilePark_TestApp.Converters
{
    /// <summary>
    /// Language to String converter class
    /// </summary>
    public static class LanguageToStringConverter
    {
        /// <summary>
        /// Convert Enum Language value to String
        /// </summary>
        public static string Convert(Language language) =>
            language.ToString();
    }
}
