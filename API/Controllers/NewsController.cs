using Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [Authorize]
        [HttpPost("Create")]
        public async Task<IActionResult> AddNews(NewsModel model)
        {
            await _newsService.AddNewsAsync(model.ToDomain());

            return Ok();
        }

        [Authorize]
        [HttpGet("Read")]
        public async Task<IActionResult> GetNewsById([Required] int id)
        {
            var news = await _newsService.GetNewsByIdAsync(id);

            return Ok(news);
        }

        [Authorize]
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateNews([Required] int id, [FromBody] NewsModel model)
        {
            await _newsService.UpdateNewsAsync(id, model.ToDomain());

            return NoContent();
        }

        [Authorize]
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteNewsById([Required] int id)
        {
            await _newsService.DeleteNewsByIdAsync(id);

            return NoContent();
        }

        /// <summary>
        /// /api/posts?from=&to  Вернуть список новостей с фильтром по дате и времени from - to
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        [HttpGet("Posts")]
        public async Task<IActionResult> GetNewsAsync([Required] DateTime from, [Required] DateTime to)
        {

            var newsList = await _newsService.GetNewsListAsync(from, to);

            return Ok(newsList);
        }

        /// <summary>
        /// /api/search?text=asd Вернуть новости в которых встречается текст(Поиск)
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [HttpGet("Search")]
        public async Task<IActionResult> GetNewsAsync([Required] string text)
        {

            var newsList = await _newsService.GetNewsListAsync(text);

            return Ok(newsList);

        }

        /// <summary>
        /// /api/topten/  Вернуть 10 самых часто используемых слов в новостях(тексте новости)
        /// </summary>
        /// <returns></returns>
        [HttpGet("TopTen")]
        public async Task<IActionResult> GetNewsTopWordsAsync()
        {
            int count = 10;

            var newsList = await _newsService.GetNewsTopWordsAsync(count);

            return Ok(newsList);

        }
    }
}
