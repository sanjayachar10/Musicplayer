using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Musicplayer.Models
{
    public class Song
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Language { get; set; }
        public string Duration { get; set; }
        public DateTime UploadedDAte { get; set; }
        public int ArtistId { get; set; }
        public int? AlbumId { get; set; }

    }

}