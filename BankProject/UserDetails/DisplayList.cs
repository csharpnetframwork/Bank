using BankProject.BankAccount;
using BankProject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.UserDetails
{
    internal class DisplayList
    {
        BankDBContext db = new BankDBContext();

        public void DisplayUserList()
        {
            Console.WriteLine("Do you want to display all users? \n 1. Yes \n 2. No ");
            string userChoice = Console.ReadLine();

            if (userChoice == "1")
            {
                var data = from a in db.AccountDetail
                           join b in db.SignUPModels
                           on a.UserName equals b.UserName
                           select new
                           {
                               a.UserName,
                               a.TotalAmount,
                               a.AccountNunmber,
                               a.Email,
                               a.createdDate,
                               b.Phone
                           };

                Console.WriteLine("\nAll Active User Details:");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("User Name\tPhone Number\tEmail Address\tAccount Opening Date\tTotal Amount\tAccount Number");
                Console.WriteLine("----------------------------------------------------------------------------------------------------");

                foreach (var item in data)
                {
                    Console.WriteLine($"{item.UserName}\t{item.Phone}\t{item.Email}\t{item.createdDate}\t{item.TotalAmount}\t{item.AccountNunmber}");
                }
            }
            else if (userChoice == "2")
            {
                Console.WriteLine("\nDo you want to search based on: \n 1. Phone \n 2. Email \n 3. Bank Account Number");
                string searchChoice = Console.ReadLine();

                if (searchChoice == "1")
                {
                    Console.WriteLine("Enter Phone Number");
                    string phone = Console.ReadLine();

                    DisplaySearchResults(phone, "Phone");
                }
                else if (searchChoice == "2")
                {
                    Console.WriteLine("Enter Email Address");
                    string email = Console.ReadLine();

                    DisplaySearchResults(email, "Email");
                }
                else if (searchChoice == "3")
                {
                    Console.WriteLine("Enter Bank Account Number");
                    string accountNumber = Console.ReadLine();

                    DisplaySearchResults(accountNumber, "Account Number");
                }
                else
                {
                    Console.WriteLine("Enter Correct Value");
                }
            }
            else
            {
                Console.WriteLine("Enter Correct Value");
            }
        }

        private void DisplaySearchResults(string searchTerm, string searchType)
        {
            var data = db.AccountDetail
               .Join(
                    db.SignUPModels,
                    p => p.UserName,
                    a => a.UserName,
                    (p, a) => new
                    {
                        Username = p.UserName,
                        Phone = a.Phone,
                        Email = a.Email,
                        AccountDate = p.createdDate,
                        AccountNumner = p.AccountNunmber,
                        Total = p.TotalAmount
                    })
                .Where(x => searchType == "Phone" ? x.Phone == searchTerm :
                            searchType == "Email" ? x.Email == searchTerm :
                            x.AccountNumner == searchTerm) // Filter based on search type
                .ToList();

            Console.WriteLine($"\nSearch Results based on {searchType}:");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("User Name\tPhone Number\tEmail Address\tAccount Opening Date\tTotal Amount\tAccount Number");
            Console.WriteLine("----------------------------------------------------------------------------------------------------");

            foreach (var item in data)
            {
                Console.WriteLine($"{item.Username}\t{item.Phone}\t{item.Email}\t{item.AccountDate}\t{item.Total}\t{item.AccountNumner}");
            }
        }
    }
}
