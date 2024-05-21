using MobilePark_TestApp.Enums;

namespace MobilePark_TestApp.Models
{
    /// <summary>
    /// Filter Parameters for Articles
    /// </summary>
    public class ArticleParameters
    {
        public string Keyword { get; set; }
        public SearchIn SearchIn { get; set; }
        public Language Language { get; set; }
    }
}
