using System;
using System.Collections.Generic;
using System.Text;

namespace Cinemov.TMDB.Dto.Application.Models.FilmesDto
{
        public class FilmeDto
        {
        public FilmeDto(float popularity, int vote_count, bool video, string poster_path, int id, bool adult, string backdrop_path, string original_language, string original_title, int[] genre_ids, string title, float vote_average, string overview, string release_date)
        {
            this.popularity = popularity;
            this.vote_count = vote_count;
            this.video = video;
            this.poster_path = "https://image.tmdb.org/t/p/w500" + poster_path;
            this.id = id;
            this.adult = adult;
            this.backdrop_path = "https://image.tmdb.org/t/p/w500" + backdrop_path;
            this.original_language = original_language;
            this.original_title = original_title;
            this.genre_ids = genre_ids;
            this.title = title;
            this.vote_average = vote_average;
            this.overview = overview;
            this.release_date = release_date;
        }

        public float popularity { get; set; }
            public int vote_count { get; set; }
            public bool video { get; set; }
            public string poster_path { get; set; }
            public int id { get; set; }
            public bool adult { get; set; }
            public string backdrop_path { get; set; }
            public string original_language { get; set; }
            public string original_title { get; set; }
            public int[] genre_ids { get; set; }
            public string title { get; set; }
            public float vote_average { get; set; }
            public string overview { get; set; }
            public string release_date { get; set; }

    }

}
