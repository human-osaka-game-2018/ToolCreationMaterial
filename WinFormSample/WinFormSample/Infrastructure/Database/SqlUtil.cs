using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WinFormSample.Infrastructures.Database {
	/// <summary>
	/// SQLユーティリティクラス。
	/// </summary>
	public static class SqlUtil {

		/// <summary>
		/// <see cref="DataTable" />からSQLを生成する。
		/// </summary>
		/// <param name="dt">SQL生成対象の<see cref="DataTable" /></param>
		/// <returns>生成したSQL文</returns>
		public static List<string> CreateUpdateSqlFrom(DataTable dt) {
			var ret = new List<string>();

			foreach (DataRow dr in dt.Rows) {
				// SQL生成
				var sql = new StringBuilder();
				sql.Append($"UPDATE {dt.TableName} SET ");
				foreach (DataColumn col in dt.Columns) {
					var colName = col.ColumnName;
					var closure = col.DataType == typeof(string) ? "'" : string.Empty;
					sql.Append($"{colName} = {closure + dr[colName].ToString() + closure}, ");
				}
				// 最後の項目のカンマを取り除く
				sql.Remove(sql.Length - 2, 1);

				sql.Append($"WHERE id = {dr["id"]}");

				ret.Add(sql.ToString());
			}

			return ret;
		}

	}
}
