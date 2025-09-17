using ShortenerApi.Domain.Entities;
using ShortenerApi.Infrastructure.Data.Models;

namespace ShortenerApi.Infrastructure.Data.Mappers
{
    public static class ShortUrlMapper
    {
        public static ShortUrlData ToDataModel(ShortUrl entity)
        {
            return new ShortUrlData
            {
                Id = entity.Id,
                OriginalUrl = entity.OriginalUrl,
                ShortCode = entity.ShortCode,
                CreatedAt = entity.CreatedAt,
                ExpiryDate = entity.ExpiryDate
            };
        }

        public static ShortUrl ToEntity(ShortUrlData model)
        {
            return new ShortUrl(model.OriginalUrl, model.ShortCode);
        }
    }
}