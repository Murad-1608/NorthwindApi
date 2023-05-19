﻿using Core.Entity.Abstract;

namespace Entity.DTOs
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
