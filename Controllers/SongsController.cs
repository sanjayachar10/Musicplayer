using Microsoft.AspNetCore.Mvc;
using Musicplayer.Data;
using Musicplayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Musicplayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {


        private ApiDbContext _dbContext;
        public SongsController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<SongsController>
        [HttpGet]
        public IEnumerable<Song> Get()
        {
            return _dbContext.Songs;
        }
        
        // GET api/<SongsController>/5
        [HttpGet("{id}")]
        public Song Get(int id)
        {
             var song= _dbContext.Songs.Find(id);
            return song;
        }

        // POST api/<SongsController>
        [HttpPost]
        public void Post([FromBody] Song song)
        {
            _dbContext.Songs.Add(song);
             _dbContext.SaveChanges();
        }

        // PUT api/<SongsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Song songOb)
        {
            var song = _dbContext.Songs.Find(id);
            song.Title = songOb.Title;
            song.Language = songOb.Language;
            _dbContext.SaveChanges();
        }

        // DELETE api/<SongsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var song = _dbContext.Songs.Find(id);
            _dbContext.Songs.Remove(song);
            _dbContext.SaveChanges();
        }
    }
}
