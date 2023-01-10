using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.Dtos
{
    public class UserForRegisterDto : IDto
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
