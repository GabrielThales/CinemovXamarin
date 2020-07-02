using System;
using System.Collections.Generic;
using System.Text;

namespace Cinemov.TMDB.Dto.Application.Models.FilmesDto
{
    public class FilmeFavoritoPostDto
    {
            public string media_type { get; set; }
            public int media_id { get; set; }
            public bool favorite { get; set; }

        public FilmeFavoritoPostDto(string media_type, int media_id, bool favorite)
        {
            this.media_type = media_type;
            this.media_id = media_id;
            this.favorite = favorite;
        }
    }
}
