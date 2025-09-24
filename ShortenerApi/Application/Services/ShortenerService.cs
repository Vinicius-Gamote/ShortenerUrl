using ShortenerApi.Domain.Entities;
using ShortenerApi.Domain.Interfaces;
using System.Net;
using ShortenerApi.Application.Interfaces;
using NanoidDotNet;

namespace ShortenerApi.Application.Services
{
    public class ShortenerService : IShortenerService
    {
        private readonly IShortUrlRepository _shortUrlRepository;
        private readonly ILogger<ShortenerService> _logger;

        public ShortenerService(IShortUrlRepository shortUrlRepository, ILogger<ShortenerService> logger)
        {
            _shortUrlRepository = shortUrlRepository;
            _logger = logger;
        }

        public async Task<ShortUrl> ShortenUrl(string originalUrl)
        {
            if (string.IsNullOrWhiteSpace(originalUrl))
                throw new ArgumentException("Original URL cannot be empty.");

            var shortCode = Nanoid.Generate(Nanoid.Alphabets.LowercaseLettersAndDigits, 10);
            var shortUrl = new ShortUrl(originalUrl, shortCode);

            await _shortUrlRepository.AddAsync(shortUrl);

            return new ShortUrl(originalUrl, shortCode);
        }

        public async Task<string> RedirectToOriginal(string shortCode)
        {
            var shortUrl = await _shortUrlRepository.GetByShortCodeAsync(shortCode);

            if (!shortUrl.OriginalUrl.StartsWith("http://") && !shortUrl.OriginalUrl.StartsWith("https://"))
            {
                shortUrl.OriginalUrl = "http://" + shortUrl.OriginalUrl;
            }
            _logger.LogInformation("ShortUrl retrieved: {@shortUrl.OriginalUrl}", shortUrl.OriginalUrl);
            return shortUrl.OriginalUrl;
        }
    }
}