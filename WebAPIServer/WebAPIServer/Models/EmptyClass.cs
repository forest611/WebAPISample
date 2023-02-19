using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebAPIServer.Models
{
	public class UserBank
	{
		[Key]
		public int id { get; set; }
		public string player { get; set; }
        public string uuid { get; set; }
        public double balance { get; set; }



    }

	public class UserBankContext : DbContext
	{

		public DbSet<UserBank> user_Bank { get; set; }

	}

	public class BankData
	{

		static void GetBank(string mcid)
		{

			var db = new UserBankContext();

			var balance = db.user_Bank.Where(t => t.player == mcid).FirstOrDefault();

			Console.WriteLine($"mcid:{mcid} balance:{balance}");
		}

	}

}

