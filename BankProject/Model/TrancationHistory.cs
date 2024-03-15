using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Model
{
    internal class TrancationHistory
    {
        [Key]
        public required string Trancation { get; set; }
        public required string TrancationType { get; set; }
        public required string Totalamount { get;set; }
        public required string TrancationDate { get; set; }
        public required string  SenderUserName { get; set; }
        public required string ReciverUserName { get; set;}
    }
}
