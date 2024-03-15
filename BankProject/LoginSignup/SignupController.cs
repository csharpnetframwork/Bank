
using BankProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.LoginSignup
{
    internal class SignupController
    {
       readonly string name = string.Empty;
        readonly string password = string.Empty;
        readonly string phonenumber=string.Empty;
        readonly string email = string.Empty;
        readonly DateTime DOB  = DateTime.MinValue;
        readonly bool isEmp = false;
        public SignupController(string name,string password, string phonenumber, string email, DateTime DOB, bool isEmp)
        {
             this.name =name ;
            this.password = password;
            this.phonenumber=phonenumber;
            this.email=email;
            this.DOB=DOB;
            this.isEmp=isEmp;
        }

        public bool CoustomerSignUP()
        {
            bool success = false;
            var signUp = new SignUPModel
            {
                UserName = name,
                Password = password,
                Phone = phonenumber,
                Email = email,
                DOB = DOB,
                IsEMP = isEmp
            };

            
          
            int result = 0;
            using (var db =new BankDBContext())
            {
                db.Add(signUp);
                result=db.SaveChanges();
              
            }
            if (result == 1)
            {
                success= true;
            }

                return success;
        }
    }
}
