using BankProject.LoginSignup;
using BankProject.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.UserDetails
{
    internal class UserProfile
    {
        LoginControle log = new LoginControle();
        BankDBContext db = new BankDBContext();
        public void Display(string username)
        {
            var a = db.UserProfiles.Where(x => (x.UserName.Equals(username) && x.Email != null)).ToList();
            if (a.Count() == 0)
            {
                db.SyncProfile(username);
            }
            Console.Clear();
            var datalist = db.UserProfiles.Where(x => x.UserName.Equals(username)).ToList();
			Console.WriteLine("|-------------------------------------------------------------------------------------------------------------------------------------|");
			Console.WriteLine("| UserName     | FullName     | Email           | Phone Number  | Date Of Birth          | Address            | Account Opening       |");
			Console.WriteLine("|--------------|--------------|-----------------|---------------|------------------------|---------------------|----------------------|");
            foreach (var d in datalist)
            {
                Console.WriteLine($"| {d.UserName,-12} | {d.FullName,-13} | {d.Email,-16} | {d.Phone,-13} | {d.DOB,-22} | {d.Address,-19} | {d.CreationDate,-24} |");
                Console.WriteLine("|--------------|--------------|-----------------|---------------|------------------------|---------------------|------------------------|");
                Console.WriteLine(); // Add a newline between each user's information
            }
            bool back = true;
            do
            {
                Console.WriteLine("Please Select below options \n 1.Edit Profile \n 2. Back Main Manu");
                string userch = Console.ReadLine();
                switch (userch)
                {
                    case "1":

                        UpdateProfile(username);
                        break;
                    case "2":
                        log.DisplayDate(username);
                        back = false;
                        break;
                }
            } while (back != true);
        }
        public bool UpdateProfile(string username)
        {
            string UserName = username;
            string Email = string.Empty;
            string Phone = string.Empty;
            DateTime DOB = DateTime.MinValue;
            string Address = string.Empty;
            string FName = string.Empty;
            string CreationDate = string.Empty;
            var Fullname = db.UserProfiles.Where(x => x.UserName.Equals(username) && x.FullName != null).ToList();
            var data = db.UserProfiles.Where(x => x.UserName.Equals(username)).ToList();
            foreach (var d in data)
            {
                if (Fullname.Count() == 0)
                {
                    Console.WriteLine("Please Enter Full Name");
                    FName = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Do You not Want to edit value for FullName \n 1. Yes \n 2. No");
                    string u = Console.ReadLine();
                    if (u != null)
                    {
                        if (u.ToLower() == "1")
                        {
                            if (d.FullName != null)
                                FName = d.FullName.ToString();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Please Enter Full Name");
                            FName = Console.ReadLine();
                            Console.Clear();
                        }
                    }
                }
                var Pno = db.UserProfiles.Select(x => x.UserName.Equals(username) && x.Phone.IsNullOrEmpty()).ToList();
                if (Pno.Contains(true))
                {
                    Console.WriteLine("Please Enter Your Phone Number");
                    Phone = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Do You not want to edit phone number \n 1. Yes \n 2. No");
                    string u = Console.ReadLine();
                    if (u != null)
                        if (u.ToLower() == "1")
                        {
                            if (d.Phone != null)
                                Phone = d.Phone.ToString();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Please Enter Phone");
                            Phone = Console.ReadLine();
                        }
                }
                var address = db.UserProfiles.Select(x => x.UserName.Equals(username) && x.Address.IsNullOrEmpty()).ToList();
                if (address.Contains(true))
                {
                    Console.WriteLine("Please Enter Your Full address");
                    Address = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Do You not want to edit Your Address \n 1. Yes \n 2. No");
                    string u = Console.ReadLine();
                    if (u != null)
                        if (u.ToLower() == "1")
                        {
                            if (d.Address != null)
                                Address = d.Address.ToString();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Please Enter Full Address");
                            Address = Console.ReadLine();
                        }
                }
            }
            db.SyncProfileUser(UserName, Phone, FName, Address);
            return true;
        }
    }
}
