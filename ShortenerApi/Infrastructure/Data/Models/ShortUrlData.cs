using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShortenerApi.Infrastructure.Data.Models
{
    [Table("ShortUrls")]
    public class ShortUrlData
    {
        [Key]
        public Guid Id { get; set; }
        [Required, MaxLength(2048)]
        public string OriginalUrl { get; set; }
        [Required, MaxLength(20)]
        public string ShortCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int VisitCount { get; set; }
    }
}