﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async  Task<IActionResult> Get()
        {
            return Ok(await  _dbContext.Songs.ToListAsync());
        }
        
        // GET api/<SongsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
             var song=await _dbContext.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound("NO RECORD FOUND");
            }
            return Ok(song);
        }

        // POST api/<SongsController>
        [HttpPost]
        public async  Task<IActionResult> Post([FromBody] Song song)
        {
            await _dbContext.Songs.AddAsync(song);
             await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<SongsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Song songOb)
        {
            var song = await _dbContext.Songs.FindAsync(id);

            if (song == null)
            {
                return NotFound("NO RECORD FOUND");
            }
            song.Title = songOb.Title;
            song.Language = songOb.Language;
            await _dbContext.SaveChangesAsync();
            return Ok("Records updated");
        }

        // DELETE api/<SongsController>/5
        [HttpDelete("{id}")]
        public async  Task<ActionResult> Delete(int id)
        {
            var song =await _dbContext.Songs.FindAsync(id);

            if (song == null)
            {
                return NotFound("NO RECORD FOUND");
            }
            _dbContext.Songs.Remove(song);
           await  _dbContext.SaveChangesAsync();
            return Ok("Dealted");
        }
    }
}
