using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dtos
{
    public class UserLoginForRegisterDto:IDto
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
