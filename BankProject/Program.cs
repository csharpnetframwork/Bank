using BankProject.LoginSignup;
using BankProject.Model;
using Microsoft.IdentityModel.Tokens;
using System;
BankDBContext ob = new BankDBContext();
Console.WriteLine("*********** Welcome To Our Bank ***********");
string userName = string.Empty;
if (userName == string.Empty)
{
    Console.WriteLine(" 1. Login \n 2. SignUp");
    String UserChoice = string.Empty;
    UserChoice = Console.ReadLine();
    switch (UserChoice)
    {
        case "1":
            LoginControle obj = new LoginControle();
            Console.WriteLine("Please Enter UserName");
            String UserName = Console.ReadLine();
            Console.WriteLine("Please Enter Password");
            String Password = Console.ReadLine();
            bool login = false;
            do
            {
               
                if (UserName != null && Password != null)
                {
                    userName = obj.LoginCustomer(UserName, Password);
                    login=true;
                }

                if (userName != string.Empty)
                {    
                    obj.DisplayDate(userName);

                }
                else
                {
                    Console.WriteLine("UserName Or PassWord is incorrect");
                    Thread.Sleep(100);
                    Console.Clear();
                    Console.WriteLine("Please Enter UserName");
                    UserName = Console.ReadLine();
                    Console.WriteLine("Please Enter Password");
                    Password = Console.ReadLine();
                }

            }
            while (!login);
            
            break;
        case "2":
            Console.WriteLine("Please Provider Below Input for Register yourself");
            bool a = true;
            string Name = string.Empty;
            do
            {
                Console.WriteLine("Please Enter Your UserName");
                Name = Console.ReadLine();
                var reuser = ob.SignUPModels.Where(x => x.UserName.Equals(Name));
                if (reuser.Count() == 1)
                {
                    a = false;
                    Console.WriteLine(Name + " UserName is already Taken by other user ");
                    Console.Clear();
                }
            }
            while (a != true);
            Console.WriteLine(Name + " UserName is avablive");
            Console.WriteLine("Please Enter Your Email");
            string Email = Console.ReadLine();
            Console.WriteLine("Please Enter Your Phone Number");
            string Phone = Console.ReadLine();
            Console.WriteLine("Please Enter Your DOB");
            string Dob = Console.ReadLine();
            DateTime Brithdate = DateTime.MaxValue;
            if (Dob != null)
            {
                 Brithdate = DateTime.Parse(Dob);
            }
            Console.WriteLine("Please Enter Your PassWord");
            string Pass = Console.ReadLine();
            Console.WriteLine("Do You Want To Create Account As a Employee  \n 1. Yes \n 2. No");
            string Conformtion = Console.ReadLine();
            bool convalue = false;
            if (Conformtion != null)
            {
                if (Conformtion.Contains("1"))
                {
                }
                else
                {
                    convalue = true;
                }

            }
            if (Name !=null && Pass !=null && Phone !=null && Email !=null)
            {
                SignupController signup = new SignupController(Name, Pass, Phone, Email, Brithdate, convalue);
                bool SignupResult = signup.CoustomerSignUP();
                 
                if (SignupResult)
                {
                    Console.Clear();
                    Console.WriteLine("Your Signup Successfully Completed");
                    Console.Clear();
                    Thread.Sleep(3000);
                    Console.WriteLine("Please Try To Login");
                    Console.WriteLine("Please Enter UserName");
                    UserName = Console.ReadLine();
                    LoginControle obj1 = new LoginControle();
                    Console.WriteLine("Please Enter Password");
                    Password = Console.ReadLine();
                   
                    login = false;
                    do
                    {
                        if (UserName != null && Password != null)
                        {
                            userName = obj1.LoginCustomer(UserName, Password);
                        }
                        if (userName != string.Empty)
                        {
                            obj1.DisplayDate(userName);
                            login = true;
                        }
                        else
                        {
                            Console.WriteLine("UserName OR Password is wrong");
                            Thread.Sleep(100);
                            Console.Clear();
                            Console.WriteLine("Please Enter UserName");
                            UserName = Console.ReadLine();
                            Console.WriteLine("Please Enter Password");
                            Password = Console.ReadLine();

                        }
                    } while (!login);
                    
                }
                else
                {
                    Console.WriteLine("SomeThing Went Worng !");
                }

            }
            break;
        default:
            Console.WriteLine("SomeThing Went Worng !");
            break;
    }
}


