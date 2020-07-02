using System;
using System.Collections.Generic;
using System.Text;

namespace Cinemov.TMDB.Dto.Application.Models.AuthenticationDto
{
    public class RequestTokenDto
    {

            public bool success { get; set; }
            public string expires_at { get; set; }
            public string request_token { get; set; }

    }
}
