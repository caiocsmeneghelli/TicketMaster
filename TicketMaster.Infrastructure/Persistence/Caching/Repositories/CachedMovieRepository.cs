using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using TicketMaster.Application.Repositories;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Infrastructure.Persistence.Caching.Repositories
{
    public class CachedMovieRepository : ICachedMovieRepository
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IDistributedCache _cache;

        private readonly string _cacheKey = "ActiveMovies";

        public CachedMovieRepository(IMovieRepository movieRepository, IDistributedCache cache)
        {
            _movieRepository = movieRepository;
            _cache = cache;
        }
        public async Task<List<Movie>> GetAllActiveMovies()
        {
            var cachedMovies = await _cache.GetStringAsync(_cacheKey);

            if (!string.IsNullOrEmpty(cachedMovies))
            {
                return JsonSerializer.Deserialize<List<Movie>>(cachedMovies);
            }

            var movies = await _movieRepository.GetAllActiveAsync(null);
            SetCache(movies);

            return movies;
        }

        public async Task RefreshActiveMovies()
        {
            // remove lista atual
            ClearCache();

            // buscar lista atualizada
            var movies = await _movieRepository.GetAllActiveAsync(null);

            // atualizar cache
            SetCache(movies);
        }

        private void SetCache(List<Movie> movies)
        {
            DateTime now = DateTime.Now;
            DateTime midnight = now.Date.AddDays(1); // 00:00 de amanhã (meia-noite de hoje)

            var options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = midnight
            };

            _cache.SetString(_cacheKey, JsonSerializer.Serialize(movies), options);
        }

        private void ClearCache()
        {
            _cache.Remove(_cacheKey);
        }
    }
}
