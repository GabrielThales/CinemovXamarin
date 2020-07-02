using System;
using System.Collections.Generic;
using System.Text;

namespace Cinemov.TMDB.Dto.Application.Models.SeriesDto
{
    public class SerieDto
    {
            public string poster_path { get; set; }
            public float popularity { get; set; }
            public int id { get; set; }
            public string backdrop_path { get; set; }
            public float vote_average { get; set; }
            public string overview { get; set; }
            public string first_air_date { get; set; }
            public string[] origin_country { get; set; }
            public int[] genre_ids { get; set; }
            public string original_language { get; set; }
            public int vote_count { get; set; }
            public string name { get; set; }
            public string original_name { get; set; }

        public SerieDto(string poster_path, float popularity, int id, string backdrop_path, float vote_average, string overview, string first_air_date, string[] origin_country, int[] genre_ids, string original_language, int vote_count, string name, string original_name)
        {
            this.poster_path = "https://image.tmdb.org/t/p/w500" + poster_path;
            this.popularity = popularity;
            this.id = id;
            this.backdrop_path = "https://image.tmdb.org/t/p/w500" + backdrop_path;
            this.vote_average = vote_average;
            this.overview = overview;
            this.first_air_date = first_air_date;
            this.origin_country = origin_country;
            this.genre_ids = genre_ids;
            this.original_language = original_language;
            this.vote_count = vote_count;
            this.name = name;
            this.original_name = original_name;
        }
    }
}
