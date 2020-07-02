using System;
using System.Collections.Generic;
using System.Text;

namespace Cinemov.TMDB.Dto.Application.Models.FilmesDto
{
    public class FilmeDetailDto
    {
        public FilmeDetailDto(bool adult, string backdrop_path, object belongs_to_collection, int budget, Genre[] genres, string homepage, int id, string imdb_id, string original_language, string original_title, string overview, float popularity, string poster_path, Production_Companies[] production_companies, Production_Countries[] production_countries, string release_date, int revenue, int runtime, Spoken_Languages[] spoken_languages, string status, string tagline, string title, bool video, float vote_average, int vote_count)
        {
            this.adult = adult;
            this.backdrop_path = "https://image.tmdb.org/t/p/w500" + backdrop_path;
            this.belongs_to_collection = belongs_to_collection;
            this.budget = budget;
            this.genres = genres;
            this.homepage = homepage;
            this.id = id;
            this.imdb_id = imdb_id;
            this.original_language = original_language;
            this.original_title = original_title;
            this.overview = overview;
            this.popularity = popularity;
            this.poster_path = "https://image.tmdb.org/t/p/w500" + poster_path;
            this.production_companies = production_companies;
            this.production_countries = production_countries;
            this.release_date = release_date;
            this.revenue = revenue;
            this.runtime = runtime;
            this.spoken_languages = spoken_languages;
            this.status = status;
            this.tagline = tagline;
            this.title = title;
            this.video = video;
            this.vote_average = vote_average;
            this.vote_count = vote_count;
        }

            public bool adult { get; set; }
            public string backdrop_path { get; set; }
            public object belongs_to_collection { get; set; }
            public int budget { get; set; }
            public Genre[] genres { get; set; }
            public string homepage { get; set; }
            public int id { get; set; }
            public string imdb_id { get; set; }
            public string original_language { get; set; }
            public string original_title { get; set; }
            public string overview { get; set; }
            public float popularity { get; set; }
            public string poster_path { get; set; }
            public Production_Companies[] production_companies { get; set; }
            public Production_Countries[] production_countries { get; set; }
            public string release_date { get; set; }
            public int revenue { get; set; }
            public int runtime { get; set; }
            public Spoken_Languages[] spoken_languages { get; set; }
            public string status { get; set; }
            public string tagline { get; set; }
            public string title { get; set; }
            public bool video { get; set; }
            public float vote_average { get; set; }
            public int vote_count { get; set; }

        public class Genre
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Production_Companies
        {
            public int id { get; set; }
            public string logo_path { get; set; }
            public string name { get; set; }
            public string origin_country { get; set; }
        }

        public class Production_Countries
        {
            public string iso_3166_1 { get; set; }
            public string name { get; set; }
        }

        public class Spoken_Languages
        {
            public string iso_639_1 { get; set; }
            public string name { get; set; }
        }

    }
}
