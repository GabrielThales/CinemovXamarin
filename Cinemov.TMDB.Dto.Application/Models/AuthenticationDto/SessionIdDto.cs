using System;
using System.Collections.Generic;
using System.Text;

namespace Cinemov.TMDB.Dto.Application.Models.AuthenticationDto
{
    public class SessionIdDto
    {
        public string request_token { get; set; }

        public SessionIdDto(string request_token)
        {
            this.request_token = request_token;
        }
    }
}
