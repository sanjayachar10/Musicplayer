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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>().HasData(
                new Song
                {
                    Id=1,
                    Title="sanjay", 
                    Language="English"
                },
                new Song
                {
                    Id = 2,
                    Title = "sany",
                    Language = "Enish"
                }

                );
        }
    }
}
