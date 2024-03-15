using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Model
{
    internal class EmployeeLogin
    {
        public Guid id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public bool isEmp { get; set; }
    }
}
