using Cinemov.TMDB.Dto.Application.Models.PessoasDto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cinemov.TMDB.Dto.Application.Services
{
    public class PessoaService
    {
        public async Task<PessoaDto> GetPessoaDetails(int id)
        {
            var httpClient = new HttpClient();
            var httpResult = httpClient.GetAsync($"https://api.themoviedb.org/3/person/{id}?api_key=7ba0016d8a29404b95fd34bb3130e470&language=pt-BR");
            var result = httpResult.Result;
            var serializedPessoaDetails = await result.Content.ReadAsStringAsync();
            var PessoaDetail = JsonConvert.DeserializeObject<PessoaDto>(serializedPessoaDetails);

            return PessoaDetail;
        }
    }
}
