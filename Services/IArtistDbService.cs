using Kolokwium.Dto;
using Kolokwium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Services
{
    public interface IArtistDbService
    {
        public Artist GetById(int id);

        public IEnumerable<ArtistEvent> GetByArtistId(int id);

        public void Update(UpdateArtistDto updateArtistDto);
    }
}
