using System.Collections.Generic;

namespace AspNetCoreWebAPI.Models
{
    public class TopHeadlines
    {
        public string Status { get; set; }
        public int TotalResults { get; set; }
        public List<Article> Articles { get; set; }
    }
}