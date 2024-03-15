using BankProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.BankAccount
{
    internal class Loan
    {
        public string CheckloanEliabletiy(string username)
        {
            using(var db =new BankDBContext())
            {
                var TarnstionData=db.AccountDetail.Where(x=>x.UserName.Equals(username))
                    .Select(x=>x.TotalAmount).FirstOrDefault();
               
                if (TarnstionData != null && double.Parse(TarnstionData) >= 10000)
                {

                    return "You are able to Take Loan Upto 20 lakh";
                }
                else if (TarnstionData != null && double.Parse(TarnstionData) >= 30000)
                {
                   
                    return "You are able to Take Loan Upto 30 lakh";
                }
                else if (TarnstionData != null && double.Parse(TarnstionData) >= 70000)
                {

                    return "You are able to Take Loan Upto 80 lakh";
                }
                else if (TarnstionData != null && double.Parse(TarnstionData) >= 90000)
                {

                    return "You are able to Take Loan Upto 2 cr";
                }
                else
                {
                    return "You are not elagibale to take loan";
                }
            }
          
        } 
        public string LoanProsse(string userName,string Amount)
        {
            using (var db = new BankDBContext())
            {
                var receiverAccount = db.AccountDetail
                             .FirstOrDefault(x => x.UserName.Equals(userName));

                if (receiverAccount != null)
                {
                    // Update receiver's account balance
                    receiverAccount.TotalAmount = (double.Parse(receiverAccount.TotalAmount) + double.Parse(Amount)).ToString();

                    // Save changes for receiver
                    db.SaveChanges();
                }
            }
            return "Loan Added in your Account ${Amount}";
        }
    }
}
