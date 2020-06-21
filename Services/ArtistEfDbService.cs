using Kolokwium.Dto;
using Kolokwium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Services
{
    public class ArtistEfDbService : IArtistDbService
    {
        private readonly AppDbContext _dbContext;

        public ArtistEfDbService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Artist GetById(int id)
        {
            return _dbContext.Artist
                .Where((a => a.IdArtist == id))
                .Single();
        }

        public IEnumerable<ArtistEvent> GetByArtistId(int id)
        {
            return _dbContext.ArtistEvent
                .Where((ae => ae.IdArtist == id))
                .ToList();
        }

        public void Update(UpdateArtistDto updateArtistDto)
        {
            var artistEvent = _dbContext.ArtistEvent
                .Where((ae => ae.IdArtist == updateArtistDto.IdArtist && ae.IdEvent == updateArtistDto.IdEvent))
                .Single();

            artistEvent.PerformanceDate = updateArtistDto.PerformanceDate;

            _dbContext.SaveChanges();
        }
    }
}
