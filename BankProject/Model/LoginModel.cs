using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Model
{
    internal class LoginModel
    {
        public Guid ID { get; set; }
        public required String UserName { get; set; }
        public required string Password { get; set; }
    }
}
