using System;
using System.Collections.Generic;
using System.Text;

namespace Cinemov.TMDB.Dto.Application.Models.FilmesDto
{
    public class FilmesAssistidosDto
    {
            public int page { get; set; }
            public FilmeAssistidoDto[] results { get; set; }
            public int total_pages { get; set; }
            public int total_results { get; set; }

        public FilmesAssistidosDto(int page, FilmeAssistidoDto[] results, int total_pages, int total_results)
        {
            this.page = page;
            this.results = results;
            this.total_pages = total_pages;
            this.total_results = total_results;
        }
    }
}
