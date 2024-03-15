using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Model
{
    internal class SignUPModel
    {
        public Guid ID { get; set; }
        public required string UserName { get; set; }
        [Key]
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string Phone  { get; set; }
        public DateTime DOB { get; set; }

        public bool IsEMP { get; set; }
    }
}
