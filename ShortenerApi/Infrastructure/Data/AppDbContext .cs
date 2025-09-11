using Microsoft.EntityFrameworkCore;
using ShortenerApi.Domain.Entities;

namespace ShortenerApi.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ShortUrl> ShortUrls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ShortUrl>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.OriginalUrl)
                      .IsRequired()
                      .HasMaxLength(2048);
                entity.Property(e => e.ShortCode)
                      .IsRequired()
                      .HasMaxLength(20);
                entity.Property(e => e.CreatedAt)
                      .IsRequired();
            });
        }
    }
}