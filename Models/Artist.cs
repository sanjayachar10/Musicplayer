﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicplayer.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string  Gender { get; set; }
        public string Name { get; set; }
        public ICollection<Album>  Albums { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
