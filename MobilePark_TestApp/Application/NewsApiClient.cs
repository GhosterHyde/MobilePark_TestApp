using Microsoft.AspNetCore.WebUtilities;
using MobilePark_TestApp.Converters;
using MobilePark_TestApp.Interfaces;
using MobilePark_TestApp.Models;
using Newtonsoft.Json;

namespace MobilePark_TestApp.Application
{
    /// <summary>
    /// News Api Service
    /// </summary>
    /// <param name="client">Http Client for connection</param>
    public partial class NewsApiClient(HttpClient client) : INewsApiClient
    {
        /// <summary>
        /// Http Client for connection
        /// </summary>
        private readonly HttpClient _client = client;

        /// <inheritdoc/>
        public async Task<ICollection<Article>> GetNews(ArticleParameters parameters)
        {
            string? content = await GetContentFromSite(parameters);

            var desiralizedContent = JsonConvert.DeserializeObject<Response>(content);

            return desiralizedContent?.Articles ?? [];
        }

        /// <summary>
        /// Get JSON of all searched Articles from WEB-site NewsApi.org
        /// </summary>
        /// <param name="parameters">Filter Parameters</param>
        /// <returns>JSON of all searched Articles</returns>
        private async Task<string> GetContentFromSite(ArticleParameters parameters)
        {
            var searchSection = SearchInToStringConverter.Convert(parameters.SearchIn);
            var languageString = LanguageToStringConverter.Convert(parameters.Language);

            var queryParameters = new Dictionary<string, string>
            {
                { "q", parameters.Keyword },
                { "searchIn", searchSection },
                { "language", languageString }
            };

            var fullUrl = QueryHelpers.AddQueryString("everything", queryParameters!);
            var response = await _client.GetAsync(fullUrl);

            var content = await response.Content.ReadAsStringAsync();

            return content;
        }
    }
}
