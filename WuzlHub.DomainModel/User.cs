using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WuzlHub.DomainModels
{
   public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public byte[] Picture { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}
