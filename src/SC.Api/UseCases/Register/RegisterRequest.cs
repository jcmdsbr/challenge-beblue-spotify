using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SC.Api.UseCases.Register
{
    public class RegisterRequest
    {
        [Required]
        public List<Guid> Playlists { get; set; }

        [Required]
        [MaxLength(14)]
        public string CustomerCpf { get; set; }
    }
}