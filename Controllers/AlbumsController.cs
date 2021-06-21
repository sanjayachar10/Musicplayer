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
    public class AlbumsController : ControllerBase
    {
        private ApiDbContext _dbContext;
        public AlbumsController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Album album)
        {
            await _dbContext.Albums.AddAsync(album);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpGet]
        public async Task<IActionResult> GetAlbums()
        {
            var albums = await (from album in _dbContext.Albums
                                select new
                                 {
                                     Id = album.Id,
                                     Name = album.Name,
                                 }).ToListAsync();
            return Ok(albums);
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> AlbumDetails(int albumId)
        {
            var albumDetails = await _dbContext.Albums.Where(a => a.Id == albumId)
                .Include(a => a.Songs).ToListAsync();
            return Ok(albumDetails);

        }
    }
}
