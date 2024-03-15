using BankProject.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.BankAccount
{
    internal class AcoountDetails
    {     BankDBContext db =new BankDBContext();
        public void displayDetails(string userName)
        {
            var Userdetails=db.AccountDetail.Where(x=>x.UserName.Equals(userName)).Select(x=>x.UserName).FirstOrDefault();
            if(Userdetails != null)
            {
                var AcoountData = db.AccountDetail.Where(x=>x.UserName.Equals(userName));
                foreach (var a in AcoountData)
                {
                    Console.WriteLine("User:"+a.UserName +"Account Details are Displayed below " +"\n"+"Account Number :" + a.AccountNunmber +"\n"+"Total Amount :" + a.TotalAmount);
                }
            }
            else
            {
                Random random = new Random();
                int randomInRange = random.Next(5, 10);
                var data = db.SignUPModels.Where(x => x.UserName.Equals(userName)).ToList();
                var Account = db.AccountDetail.Where(x => x.UserName.Equals(userName)).Select(x => x.TotalAmount)
                    .FirstOrDefault();
                string total = string.Empty;
                if (Account == null)
                {
                    total = "1000";
                }
                else
                {
                    total = Account;
                }
                foreach (var item in data)
                {
                    string Accoun = randomInRange.ToString() + item.Phone;
                    var AccountModel = new AccountModel
                    {
                        AccountNunmber = Accoun,
                        Email = item.Email,
                        TotalAmount = total,
                        createdDate = DateTime.Now.ToString(),
                        UserName = item.UserName,

                    };
                    db.AccountDetail.Add(AccountModel);
                    db.SaveChanges();
                }
            }
           
            
        }
    }
}
