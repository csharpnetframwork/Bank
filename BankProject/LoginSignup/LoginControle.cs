using BankProject.BankAccount;
using BankProject.Model;
using BankProject.UserDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankProject.PolicyDetails;

namespace BankProject.LoginSignup
{
    internal class LoginControle
    {
        readonly BankDBContext db = new BankDBContext();
        public String LoginCustomer(String UserName, String PassWord)
        {
            string User = string.Empty;
            if (UserName != null || PassWord != null)
            {
                var result = db.SignUPModels.Where(x => x.UserName.Equals(UserName) && x.Password.Equals(PassWord)).ToList();
                if (result.Count() == 1)
                {
                    var UserTemp = db.SignUPModels.Where(x => x.UserName.Equals(UserName)).ToList();
                    if (UserTemp != null)
                    {
                        foreach (var item in UserTemp)
                        {
                            User = item.UserName;
                        }

                    }

                }
            }
            return User;
        }
        public void DisplayDate(string userName)
        {
            Console.Clear();
            DateTime date = DateTime.Now;
            string formattedTime = date.ToString("h:mm tt");
            int colonIndex = formattedTime.IndexOf(':');
            string hourPart = colonIndex != -1 ? formattedTime.Substring(0, colonIndex) : formattedTime;
            if (formattedTime.Contains("PM"))
            {
                int time = int.Parse(hourPart);
                if (time >= 12 && time <= 5)
                {
                    Console.WriteLine("Good AfterNoon : " + "Time is :" + formattedTime);

                }
                else
                {
                    Console.WriteLine(" Good Evening : " + "Time is :" + formattedTime);
                }
            }
            else
            {
                int time = int.Parse(hourPart);
                if ((time >= 12) && (time <= 7) || (time! > 5))
                {
                    Console.WriteLine("Good  Night: " + "Time is :" + formattedTime);
                }
                else
                {
                    Console.WriteLine("Good Morning : " + "Time is :" + formattedTime);
                }
            }

            Console.WriteLine(" Login UserName : " + userName);
            var EmpType = db.SignUPModels.Where(x => x.IsEMP.Equals(true) && x.UserName.Equals(userName)).ToList();
            bool exit = false;
            do
            {
                Console.WriteLine("Please Select Below Options");
                if (EmpType.Count() == 0)
                {
                    Console.Clear();
                    Console.WriteLine(" 1. User Profile \n 2. Account Details \n 3. Transtion History \n 4. Loan  \n 5. Policy \n 6. Payment \n 7. Exit");
                    String option = Console.ReadLine();
                    switch (option)
                    {
                        case "1":
                            UserProfile obj = new UserProfile();
                            obj.Display(userName);
                            break;
                        case "2":
                            AcoountDetails obj1 = new AcoountDetails();
                            obj1.displayDetails(userName);
                            break;
                        case "6":
                            PaymanetMethode paymanetMethode = new PaymanetMethode(userName);
                            paymanetMethode.display();
                         break;
                        case "3":
                            UserTranctionHistory trhistory =new UserTranctionHistory();
                            trhistory.Display(userName);
                            break;

                        default:
                            exit = true;
                         break;
                    }
                }
                else
                {
                    Console.WriteLine(" 1. User's List  \n 2. User's Loan  \n 3. update Policy \n 4. Exit");
                   string userch= Console.ReadLine();
                    exit = false;
                    switch (userch)
                    {
                        case "1":
                            DisplayList dis = new DisplayList();
                            dis.DisplayUserList();
                            break;
                        case "2":

                         break;
                        case "3":
                            Policy Polic = new Policy();
                            string UserType = "Employee";
                            Polic.policyView(userName,UserType);
                            break;
                        case "4":
                            exit= true;
                            break;
                    }
                }
            } while (exit == true);
        }
    }

}
