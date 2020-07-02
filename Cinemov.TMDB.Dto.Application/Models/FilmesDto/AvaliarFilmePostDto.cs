using System;
using System.Collections.Generic;
using System.Text;

namespace Cinemov.TMDB.Dto.Application.Models.FilmesDto
{
    public class AvaliarFilmePostDto
    {

            public float value { get; set; }

        public AvaliarFilmePostDto(float value)
        {
            this.value = value;
        }
    }
}
