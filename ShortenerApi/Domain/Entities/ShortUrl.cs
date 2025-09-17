namespace ShortenerApi.Domain.Entities
{
    public class ShortUrl(string originalUrl, string shortCode)
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string OriginalUrl { get; set; } = originalUrl;
        public string ShortCode { get; set; } = shortCode;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ExpiryDate { get; set; }
        public int VisitCount { get; set; } = 0;
    }
}