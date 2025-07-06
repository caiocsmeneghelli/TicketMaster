using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Text.Json.Serialization;
using TicketMaster.Domain.Entities;
using TicketMaster.Domain.Repositories;

namespace TicketMaster.Infrastructure.Persistence.Caching.Repositories
{
    public class CachedMovieSessionRepository : ICachedMovieSessionRepository
    {
        private readonly IMovieSessionRepository _repository;
        private readonly IDistributedCache _cache;

        public CachedMovieSessionRepository(IMovieSessionRepository repository, IDistributedCache cache)
        {
            _repository = repository;
            _cache = cache;
        }

        public async Task<List<MovieSession>> GetMovieByMovieAndDate(int idMovie, DateTime date)
        {
            string cacheKey = $"MovieSessions_{idMovie}_{date:yyyyMMdd}";

            var cachedSessions = await _cache.GetStringAsync(cacheKey);
            if (!string.IsNullOrEmpty(cachedSessions))
            {
                var serializeOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    ReferenceHandler = ReferenceHandler.Preserve,
                    WriteIndented = true // opcional, para facilitar a leitura do JSON
                };
                return JsonSerializer.Deserialize<List<MovieSession>>(cachedSessions, serializeOptions);
            }

            var movieSessions = await _repository.GetAllByMovieAndDate(idMovie, date);
            SetCache(cacheKey, movieSessions);

            return movieSessions;
        }

        private void SetCache(string cacheKey, List<MovieSession> movieSessions)
        {
            DateTime now = DateTime.Now;
            DateTime midnight = now.Date.AddDays(1); // 00:00 de amanhã (meia-noite de hoje)

            var options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = midnight
            };

            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true // opcional, para facilitar a leitura do JSON
            };

            _cache.SetString(cacheKey, JsonSerializer.Serialize(movieSessions, serializeOptions), options);
        }

        public async void ClearCacheByMovie(int idMovie)
        {
            // busca todos os moviesSessions ativos por filme
            var movieSessions = await _repository.GetAllAvailableByMovieAsync(idMovie);

            // faz uma lista de datas
            var dates = movieSessions.Select(ms => ms.SessionTime.Date).Distinct().ToList();

            // remove o cache para cada data
            foreach (var date in dates)
            {
                string cacheKey = $"MovieSessions_{idMovie}_{date:yyyyMMdd}";
                await _cache.RemoveAsync(cacheKey);
            }
        }
    }
}
