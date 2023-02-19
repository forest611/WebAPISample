using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace WebAPIServer.Models
{
	/// <summary>
	/// Man10Bankのテーブル構造
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
	/// DbContextはスレッドセーフでない
	/// </summary>
	public class UserBankContext : DbContext
	{

		public DbSet<UserBank> user_Bank { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost;port=3306;user=forest;password=rDcrmPRLJvu@ex/E,>K;database=man10_bank";

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 30));

			optionsBuilder.UseMySql(connectionString,serverVersion);
        }

    }

	/// <summary>
	/// データ
	/// </summary>
	public class BankData
	{

		public static double GetBank(string mcid)
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

