using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
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
		public async Task<DataTable> SelectAsync() {
			DataTable ret = new DataTable();
			await using (var con = await Connection.CreateAsync()) {
				var sql = "SELECT * FROM enemy;";
				var cmd = new MySqlCommand(sql, con);
				var da = new MySqlDataAdapter(cmd);

				await da.FillAsync(ret);
				ret.TableName = "enemy";
			}

			return ret;
		}

		/// <summary>
		/// EnemyテーブルデータにINSERTを行う。
		/// </summary>
		/// <param name="targetList">挿入対象データ</param>
		/// <returns><c>true</c>: 成功 <c>false</c>: 失敗</returns>
		public async Task<bool> InsertAsync(IEnumerable<EnemyParameter> targetList) {
			var ret = true;

			// トランザクション開始
			await using (var con = await Connection.CreateAsync())
			await using (var tran = await con.BeginTransactionAsync()) {
				foreach(var target in targetList) {
					var sql = $"INSERT INTO enemy VALUES(0, '{target.Name}', {target.Hp}, {target.IsBoss});";

					// SQL実行
					var cmd = new MySqlCommand(sql, con);
					if (await cmd.ExecuteNonQueryAsync() == 0) {
						ret = false;
						break;
					}
				}

				// 全件更新できた場合はコミット
				if (ret) {
					await tran.CommitAsync();
				} else {
					await tran.RollbackAsync();
				}
			}

			return ret;
		}

		/// <summary>
		/// EnemyテーブルデータにUPDATEを行う。
		/// </summary>
		/// <param name="enemyData">更新対象データ</param>
		/// <returns><c>true</c>: 成功 <c>false</c>: 失敗</returns>
		public async Task<bool> UpdateAsync(DataTable enemyData) {
			var ret = true;

			// SQL生成
			var sqlList = SqlUtil.CreateUpdateSqlFrom(enemyData);

			// トランザクション開始
			await using (var con = await Connection.CreateAsync())
			await using (var tran = await con.BeginTransactionAsync()) {
				foreach (var sql in sqlList) {
					// SQL実行
					var cmd = new MySqlCommand(sql, con);
					if (await cmd.ExecuteNonQueryAsync() == 0) {
						ret = false;
						break;
					}
				}

				// 全件更新できた場合はコミット
				if (ret) {
					await tran.CommitAsync();
				} else {
					await tran.RollbackAsync();
				}
			}

			return ret;
		}

	}
}
