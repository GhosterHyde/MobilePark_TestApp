using MobilePark_TestApp.Enums;

namespace MobilePark_TestApp.Models
{
    public class ParametersAndResult
    {        
        public int Id { get; set; }

        public string Keyword { get; set; }
        
        public SearchIn SearchIn { get; set; }
        
        public Language Language { get; set; }
        
        public IEnumerable<ArticleWithVowelsCount> Result { get; set; }
    }
}
