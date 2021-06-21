using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Musicplayer.Data;
using Musicplayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicplayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private ApiDbContext _dbContext;
        public ArtistsController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Artist artist)
        {
            await _dbContext.Artists.AddAsync(artist);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpGet]
        public async Task<IActionResult> GetArtists(int? pageNumber, int? pageSize)
        {

            int currentPageNumber = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 5;
            var artists =await (from artist in _dbContext.Artists
                                select new
                                {
                                    Id=artist.Id,
                                    Name=artist.Name,
                                }).ToListAsync();
            return Ok(artists.Skip((currentPageNumber - 1) * currentPageSize).Take
                (currentPageSize));
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> ArtistDetails(int ArtistId)
        {
            var artistsDeatils = await _dbContext.Artists.Where(a => a.Id == ArtistId)
                .Include(a => a.Songs).ToListAsync();
            return Ok(artistsDeatils);

        }

    }
}
