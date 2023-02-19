using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebAPIServer.Models
{
	/// <summary>
	/// UserBankテーブル
	/// </summary>
	public class UserBank
	{
		[Key]
		public int id { get; set; }
		public string player { get; set; }
        public string uuid { get; set; }
        public double balance { get; set; }

    }

    /// <summary>
    /// 接続設定など
    /// https://learn.microsoft.com/ja-jp/ef/core/dbcontext-configuration/
    /// </summary>
    public class UserBankContext : MySQLContext
	{
        public UserBankContext() : base("man10_bank")
        {
        }

        public DbSet<UserBank> user_Bank { get; set; }
    }

	/// <summary>
	/// データ
	/// </summary>
	public class Bank
	{
		public static double GetBalance(string mcid)
		{

			var db = new UserBankContext();

			var balance = db.user_Bank.Where(t => t.player == mcid).FirstOrDefault()?.balance ?? 0.0;

			db.user_Bank.ForEachAsync(result =>
			{
                Console.WriteLine($"FOREACH:{result.player}{result.balance}");
            });

            Console.WriteLine($"mcid:{mcid} balance:{balance}");

			return balance;
		}

	}

}

