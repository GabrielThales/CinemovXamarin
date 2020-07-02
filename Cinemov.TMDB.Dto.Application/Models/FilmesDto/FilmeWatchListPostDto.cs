using System;
using System.Collections.Generic;
using System.Text;

namespace Cinemov.TMDB.Dto.Application.Models.FilmesDto
{
    public class FilmeWatchListPostDto
    {
            public string media_type { get; set; }
            public int media_id { get; set; }
            public bool watchlist { get; set; }

        public FilmeWatchListPostDto(string media_type, int media_id, bool watchlist)
        {
            this.media_type = media_type;
            this.media_id = media_id;
            this.watchlist = watchlist;
        }
    }
}
