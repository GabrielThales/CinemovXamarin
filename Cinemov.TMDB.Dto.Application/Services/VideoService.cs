using Cinemov.TMDB.Dto.Application.Models.VideoDto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cinemov.TMDB.Dto.Application.Services
{
    public class VideoService
    {
        public async Task<String> GetTrailer(int id)
        {
            var httpClient = new HttpClient();
            var httpResult = httpClient.GetAsync($"https://api.themoviedb.org/3/movie/{id}/videos?api_key=7ba0016d8a29404b95fd34bb3130e470&language=pt-BR");
            var result = httpResult.Result;
            var serializedVideoDto = await result.Content.ReadAsStringAsync();
            var videoDto = JsonConvert.DeserializeObject<VideoDto>(serializedVideoDto);

            String resultado = "Não Encontrado";

            foreach(VideoDto.Result item in videoDto.results)
            {
                if(item.type == "Trailer" && item.site == "YouTube")
                {
                    resultado = "https://www.youtube.com/watch?v=" + item.key;
                    break;
                }
            }

            return resultado;
        }
    }
}
