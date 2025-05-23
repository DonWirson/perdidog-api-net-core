﻿using System.ComponentModel.DataAnnotations;

namespace perdidog.Models.Dtos
{
    public class RegisterRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }


        public string[] Roles { get; set; }
    }
}
