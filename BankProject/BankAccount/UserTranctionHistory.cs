using BankProject.LoginSignup;
using BankProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.BankAccount
{
    internal class UserTranctionHistory
    {

      
        public bool Display(string userName)
        {
            bool flag = false;
            using(var db =new BankDBContext())
            {
                Console.WriteLine("User " + userName + " Transtion history");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Send Histroy");
                var Data =  db.TrancationHistorys.Where(x=>x.SenderUserName.Equals(userName)).ToList();
                foreach(var x in Data)
                {
                    Console.WriteLine("Transtion ID " + x.Trancation + " :-:" + "\t"+"Send To "+x.ReciverUserName +" :-:"+"\t"+"Amount "+x.Totalamount +" :-:"+"\t"+"Transtion Date "+x.TrancationDate);
                   // Console.ReadLine();
                }
                var data = db.TrancationHistorys.Where(x => x.ReciverUserName.Equals(userName)).ToList();
                Console.WriteLine("User " + userName + " Transtion history");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Recived Histroy");
                foreach ( var x in data)
                {
                   
                    Console.WriteLine("Transtion ID " + x.Trancation + ":-:" + "\t" + "Recived From " + x.SenderUserName + ":-:" + "\t" + "Amount " + x.Totalamount + ":-:" + "\t" + "Transtion Date " + x.TrancationDate);
                     // Console.ReadLine();
                    flag = true;
                   
                }
                Console.WriteLine("Do You Want to Go Back ? \n 1. Yes \n 2. No");
                string aa = Console.ReadLine();
                if (aa == "1")
                {
                    LoginControle obj = new LoginControle();
                    obj.DisplayDate(userName);
                }
                else
                {
                    UserTranctionHistory tr=new UserTranctionHistory();
                    tr.Display(userName);
                }
            }
            return flag;
        }
    }
}
