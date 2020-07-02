using Cinemov.TMDB.Dto.Application.Models.FilmesDto;
using Cinemov.TMDB.Dto.Application.Models.PesquisaDto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cinemov.TMDB.Dto.Application.Services
{
    public class PesquisaService
    {
        public async Task<PesquisaFilmeDto> GetPesquisaFilmes(string pesquisa)
        {
            pesquisa = pesquisa.Replace(" ", "%20");

            var httpClient = new HttpClient();
            var httpResult = httpClient.GetAsync($"https://api.themoviedb.org/3/search/movie?api_key=7ba0016d8a29404b95fd34bb3130e470&language=pt-BR&query={pesquisa}&page=1&include_adult=false");
            var result = httpResult.Result;
            var serializedPesquisaFilmeDto = await result.Content.ReadAsStringAsync();
            var PesquisaFilmeDto = JsonConvert.DeserializeObject<PesquisaFilmeDto>(serializedPesquisaFilmeDto);

            return PesquisaFilmeDto;
        }

        public async Task<PesquisaSerieDto> GetPesquisaSeries(string pesquisa)
        {
            pesquisa = pesquisa.Replace(" ", "%20");

            var httpClient = new HttpClient();
            var httpResult = httpClient.GetAsync($"https://api.themoviedb.org/3/search/tv?api_key=7ba0016d8a29404b95fd34bb3130e470&language=pt-BR&page=1&query={pesquisa}&include_adult=false");
            var result = httpResult.Result;
            var serializedPesquisaSerieDto = await result.Content.ReadAsStringAsync();
            var PesquisaSerieDto = JsonConvert.DeserializeObject<PesquisaSerieDto>(serializedPesquisaSerieDto);

            return PesquisaSerieDto;
        }

        public async Task<PesquisaPessoaDto> GetPesquisaPessoas(string pesquisa)
        {
            pesquisa = pesquisa.Replace(" ", "%20");

            var httpClient = new HttpClient();
            var httpResult = httpClient.GetAsync($"https://api.themoviedb.org/3/search/person?api_key=7ba0016d8a29404b95fd34bb3130e470&language=pt-BR&query={pesquisa}&page=1&include_adult=false");
            var result = httpResult.Result;
            var serializedPesquisaPessoaDto = await result.Content.ReadAsStringAsync();
            var PesquisaPessoaDto = JsonConvert.DeserializeObject<PesquisaPessoaDto>(serializedPesquisaPessoaDto);

            return PesquisaPessoaDto;
        }

    }
}
