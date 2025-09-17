using ShortenerApi.Domain.Entities;
using ShortenerApi.Domain.Interfaces;
using System.Net;
using ShortenerApi.Application.Interfaces;

namespace ShortenerApi.Application.Services
{
    public class ShortenerService : IShortenerService
    {
        private readonly IShortUrlRepository _shortUrlRepository;

        public ShortenerService(IShortUrlRepository shortUrlRepository)
        {
            _shortUrlRepository = shortUrlRepository;
        }

        public async Task<ShortUrl> ShortenUrl(string originalUrl)
        {
            if (string.IsNullOrWhiteSpace(originalUrl))
                throw new ArgumentException("Original URL cannot be empty.");

            var shortCode = WebUtility.UrlEncode(originalUrl);
            var shortUrl = new ShortUrl(originalUrl, shortCode);

            await _shortUrlRepository.AddAsync(shortUrl);

            return new ShortUrl(originalUrl, shortCode);
        }

        public async Task<string> RedirectToOriginal(string shortCode)
        {
            var shortUrl = await _shortUrlRepository.GetByShortCodeAsync(shortCode);
            return shortUrl.OriginalUrl;
        }
    }
}