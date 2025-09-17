using ShortenerApi.Domain.Entities;

namespace ShortenerApi.Application.Interfaces
{
    public interface IShortenerService
    {
        Task<ShortUrl> ShortenUrl(string originalUrl);
        Task<string> RedirectToOriginal(string shortCode);
    }
}