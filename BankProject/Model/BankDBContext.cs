using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BankProject.Model
{
    internal class BankDBContext:DbContext
    {
        public DbSet<PolicyModel> PolicyModels { get; set; }
        public DbSet<PolicyArchiveModel> PolicyArchiveModels { get; set; }
        public DbSet<EmployeeLogin>EmployeeLogins { get; set; }
        public DbSet<UserProfileModel>UserProfiles { get; set; }
        public DbSet<LoginModel> LoginCustomer { get; set; }
        public DbSet<SignUPModel>SignUPModels { get; set; } 
        public DbSet<AccountModel> AccountDetail { get; set; }
        public DbSet<TrancationHistory> TrancationHistorys {  get; set; }
        public void SyncProfile(string Username)
        {
            // Execute the stored procedure
            Database.ExecuteSqlRaw("EXEC SyncProfile @Username", new SqlParameter("@Username", Username));
        }
        public void SyncProfileUser(string Username, string? phone, string? FName, string? Address)
        {
            // Execute the stored procedure with multiple parameters
            Database.ExecuteSqlRaw("EXEC SyncProfileUser @Username, @Phone, @FName, @Address",
                new SqlParameter("@Username", Username),
                new SqlParameter("@Phone", phone),
                new SqlParameter("@FName", FName),
                new SqlParameter("@Address", Address));
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             var ConcontionDB = ConfigurationManager.AppSettings["con"];
             optionsBuilder.UseSqlServer(ConcontionDB);


        }
    }
}
