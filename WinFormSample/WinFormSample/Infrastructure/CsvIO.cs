using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WinFormSample.Domain.DomainObjects.Entities;

namespace WinFormSample.Infrastructure {
	/// <summary>
	/// CSV入出力クラス。
	/// </summary>
	public static class CsvIO {

		/// <summary>
		/// 敵情報をCSVファイルに書き出す。
		/// </summary>
		/// <param name="list">出力対象のリスト</param>
		/// <param name="filePath">出力先ファイルパス</param>
		public static async Task WriteEnemyParametersAsync(IEnumerable<EnemyParameter> list, string filePath) {
			var sb = new StringBuilder();

			// ヘッダ
			sb.Append(nameof(EnemyParameter.Name)).Append(",");
			sb.Append(nameof(EnemyParameter.Hp)).Append(",");
			sb.Append(nameof(EnemyParameter.IsBoss));
			sb.Append(Environment.NewLine);

			// データ
			foreach (var row in list) {
				sb.Append(row.Name).Append(",");
				sb.Append(row.Hp).Append(",");
				sb.Append(row.IsBoss);
				sb.Append(Environment.NewLine);
			}

			using (var writer = new StreamWriter(filePath, false, Encoding.UTF8)) {
				await writer.WriteAsync(sb.ToString());
			}
		}

	}
}
