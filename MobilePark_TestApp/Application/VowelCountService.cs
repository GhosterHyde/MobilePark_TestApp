using MobilePark_TestApp.Enums;
using MobilePark_TestApp.Models;
using System.Text.RegularExpressions;

namespace MobilePark_TestApp.Application
{
    public class VowelCountService
    {
        /// <summary>
        /// Symbol in content that starts hidden part of article
        /// </summary>
        private const char contentMoreCharsStartSymbol = '[';

        /// <summary>
        /// Regular Expression Pattern to find Vowels
        /// </summary>
        private static readonly string vowelsPattern = "(?i:[aeiouyаеёиоуыэюя])";

        /// <summary>
        /// Vowel Search Regular Expression
        /// </summary>
        private readonly Regex vowelsRegex = new(vowelsPattern);

        /// <summary>
        /// Count Vowels in Article Search Field
        /// </summary>
        /// <param name="articles">List of Articles</param>
        /// <param name="searchIn">Field Where to find Keyword</param>
        /// <returns></returns>
        public IEnumerable<ArticleWithVowelsCount> CountVowelsInNews(ICollection<Article> articles, SearchIn searchIn)
        {
            List<ArticleWithVowelsCount> result = [];

            for (int i = 0; i < articles.Count; i++)
            {
                var article = articles.ElementAt(i);

                var searchField = GetSearchField(article, searchIn);

                var vowelsCount = vowelsRegex.Matches(searchField).Count;

                result.Add(new ArticleWithVowelsCount()
                {
                    Title = article.Title,
                    Description = article.Description,
                    Content = article.Content,
                    VowelsCount = vowelsCount
                });
            }

            return result;
        }

        /// <summary>
        /// Get Text of Searched Field
        /// </summary>
        /// <param name="article">Article</param>
        /// <param name="searchIn">Field Where to find Keyword</param>
        /// <returns>Text of Searched Field</returns>
        private static string GetSearchField(Article article, SearchIn searchIn)
        {
            string searchField = GetField(article, searchIn);

            string result = ParseSearchField(article, searchField);

            return result;
        }

        /// <summary>
        /// Get Article Searched Field Text
        /// </summary>
        /// <param name="article">Article</param>
        /// <param name="searchIn">Searched Field</param>
        /// <returns>Article Searched Field Text</returns>
        /// <exception cref="NotImplementedException">Not Implemented Searched Field</exception>
        private static string GetField(Article article, SearchIn searchIn) =>
            searchIn switch
            {
                SearchIn.title => article.Title,
                SearchIn.description => article.Description,
                SearchIn.content => article.Content,
                _ => throw new NotImplementedException()
            };

        /// <summary>
        /// Parse Text of Article Searched Field
        /// </summary>
        /// <param name="article">Article</param>
        /// <param name="searchField">Searched Field</param>
        /// <returns>Parsed Text of Article Searched Field</returns>
        private static string ParseSearchField(Article article, string searchField)
        {
            if (searchField.Contains(contentMoreCharsStartSymbol))
            {
                return searchField.LastIndexOf(contentMoreCharsStartSymbol) != 0
                    ? searchField[..article.Content.LastIndexOf(contentMoreCharsStartSymbol)]
                    : string.Empty;
            }

            return searchField;
        }
    }
}
