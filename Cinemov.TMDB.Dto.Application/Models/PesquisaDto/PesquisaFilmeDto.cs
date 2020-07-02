using Cinemov.TMDB.Dto.Application.Models.FilmesDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinemov.TMDB.Dto.Application.Models.PesquisaDto
{
    public class PesquisaFilmeDto
    {

            public int page { get; set; }
            public FilmeDto[] results { get; set; }
            public int total_results { get; set; }
            public int total_pages { get; set; }

    }
}
