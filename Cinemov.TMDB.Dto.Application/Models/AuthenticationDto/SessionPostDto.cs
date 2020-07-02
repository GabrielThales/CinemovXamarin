using System;
using System.Collections.Generic;
using System.Text;

namespace Cinemov.TMDB.Dto.Application.Models.AuthenticationDto
{
    class SessionPostDto
    {
        public SessionPostDto(string username, string password, string request_token)
        {
            this.username = username;
            this.password = password;
            this.request_token = request_token;
        }

        public string username { get; set; }
            public string password { get; set; }
            public string request_token { get; set; }

    }
}
