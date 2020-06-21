using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium.Dto;
using Kolokwium.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistDbService _artistDbService;

        public ArtistsController(IArtistDbService artistDbService)
        {
            _artistDbService = artistDbService;
        }

        [HttpGet("{id}")]
        public IActionResult Read(int id)
        {
            var artist = _artistDbService.GetById(id);
            var artistEvents = _artistDbService.GetByArtistId(id);

            artistEvents.ToList().ForEach(ae => artist.ArtistEvents.Add(ae));

            return Ok(artist);
        }

        [HttpPut]
        public IActionResult Update(UpdateArtistDto request)
        {
            _artistDbService.Update(request);

            return Ok();
        }
    }
}
