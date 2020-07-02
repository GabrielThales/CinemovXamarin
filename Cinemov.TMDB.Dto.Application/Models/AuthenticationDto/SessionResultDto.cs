using System;
using System.Collections.Generic;
using System.Text;

namespace Cinemov.TMDB.Dto.Application.Models.AuthenticationDto
{
    public class SessionResultDto
    {

            public bool success { get; set; }
            public string session_id { get; set; }

        public SessionResultDto(bool success, string session_id)
        {
            this.success = success;
            this.session_id = session_id;
        }
    }
}
