using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Text.Json.Serialization;
using TicketMaster.Application.DTOs;
using TicketMaster.Application.Repositories;
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

        public async Task<MovieWithTheatersDto> GetMovieByMovieAndDate(int idMovie, DateTime date)
        {
            string cacheKey = $"MovieSessions_{idMovie}_{date:yyyyMMdd}";

            var cachedSessions = await _cache.GetStringAsync(cacheKey);
            if (!string.IsNullOrEmpty(cachedSessions))
            {
                return JsonSerializer.Deserialize<MovieWithTheatersDto>(cachedSessions);
            }

            var result = new MovieWithTheatersDto();
            var movieSessions = await _repository.GetAllByMovieAndDate(idMovie, date);
            if(movieSessions == null || movieSessions.Count == 0)
            {
                return result;
            }

            result.FromMovieSessions(movieSessions);
            SetCache(cacheKey, result);

            return result;
        }

        private void SetCache(string cacheKey, object movieSessions)
        {
            DateTime now = DateTime.Now;
            DateTime midnight = now.Date.AddDays(1); // 00:00 de amanhã (meia-noite de hoje)

            var options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = midnight
            };

            _cache.SetString(cacheKey, JsonSerializer.Serialize(movieSessions), options);
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
