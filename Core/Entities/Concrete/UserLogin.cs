using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class UserLogin : IEntity
    {
        public int UserId { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
    }
}
