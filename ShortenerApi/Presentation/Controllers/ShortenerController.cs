using Microsoft.AspNetCore.Mvc;
using ShortenerApi.Application.Interfaces;

namespace ShortenerApi.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShortenerController : ControllerBase
    {
        private readonly ILogger<ShortenerController> _logger;
        private readonly IShortenerService _shortenerService;
        public ShortenerController(ILogger<ShortenerController> logger, IShortenerService shortenerService)
        {
            _logger = logger;
            _shortenerService = shortenerService;
        }

        [HttpPost("shorten")]
        public async Task<IActionResult> ShortenUrl([FromBody] string originalUrl)
        {
            try
            {
                var shortCode = await _shortenerService.ShortenUrl(originalUrl);
                return Ok($"URL shortened successfully: {shortCode.ShortCode}"); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Shortening URL failed");
                return Ok();
            }
        }

        [HttpGet("/{shortCode}")]
        public async Task<IActionResult> RedirectToOriginal(string shortCode)
        {
            try
            {
                var shortUrl = await _shortenerService.RedirectToOriginal(shortCode);
                return Redirect(shortUrl); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Cannot find original URL to redirect");
                return Ok();
            }
        }
    }
}