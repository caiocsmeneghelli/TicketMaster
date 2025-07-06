using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Infrastructure.Persistence.Repositories
{
    public class CachedMovieRepositoy : ICachedMovieRepository
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IDistributedCache _cache;

        public CachedMovieRepositoy(IMovieRepository movieRepository, IDistributedCache cache)
        {
            _movieRepository = movieRepository;
            _cache = cache;
        }
        public async Task<List<Movie>> GetAllActiveMovies()
        {
            var cacheKey = "ActiveMovies";
            var cachedMovies = await _cache.GetStringAsync(cacheKey);

            if (!string.IsNullOrEmpty(cachedMovies))
            {
                return JsonSerializer.Deserialize<List<Movie>>(cachedMovies);
            }

            var movies = await _movieRepository.GetAllActiveAsync(null);

            DateTime now = DateTime.Now;
            DateTime midnight = now.Date.AddDays(1); // 00:00 de amanhã (meia-noite de hoje)

            var options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = midnight
            };

            await _cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(movies), options);

            return movies;
        }
    }
}
