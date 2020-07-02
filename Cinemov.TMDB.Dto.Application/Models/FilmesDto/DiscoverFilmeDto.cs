using System;
using System.Collections.Generic;
using System.Text;

namespace Cinemov.TMDB.Dto.Application.Models.FilmesDto
{
        public class DiscoverFilmeDto
        {
            public int page { get; set; }
            public int total_results { get; set; }
            public int total_pages { get; set; }
            public FilmeDto[] results { get; set; }
        }

}
