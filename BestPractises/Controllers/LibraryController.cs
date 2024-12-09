using BestPractises.Interfaces;
using BestPractises.Models;
using BestPractises.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Text.Json;

namespace BestPractises.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private ILibraryService _libraryService;
        private readonly IRedisCacheService _redisCacheService;

        public LibraryController(ILibraryService libraryService,IRedisCacheService redisCacheService)
        {
            _libraryService = libraryService;
            _redisCacheService = redisCacheService;


        }

        [HttpGet("books")]
        public IActionResult Get(int pageNum = 1, int pageSize = 10)
        {
            var pagedBooks = _libraryService.GetBooks(pageNum, pageSize);

            return Ok(pagedBooks);
        }
        
        [HttpGet("articles")]
        public async Task <IActionResult> Get()
        {
            string key = "articles";
            var cacheArticles = await _redisCacheService.GetValueAsync(key);
            if (cacheArticles != null)
            {
                var articlesFromCache = JsonConvert.SerializeObject(cacheArticles,Formatting.None);

                return Ok(cacheArticles);
            }

            var articles =_libraryService.GetArticles();
            if (articles == null)
            {
                var result = ServiceResult<Article>.Fail(
                    null,
                    404,
                    "Not Found"
                    );
            }

            var redisArticles = JsonConvert.SerializeObject(articles, Formatting.None);
            await _redisCacheService.SetValueAsync(key, redisArticles);

            return Ok(articles);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetBooksById(int id)
        {
            var book = _libraryService.GetBooks().FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                var result = ServiceResult<Book>.ErrorNotfoundWithId(
                    id.ToString(),
                    404,
                    "Not Found"
                );
                return BadRequest(result.ProblemDetails);
            }

            

            return Ok(book);
        }


        [HttpPost("{stock:int}")]
        public IActionResult Create(int stock)
        {
            if (stock > 20)
            {
                var result = ServiceResult<Book>.ErrorPostBook(
                    400,
                    "stock Error"
                    );
                return BadRequest(result.ProblemDetails);
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update() {
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete() {
            return Ok();
        }

        [HttpPatch("type/{type}")]
        public IActionResult Book(string type) {
            return Ok();
        }
    }
}
