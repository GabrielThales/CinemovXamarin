using System;
using System.Collections.Generic;
using System.Text;

namespace Cinemov.Domain.Entities
{
    public class Avaliacao : EntityBase
    {
        public Guid Id { get; set; }
        public int FilmeId { get; set; }
        public string FilmeTitulo { get; set; }
        public string Poster { get; set; }
        public string Titulo { get; set; }
        public string Review { get; set; }
        public float NotaFilme { get; set; }

        public Avaliacao(int filmeId, string filmeTitulo, string poster, string titulo, string review, float notaFilme)
        {
            Id = Guid.NewGuid();
            FilmeId = filmeId;
            FilmeTitulo = filmeTitulo;
            Poster = poster;
            Titulo = titulo;
            Review = review;
            NotaFilme = notaFilme;
        }
    }


}
