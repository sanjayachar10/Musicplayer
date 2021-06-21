using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicplayer.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
