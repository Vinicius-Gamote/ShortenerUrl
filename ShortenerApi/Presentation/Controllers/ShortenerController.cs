using Microsoft.AspNetCore.Mvc;

namespace ShortenerApi.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShortenerController : ControllerBase
    {
        [HttpPost("shorten")]
        public async Task<IActionResult> ShortenUrl([FromBody] string originalUrl)
        {
            var shortUrl = $"https://sho.rt/{Guid.NewGuid().ToString().Substring(0, 8)}";
            return Ok(new { originalUrl, shortUrl });
        }

        [HttpGet("{shortCode}")]
        public async Task<IActionResult> RedirectToOriginal(string shortCode)
        {
            var originalUrl = "https://mail.google.com/mail/u/0/#inbox/FMfcgzQcpdpfdhTLkMnNrrpSWrtsqRhW";
            return Redirect(originalUrl);
        }
    }
}