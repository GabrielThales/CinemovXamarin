using System;
using System.Collections.Generic;
using System.Text;

namespace Cinemov.TMDB.Dto.Application.Models.FilmesDto
{
    public class FilmesCinemaDto
    {

            public FilmeDto[] results { get; set; }
            public int page { get; set; }
            public int total_results { get; set; }
            public Dates dates { get; set; }
            public int total_pages { get; set; }

        public class Dates
        {
            public string maximum { get; set; }
            public string minimum { get; set; }
        }

    }
}
