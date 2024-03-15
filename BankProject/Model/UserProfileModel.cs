using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Model
{
    internal class UserProfileModel
    {
        public required string UserName { get; set; }
        [Key]
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public DateTime DOB { get; set; }
        public string? Address { get; set; }
        public string? FullName { get; set; }
        public string? CreationDate { get; set; }
    }
}
