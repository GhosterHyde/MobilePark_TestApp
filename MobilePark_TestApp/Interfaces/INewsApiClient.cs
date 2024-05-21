using MobilePark_TestApp.Models;

namespace MobilePark_TestApp.Interfaces
{
    /// <summary>
    /// Interface of News Api Service
    /// </summary>
    public interface INewsApiClient
    {
        /// <summary>
        /// Get List of Articles and Vowels Count in Searched Field
        /// </summary>
        /// <param name="parameters">Filter Parameters</param>
        /// <returns>List of Articles and Vowels Count in Searched Field</returns>
        public Task<ICollection<Article>> GetNews(ArticleParameters parameters);
    }
}
