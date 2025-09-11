using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShortenerApi.Domain.Entities;
using ShortenerApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using ShortenerApi.Infrastructure.Data;

namespace ShortenerApi.Infrastructure.Services
{
    public class ShortUrlRepository : IShortUrlRepository
    {
        private readonly AppDbContext _context;

        public ShortUrlRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ShortUrl> GetByShortCodeAsync(string shortCode)
        {
            return await _context.ShortUrls
                .FirstOrDefaultAsync(s => s.ShortCode == shortCode);
        }

        public async Task<ShortUrl> GetByOriginalUrlAsync(string originalUrl)
        {
            return await _context.ShortUrls
                .FirstOrDefaultAsync(s => s.OriginalUrl == originalUrl);
        }

        public async Task<IEnumerable<ShortUrl>> GetAllAsync()
        {
            return await _context.ShortUrls.ToListAsync();
        }

        public async Task AddAsync(ShortUrl shortUrl)
        {
            await _context.ShortUrls.AddAsync(shortUrl);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ShortUrl shortUrl)
        {
            _context.ShortUrls.Update(shortUrl);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.ShortUrls.FindAsync(id);
            if (entity != null)
            {
                _context.ShortUrls.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ShortCodeExistsAsync(string shortCode)
        {
            return await _context.ShortUrls.AnyAsync(s => s.ShortCode == shortCode);
        }
    }
}