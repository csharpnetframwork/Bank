using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Model
{
    internal class AccountModel
    {
        public int ID { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        [Key]
        public required string AccountNunmber {get;set;}
        public required string TotalAmount { get; set; }
        public required string createdDate { get; set; }
    }
}
