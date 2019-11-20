using System.Configuration;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WinFormSample.Infrastructures.Database {
	/// <summary>
	/// DB接続クラス。
	/// </summary>
	public static class Connection {

		/// <summary>
		/// DB接続文字列取得用のApp.configのキー
		/// </summary>
		private const string KeyOfDbKey = "dbKey";

		/// <summary>
		/// 接続文字列。
		/// </summary>
		private static readonly string connectionString;

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		static Connection() {
			connectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings[KeyOfDbKey]].ConnectionString;
		}

		/// <summary>
		/// コネクションを生成する。
		/// </summary>
		/// <returns>生成したコネクション</returns>
		public static async Task<MySqlConnection> CreateAsync() {
			var con = new MySqlConnection(connectionString);
			await con.OpenAsync();
			return con;
		}

	}
}
