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
		//TODO:mcid->uuidに変える
		public static double GetBalance(string mcid)
		{
			var db = new UserBankContext();
			var balance = db.user_Bank.FirstOrDefault(t => t.player == mcid)?.balance ?? 0.0;
			return balance;
		}

		public static double SetBalance(string mcid, double amount)
		{
			var db = new UserBankContext();
			var data = db.user_Bank.FirstOrDefault(t => t.player == mcid);

			if (data == null)
			{
				return 0.0;
			}

			data.balance = amount;

			db.SaveChanges();
			return amount;
			
		}


	}

}

