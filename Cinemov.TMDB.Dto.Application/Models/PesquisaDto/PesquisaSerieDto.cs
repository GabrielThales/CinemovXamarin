using Cinemov.TMDB.Dto.Application.Models.SeriesDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinemov.TMDB.Dto.Application.Models.PesquisaDto
{
    public class PesquisaSerieDto
    {
            public int page { get; set; }
            public SerieDto[] results { get; set; }
            public int total_results { get; set; }
            public int total_pages { get; set; }

    }
}
