using System.Threading.Tasks;
using ShortenerApi.Domain.Entities;

namespace ShortenerApi.Domain.Interfaces
{
    public interface IShortUrlRepository
    {
        Task<ShortUrl> GetByShortCodeAsync(string shortCode);
        Task<ShortUrl> GetByOriginalUrlAsync(string originalUrl);
        Task AddAsync(ShortUrl shortUrl);
        Task<bool> ShortCodeExistsAsync(string shortCode);
    }
}