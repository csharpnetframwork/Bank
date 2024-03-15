using BankProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.BankAccount
{
    internal class PaymanetMethode
    {
        private string userName;

        public PaymanetMethode(string userName)
        {
            this.userName = userName;
        }

        public void display()
        {
            Console.WriteLine("1.UPI \n2.Bank To Bank Tansfer");
            string userCh = Console.ReadLine();
            if (userCh != null)
            {
                switch (userCh)
                {
                    case "1":
                        Console.WriteLine("Please Enter Mobile Number ");
                        string MobileNumber = Console.ReadLine();
                        if (MobileNumber != null)
                        {
                            var FlagValue = Upi(MobileNumber, userName);
                            if (FlagValue)
                            {
                                Console.WriteLine("Transtion is completed ");
                            }
                            else
                            {
                                Console.WriteLine("Transtion Failed ");
                            }
                        }
                        break;
                    case "2":
                        Console.WriteLine("Please Enter Bank Account Number");
                        string BankNumber = Console.ReadLine();
                        if(BankNumber != null)
                        {
                            bool FlagValue = BankToBank(BankNumber, userName);
                            if (FlagValue)
                            {
                                Console.WriteLine("Transtion is completed ");
                            }
                            else
                            {
                                Console.WriteLine("Transtion Failed ");
                            }
                        }
                        break;

                }
            }

        }
        public bool Upi(string MobileNumber, string CurrentuserName)
        {
            bool Transaction = false;
            using (var db = new BankDBContext())
            {
                var ReceiverUsername = db.SignUPModels
                    .Where(x => x.Phone.Equals(MobileNumber))
                    .Select(x => x.UserName)
                    .FirstOrDefault();

                if (ReceiverUsername != null)
                {
                    // Ask the user to enter the amount
                    Console.WriteLine("Please Enter Amount");
                    string SendAmount = Console.ReadLine();

                    if (SendAmount != null)
                    {
                        // Get sender's account details
                        var senderAccount = db.AccountDetail
                            .FirstOrDefault(x => x.UserName.Equals(CurrentuserName));

                        if (senderAccount != null && double.Parse(senderAccount.TotalAmount) >= double.Parse(SendAmount))
                        {
                            // Generate a random transaction number
                            Random random = new Random();
                            int randomNumber = random.Next(100000, 999999);

                            // Create a transaction record for sender
                            TrancationHistory senderTransaction = new TrancationHistory
                            {
                                ReciverUserName = ReceiverUsername,
                                SenderUserName = CurrentuserName,
                                Trancation = randomNumber.ToString(),
                                TrancationType = "UPI",
                                Totalamount = SendAmount,
                                TrancationDate = DateTime.Now.ToString()
                            };

                            // Add the sender transaction to the context
                            db.TrancationHistorys.Add(senderTransaction);

                            // Update sender's account balance
                            senderAccount.TotalAmount = (double.Parse(senderAccount.TotalAmount) - double.Parse(SendAmount)).ToString();

                            // Save changes for sender
                            db.SaveChanges();

                            // Get receiver's account details
                            var receiverAccount = db.AccountDetail
                                .FirstOrDefault(x => x.UserName.Equals(ReceiverUsername));

                            if (receiverAccount != null)
                            {
                                // Update receiver's account balance
                                receiverAccount.TotalAmount = (double.Parse(receiverAccount.TotalAmount) + double.Parse(SendAmount)).ToString();

                                // Save changes for receiver
                                db.SaveChanges();

                                Transaction = true;
                            }
                        }
                    }
                }
            }
            return Transaction;
        }
        public bool BankToBank(string BankNumber, string CurrentuserName)
        {
            bool Transaction = false;
            using (var db = new BankDBContext())
            {
                var ReceiverUsername = db.AccountDetail
                    .Where(x => x.AccountNunmber.Equals(BankNumber))
                    .Select(x => x.UserName)
                    .FirstOrDefault();

                if (ReceiverUsername != null)
                {
                    // Ask the user to enter the amount
                    Console.WriteLine("Please Enter Amount");
                    string SendAmount = Console.ReadLine();
                    if (SendAmount != null)
                    {
                        // Get sender's account details
                        var senderAccount = db.AccountDetail
                            .FirstOrDefault(x => x.UserName.Equals(CurrentuserName));

                        if (senderAccount != null && double.Parse(senderAccount.TotalAmount) >= double.Parse(SendAmount))
                        {
                            // Generate a random transaction number
                            Random random = new Random();
                            int randomNumber = random.Next(100000, 999999);

                            // Create a transaction record for sender
                            TrancationHistory senderTransaction = new TrancationHistory
                            {
                                ReciverUserName = ReceiverUsername,
                                SenderUserName = CurrentuserName,
                                Trancation = randomNumber.ToString(),
                                TrancationType = "Bank To Bank",
                                Totalamount = SendAmount,
                                TrancationDate = DateTime.Now.ToString()
                            };

                            // Add the sender transaction to the context
                            db.TrancationHistorys.Add(senderTransaction);

                            // Update sender's account balance
                            senderAccount.TotalAmount = (double.Parse(senderAccount.TotalAmount) - double.Parse(SendAmount)).ToString();

                            // Save changes for sender
                            db.SaveChanges();

                            // Get receiver's account details
                            var receiverAccount = db.AccountDetail
                                .FirstOrDefault(x => x.UserName.Equals(ReceiverUsername));

                            if (receiverAccount != null)
                            {
                                // Update receiver's account balance
                                receiverAccount.TotalAmount = (double.Parse(receiverAccount.TotalAmount) + double.Parse(SendAmount)).ToString();

                                // Save changes for receiver
                                db.SaveChanges();

                                Transaction = true;
                            }
                        }
                    }
                }
            }
            return Transaction;
        }
    }
}

