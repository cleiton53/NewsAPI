using System.Threading.Tasks;
using AspNetCoreWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebAPI.Controllers
{

    [Route("api/news")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        NewsService _newsService;
        public NewsController(NewsService newsService)
        {
            this._newsService = newsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await this._newsService.GetArticles());
        }
    }
}