using System.ComponentModel.DataAnnotations;

namespace ShortenerApi.Domain.Entities
{
    public class ShortUrl(string originalUrl, string shortCode)
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string OriginalUrl { get; set; } = originalUrl;
        [MaxLength(100)]
        public string ShortCode { get; set; } = shortCode;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ExpiryDate { get; set; } = DateTime.UtcNow.AddMonths(1);
        public int VisitCount { get; set; } = 0;
    }
}