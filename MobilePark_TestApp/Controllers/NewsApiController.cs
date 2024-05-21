using Microsoft.AspNetCore.Mvc;
using MobilePark_TestApp.Application;
using MobilePark_TestApp.Enums;
using MobilePark_TestApp.Infrastructure;
using MobilePark_TestApp.Interfaces;
using MobilePark_TestApp.Models;

namespace MobilePark_TestApp.Controllers
{
    /// <summary>
    /// News Api Controller
    /// </summary>
    /// <param name="newsApiClient"></param>
    /// <param name="logger"></param>
    [ApiController]
    [Route("[controller]")]
    public class NewsApiController(
        INewsApiClient newsApiClient,
        VowelCountService vowelCountService,
        NewsApiDbContext dbContext,
        ILogger<NewsApiController> logger) : ControllerBase
    {
        /// <summary>
        /// Result Logger
        /// </summary>
        private readonly ILogger<NewsApiController> _logger = logger;

        /// <summary>
        /// News Api Service
        /// </summary>
        private readonly INewsApiClient _newsApiClient = newsApiClient;
        private readonly VowelCountService _vowelCountService = vowelCountService;

        /// <summary>
        /// Get Articles and Count of Vowels in selected Section
        /// </summary>
        /// <returns>List of Articles and Count of Vowels in selected Section</returns>
        [HttpGet]
        public async Task<IEnumerable<ArticleWithVowelsCount>> Get(string keyword, SearchIn searchIn, Language language)
        {
            try
            {
                ArticleParameters parameters = new()
                {
                    Keyword = keyword,
                    SearchIn = searchIn,
                    Language = language
                };

                ICollection<Article> articles = await _newsApiClient.GetNews(parameters);

                var articlesWithVowelsCount = _vowelCountService
                    .CountVowelsInNews(articles, searchIn)
                    .OrderByDescending(article => article.VowelsCount)
                    .ToArray();

                dbContext.Results.Add(
                    new ParametersAndResult()
                    {
                        Keyword = keyword,
                        SearchIn = searchIn,
                        Language = language,
                        Result = articlesWithVowelsCount
                    });

                dbContext.SaveChanges();

                return articlesWithVowelsCount;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Произошла ошибка при получении списка новостей.");

                return [];
            }
        }
    }
}
