using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreWebAPI.Models;

namespace AspNetCoreWebAPI.Services
{
    public class NewsService
    {

        public NewsService()
        {

        }
        public async Task<TopHeadlines> GetArticles()
        {
            var apiGoogle = new ApiAccessGoogleNews();
            var topHeadlines = await apiGoogle.GetArticlesTopHeadlines("br");
            return topHeadlines;
        }

    }
}