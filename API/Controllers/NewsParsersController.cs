using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api")]
    [ApiController]
    public class NewsParsersController : ControllerBase
    {
        private readonly INewsParserConfigsService _parsersConfigsService;
        private readonly INewsParsersService _parsersService;
        private readonly INewsService _newsService;

        public NewsParsersController(INewsParserConfigsService parsersConfigsService, INewsParsersService parsersService, INewsService newsService)
        {
            _parsersConfigsService = parsersConfigsService;
            _parsersService = parsersService;
            _newsService = newsService;
        }

        [HttpPost("ParseNews")]
        public async Task<IActionResult> ParseByConfigurationAsync([Required] int id)
        {
            var parserConfig = await _parsersConfigsService.GetNewsParserConfigByIdAsync(id);

            if (parserConfig is null)
                return BadRequest("Parsing configuration with this id does not exist");

            var parsedNewsList = await _parsersService.ParseByConfigurationAsync(parserConfig);

            await _newsService.AddNewsListAsync(parsedNewsList);

            return Ok(parsedNewsList);

        }
    }
}
