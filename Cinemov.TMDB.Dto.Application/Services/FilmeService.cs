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
    public class FilmeService
    {
        public async Task<DiscoverFilmeDto> GetDiscorverFilmes()
        {
            var httpClient = new HttpClient();
            var httpResult = httpClient.GetAsync("https://api.themoviedb.org/3/discover/movie?api_key=7ba0016d8a29404b95fd34bb3130e470&language=pt-BR&sort_by=popularity.desc&include_adult=false&include_video=false&page=1");
            var result = httpResult.Result;
            var serializedDiscoverFilmeDto = await result.Content.ReadAsStringAsync();
            var discoverFilmeDto = JsonConvert.DeserializeObject<DiscoverFilmeDto>(serializedDiscoverFilmeDto);

            return discoverFilmeDto;
        }

        public async Task<FilmesCinemaDto> GetFilmesEmCartaz()
        {
            var httpClient = new HttpClient();
            var httpResult = httpClient.GetAsync("https://api.themoviedb.org/3/movie/now_playing?api_key=7ba0016d8a29404b95fd34bb3130e470&language=pt-BR&page=1");
            var result = httpResult.Result;
            var serializedFilmeCinemaDto = await result.Content.ReadAsStringAsync();
            var FilmeCinemaDto = JsonConvert.DeserializeObject<FilmesCinemaDto>(serializedFilmeCinemaDto);

            return FilmeCinemaDto;
        }

        public async Task<FilmeDetailDto> GetFilmeDetails(int id)
        {
            var httpClient = new HttpClient();
            var httpResult = httpClient.GetAsync($"https://api.themoviedb.org/3/movie/{id}?api_key=7ba0016d8a29404b95fd34bb3130e470&language=pt-BR");
            var result = httpResult.Result;
            var serializedFilmeDetails = await result.Content.ReadAsStringAsync();
            var FilmeDetail = JsonConvert.DeserializeObject<FilmeDetailDto>(serializedFilmeDetails);
      
            return FilmeDetail;
        }

        public async Task<FilmesAssistidosDto> GetFilmesAvaliados(string sessionId, int page)
        {
            var account_id = "account_id";
            var httpClient = new HttpClient();
            var httpResult = httpClient.GetAsync($"https://api.themoviedb.org/3/account/{account_id}/rated/movies?api_key=7ba0016d8a29404b95fd34bb3130e470&language=pt-BR&session_id={sessionId}&sort_by=created_at.desc&page={page}");
            var result = httpResult.Result;
            var serializedFilmesAvaliados = await result.Content.ReadAsStringAsync();
            var filmesAvaliados = JsonConvert.DeserializeObject<FilmesAssistidosDto>(serializedFilmesAvaliados);

            return filmesAvaliados;
        }

        public async Task<PesquisaFilmeDto> GetFilmesFavoritos(string sessionId, int page)
        {
            var account_id = "account_id";
            var httpClient = new HttpClient();
            var httpResult = httpClient.GetAsync($"https://api.themoviedb.org/3/account/{account_id}/favorite/movies?api_key=7ba0016d8a29404b95fd34bb3130e470&session_id={sessionId}&language=pt-BR&sort_by=created_at.desc&page={page}");
            var result = httpResult.Result;
            var serializedFilmes = await result.Content.ReadAsStringAsync();
            var filmes = JsonConvert.DeserializeObject<PesquisaFilmeDto>(serializedFilmes);

            return filmes;
        }

        public async Task<PesquisaFilmeDto> GetWatchlist(string sessionId, int page)
        {
            var account_id = "account_id";
            var httpClient = new HttpClient();
            var httpResult = httpClient.GetAsync($"https://api.themoviedb.org/3/account/{account_id}/watchlist/movies?api_key=7ba0016d8a29404b95fd34bb3130e470&language=pt-BR&session_id={sessionId}&sort_by=created_at.desc&page={page}");
            var result = httpResult.Result;
            var serializedFilmesAvaliados = await result.Content.ReadAsStringAsync();
            var filmesAvaliados = JsonConvert.DeserializeObject<PesquisaFilmeDto>(serializedFilmesAvaliados);

            return filmesAvaliados;
        }

        public async Task<Boolean> AddFilmeFavorito(int id, string sessionId)
        {
            var account_id = "account_id";
            var favorito = new FilmeFavoritoPostDto("movie",id, true);
            var json = JsonConvert.SerializeObject(favorito);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpClient = new HttpClient();
            var httpResult = await httpClient.PostAsync($"https://api.themoviedb.org/3/account/{account_id}/favorite?api_key=7ba0016d8a29404b95fd34bb3130e470&session_id={sessionId}", data);

            string result = httpResult.Content.ReadAsStringAsync().Result;
            //Console.WriteLine(result);

            var resultado = false;

            if (result.Contains("12"))
            {
                resultado = true;
            }

            return resultado;
        }

        public async Task<Boolean> AddWatchList(int id, string sessionId)
        {
            var account_id = "account_id";
            var watchlist = new FilmeWatchListPostDto("movie", id, true);
            var json = JsonConvert.SerializeObject(watchlist);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpClient = new HttpClient();
            var httpResult = await httpClient.PostAsync($"https://api.themoviedb.org/3/account/{account_id}/watchlist?api_key=7ba0016d8a29404b95fd34bb3130e470&session_id={sessionId}", data);

            string result = httpResult.Content.ReadAsStringAsync().Result;
            //Console.WriteLine(result);

            var resultado = false;

            if (result.Contains("12") || result.Contains("Success"))
            {
                resultado = true;
            }

            return resultado;
        }

        public async Task<Boolean> AvaliarFilme(int id, string sessionId, float rating)
        {
            //var account_id = "account_id";
            var watchlist = new AvaliarFilmePostDto(rating);
            var json = JsonConvert.SerializeObject(watchlist);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpClient = new HttpClient();
            var httpResult = await httpClient.PostAsync($"https://api.themoviedb.org/3/movie/{id}/rating?api_key=7ba0016d8a29404b95fd34bb3130e470&session_id={sessionId}", data);

            string result = httpResult.Content.ReadAsStringAsync().Result;
            //Console.WriteLine(result);

            var resultado = false;

            if (result.Contains("true"))
            {
                resultado = true;
            }

            return resultado;
        }

    }
}
