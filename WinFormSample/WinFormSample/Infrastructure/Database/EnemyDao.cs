using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using WinFormSample.Domain.DomainObjects.Entities;

namespace WinFormSample.Infrastructures.Database {
	/// <summary>
	/// Enemyテーブルにアクセスするクラス。
	/// </summary>
	public class EnemyDao {

		/// <summary>
		/// Enemyテーブルデータを全件取得する。
		/// </summary>
		/// <returns>取得したデータ</returns>
		public DataTable Select() {
			DataTable ret = new DataTable();
			using (var con = Connection.Create()) {
				var sql = "SELECT * FROM enemy;";
				var cmd = new MySqlCommand(sql, con);
				var da = new MySqlDataAdapter(cmd);

				da.Fill(ret);
				ret.TableName = "enemy";
			}

			return ret;
		}

		/// <summary>
		/// EnemyテーブルデータにINSERTを行う。
		/// </summary>
		/// <param name="targetList">挿入対象データ</param>
		/// <returns><c>true</c>: 成功 <c>false</c>: 失敗</returns>
		public bool Insert(IEnumerable<EnemyParameter> targetList) {
			var ret = true;

			// トランザクション開始
			using (var con = Connection.Create())
			using (var tran = con.BeginTransaction()) {
				foreach(var target in targetList) {
					var sql = $"INSERT INTO enemy VALUES(0, '{target.Name}', {target.Hp}, {target.IsBoss});";

					// SQL実行
					var cmd = new MySqlCommand(sql, con);
					if (cmd.ExecuteNonQuery() == 0) {
						ret = false;
						break;
					}
				}

				// 全件更新できた場合はコミット
				if (ret) {
					tran.Commit();
				} else {
					tran.Rollback();
				}
			}

			return ret;
		}

		/// <summary>
		/// EnemyテーブルデータにUPDATEを行う。
		/// </summary>
		/// <param name="enemyData">更新対象データ</param>
		/// <returns><c>true</c>: 成功 <c>false</c>: 失敗</returns>
		public bool Update(DataTable enemyData) {
			var ret = true;

			// SQL生成
			var sqlList = SqlUtil.CreateUpdateSqlFrom(enemyData);

			// トランザクション開始
			using (var con = Connection.Create())
			using (var tran = con.BeginTransaction()) {
				foreach (var sql in sqlList) {
					// SQL実行
					var cmd = new MySqlCommand(sql, con);
					if (cmd.ExecuteNonQuery() == 0) {
						ret = false;
						break;
					}
				}

				// 全件更新できた場合はコミット
				if (ret) {
					tran.Commit();
				} else {
					tran.Rollback();
				}
			}

			return ret;
		}

	}
}
