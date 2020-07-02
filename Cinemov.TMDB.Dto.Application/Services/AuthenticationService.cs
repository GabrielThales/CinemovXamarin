using Cinemov.TMDB.Dto.Application.Models.AuthenticationDto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cinemov.TMDB.Dto.Application.Services
{
    public class AuthenticationService
    {
        public async Task<RequestTokenDto> GetToken()
        {
            var httpClient = new HttpClient();
            var httpResult = httpClient.GetAsync("https://api.themoviedb.org/3/authentication/token/new?api_key=7ba0016d8a29404b95fd34bb3130e470");
            var result = httpResult.Result;
            var serializedRequestToken = await result.Content.ReadAsStringAsync();
            var requestTokenDto = JsonConvert.DeserializeObject<RequestTokenDto>(serializedRequestToken);

            return requestTokenDto;
        }

        public async Task<Boolean> CreateSession(string login, string senha,RequestTokenDto token)
        {
            var session = new SessionPostDto(login,senha, token.request_token);
            var json = JsonConvert.SerializeObject(session);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpClient = new HttpClient();
            var httpResult = await httpClient.PostAsync("https://api.themoviedb.org/3/authentication/token/validate_with_login?api_key=7ba0016d8a29404b95fd34bb3130e470",data);

            string result = httpResult.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);

            var resultado = false;

            if (result.Contains("true"))
            {
                resultado = true;
            }

            return resultado;
        }

        public async Task<SessionResultDto> CreateSessionId(RequestTokenDto token)
        {
            var session = new SessionIdDto(token.request_token);
            var json = JsonConvert.SerializeObject(session);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpClient = new HttpClient();
            var httpResult = await httpClient.PostAsync("https://api.themoviedb.org/3/authentication/session/new?api_key=7ba0016d8a29404b95fd34bb3130e470", data);

            string result = httpResult.Content.ReadAsStringAsync().Result;
            var resultado = JsonConvert.DeserializeObject<SessionResultDto>(result);
            //Console.WriteLine(result);

            return resultado;
        }
    }
}
