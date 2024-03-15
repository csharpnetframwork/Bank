using BankProject.Migrations;
using BankProject.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BankProject.PolicyDetails
{
    internal class Policy
    {
        BankDBContext db = new BankDBContext();
        string id = string.Empty;
        string policyname = string.Empty;
        string policytype = string.Empty;
        string desc = string.Empty;
        readonly string Createdate = DateTime.Now.ToString();
        readonly string Modifieddate = DateTime.Now.ToString();
        public void policyView(string username, string UserType)
        {
            string userchoice = string.Empty;
            if (UserType.Contains("Employee"))
            {
                Console.WriteLine("Welcome to the Policy Management System!");
                Console.WriteLine("1. Add Policy");
                Console.WriteLine("2. View Policy");
                Console.WriteLine("3. Update \n 4. Delete");
                Console.WriteLine("5. Exit");
                Console.Write("Please enter your choice: ");
                userchoice = Console.ReadLine();
                if (userchoice == "1")
                {
                    AddPolicy();
                }
                else if (userchoice == "2")
                {
                    ViewPolicy();
                }
                else if(userchoice == "3" || userchoice== "4")
                {
                    Console.WriteLine("pleas enter id Policy ");
                    string id = Console.ReadLine();
                    UpdateAndDelete(id,userchoice);
                }
                else if (userchoice == "5")
                {

                }

            }
            else
            {
                Console.WriteLine("Welcome to the Policy Management System!");
                Console.WriteLine("2. View Policy");
                Console.WriteLine("3. Exit");
                Console.Write("Please enter your choice: ");
                userchoice = Console.ReadLine();
            }
        }
        public bool AddPolicy()
        {
            Console.WriteLine("please enter Policy id");
           #pragma warning disable CS8601 // Possible null reference assignment.
            id = Console.ReadLine();
             #pragma warning restore CS8601 // Possible null reference assignment.
            if (id != null)
            {
                var i = db.PolicyModels.Where(x => x.ID.Equals(id)).ToList();
                if (i.Count() == 0)
                {
                    Console.WriteLine("please enter Policy type \n 1. Information Security Policy \n2. Fraud Prevention and Detection Policy \n3. Business Continuity and Disaster Recovery Policy \n4. Customer Complaints Handling Policy: ");     
                    //policytype = Console.ReadLine();
                    string choice = string.Empty;
                    choice = Console.ReadLine();
                    string Type = string.Empty;
                    if (choice == "1")
                    {
                        Type = "Information Security Policy";
                    }
                    else if (choice == "2")
                    {
                        Type = "Fraud Prevention and Detection Policy";
                    }
                    else if (choice == "3")
                    {
                        Type = "Business Continuity and Disaster Recovery Policy";
                    }
                    else if (choice == "4")
                    {
                        Type = "Customer Complaints Handling Policy:";
                    }
                    Console.WriteLine("please enter Policy Name");
                    policyname = Console.ReadLine();
                    Console.WriteLine("please enter Policy Description");
                    desc = Console.ReadLine();
                    var AddPloicymodel = new PolicyModel
                    {
                        ID = id,
                        PolicyName = policyname,
                        PolicyType = Type,
                        Desc = desc,
                        CreateDate = Createdate,
                        ModifiedDate = Modifieddate,

                    };
                    int result = 0;
                    using (var db = new BankDBContext())
                    {
                        db.Add(AddPloicymodel);
                        result = db.SaveChanges();
                    }
                    if (result == 1)
                    {
                        Console.WriteLine("You have succesfully added the policy");
                    }
                }
                else
                {
                    Console.WriteLine("ID is already there Please enter different ID");
                }
            }
            return true;
        }
        public void ViewPolicy()
        {
            Console.WriteLine("Please Enter your choice which Policy you want view!!!");
            Console.WriteLine("1. Information Security Policy \n2. Fraud Prevention and Detection Policy \n3. Business Continuity and Disaster Recovery Policy \n4. Customer Complaints Handling Policy: ");
            string choice = string.Empty;
            choice = Console.ReadLine();
            string Type = string.Empty;
            if (choice == "1")
            {
                Type = "Information Security Policy";
            }
            else if (choice == "2") 
            {
                Type = "Fraud Prevention and Detection Policy";
            }
           else if (choice=="3")
            {
                Type = "Business Continuity and Disaster Recovery Policy";
            }
            else if (choice =="4")
            {
                Type = "Customer Complaints Handling Policy:";
            }

            var PolicyData = db.PolicyModels.Where(x => x.PolicyType.Equals(Type)).ToList();
            foreach(var item in PolicyData)
            {
                Console.WriteLine("Policy Details : " +item.Desc);
                Console.WriteLine("                                             " + item.CreateDate);
            }
        }
        public void UpdateAndDelete(string id,string userchoice)
        {
            if (userchoice == "3")
            {
                Console.WriteLine("Please enter update desc ");
                string dec= Console.ReadLine();
                var policy = db.PolicyModels.FirstOrDefault(x=>x.ID.Equals(id));
                if (policy != null)
                {
                    // Update the specific column value
                    policy.Desc = dec;
                    policy.ModifiedDate = DateTime.Now.ToString();
                    // Save changes to the database
                    db.SaveChanges();
                }
            }
            else if(userchoice == "4") 
            {
                var policy = db.PolicyModels.FirstOrDefault(x => x.ID.Equals(id));
                if (policy != null)
                {// Remove the entity from the DbSet
                    db.PolicyModels.Remove(policy);
                    db.SaveChanges();
                }
            }
        }
    }
}
