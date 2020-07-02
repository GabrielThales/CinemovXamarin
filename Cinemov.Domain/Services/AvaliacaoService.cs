using Cinemov.Domain.Entities;
using Cinemov.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinemov.Domain.Services
{
    public class AvaliacaoService
    {
        public IAvaliacaoRepository Repository { get; set; }

        public AvaliacaoService(IAvaliacaoRepository repository)
        {
            this.Repository = repository;
        }

        public void Create(Avaliacao avaliacao)
        {
            Repository.Create(avaliacao);
            Repository.SaveChanges();
        }

        public IEnumerable<Avaliacao> GetAllAvaliacoes()
        {
            return Repository.GetAll();
        }

        public void UpdateAvaliacao(Avaliacao avaliacao)
        {
            Repository.Update(avaliacao);
            Repository.SaveChanges();
        }

        public void DeleteAvaliacao(Avaliacao avaliacao)
        {
            Repository.Delete(avaliacao);
            Repository.SaveChanges();
        }
    }
}
