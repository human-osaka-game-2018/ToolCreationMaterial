using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WinFormSample.Domain.DomainObjects.Entities;
using WinFormSample.Infrastructure;
using WinFormSample.Infrastructures.Database;

namespace WinFormSample.Domain.Services {
	/// <summary>
	/// 敵画面のビジネスロジッククラス。
	/// </summary>
	public class EnemyService {

		#region field members
		/// <summary>
		/// Enemyテーブルアクセスクラス。
		/// </summary>
		private EnemyDao dao = new EnemyDao();
		#endregion

		#region public methods
		/// <summary>
		/// 表示サンプルデータを生成する。
		/// </summary>
		/// <returns>敵情報のリスト</returns>
		public List<EnemyParameter> CreateSampleData() {
			var ret = new List<EnemyParameter>();

			// 10件データ生成
			Enumerable.Range(1, 10).ToList().ForEach(i => {
				var enemy = new EnemyParameter($"enemy{i}", 100 * i, ((i % 5) == 0));
				ret.Add(enemy);
			});

			return ret;
		}

		/// <summary>
		/// 敵情報をDBから取得する。
		/// </summary>
		/// <returns>取得した敵情報</returns>
		public async Task<DataTable> LoadAsync() {
			var dt = await this.dao.SelectAsync();
			dt.AcceptChanges();
			return dt;
		}

		/// <summary>
		/// CSVにエクスポートする。
		/// </summary>
		/// <param name="targetList">出力対象データ</param>
		/// <param name="filePath">ファイルパス</param>
		public async Task ExportAsync(DataTable targetDT, string filePath) {
			// DataTableをListに変換
			var list = new List<EnemyParameter>();
			targetDT.Rows.OfType<DataRow>().ToList().ForEach(dr => {
				var enemy = new EnemyParameter(dr["name"].ToString() ?? "", Convert.ToInt32(dr["hp"]), (Convert.ToByte(dr["boss_flag"]) == 1));

				list.Add(enemy);
			});

			await this.ExportAsync(list, filePath);
		}

		/// <summary>
		/// CSVにエクスポートする。
		/// </summary>
		/// <param name="targetList">出力対象データ</param>
		/// <param name="filePath">ファイルパス</param>
		public Task ExportAsync(IEnumerable<EnemyParameter> targetList, string filePath) {
			return CsvIO.WriteEnemyParametersAsync(targetList, filePath);
		}

		/// <summary>
		/// 敵情報の新規データをDBに挿入する。
		/// </summary>
		/// <param name="targetList">新規作成データ</param>
		/// <returns>挿入に成功したかどうか</returns>
		public Task<bool> SaveAsync(IEnumerable<EnemyParameter> targetList) {
			return this.dao.InsertAsync(targetList);
		}

		/// <summary>
		/// 敵情報の更新をDBに反映する。
		/// </summary>
		/// <param name="dt">更新データを含む全件データ</param>
		/// <returns>更新に成功したかどうか</returns>
		public async Task<bool> SaveAsync(DataTable dt) {
			// 更新対象データのみ抜き出し
			var targetDt = dt.Copy();
			var unupdatedRows = targetDt.Rows.Cast<DataRow>().Where(x => x.RowState != DataRowState.Modified);
			unupdatedRows.ToList().ForEach(x => targetDt.Rows.Remove(x));

			var ret = await this.dao.UpdateAsync(targetDt);

			// FIXME: Insertは未実装

			if (ret) {
				dt.AcceptChanges();
			}

			return ret;
		}
		#endregion

	}
}
