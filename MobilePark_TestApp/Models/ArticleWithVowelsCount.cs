namespace MobilePark_TestApp.Models
{
    /// <summary>
    /// Class of Article and Vowels Count in Searched Field
    /// </summary>
    public class ArticleWithVowelsCount
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public int VowelsCount { get; set; } = 0;
    }
}
