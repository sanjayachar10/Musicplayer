using Microsoft.EntityFrameworkCore;
using Musicplayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicplayer.Data
{
    public class ApiDbContext :DbContext
    {


        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
                
        }

        public DbSet<Song> Songs
        { get; set; }
        public DbSet<Artist> Artists

        { get; set; }
        public DbSet<Album> Albums

        { get; set; }


       
    }
}
