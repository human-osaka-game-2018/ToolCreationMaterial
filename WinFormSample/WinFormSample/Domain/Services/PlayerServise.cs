using System.IO;
using System.Threading.Tasks;
using WinFormSample.Domain.DomainObjects.Entities;
using WinFormSample.Infrastructures;

namespace WinFormSample.Domain.Services {
	/// <summary>
	/// プレイヤー画面のビジネスロジッククラス。
	/// </summary>
	public class PlayerService {

		#region public methods
		/// <summary>
		/// プレイヤー情報をファイルから読み込む。
		/// </summary>
		/// <param name="filePath">ファイルパス</param>
		/// <returns>読み込んだデータを格納したオブジェクト</returns>
		public async Task<PlayerParameter?> LoadAsync(string filePath) {
			// 拡張子で判断してデシリアライズ
			return Path.GetExtension(filePath)?.ToLower() switch {
				XmlIO.Extension => await XmlIO.ReadAsync<PlayerParameter>(filePath),
				JsonIO.Extension => await JsonIO.ReadAsync<PlayerParameter>(filePath),
				_ => null
			};
		}

		/// <summary>
		/// プレイヤー情報をファイルに保存する。
		/// </summary>
		/// <param name="value">保存する情報</param>
		/// <param name="filePath">保存先ファイルパス</param>
		public async Task SaveAsync(PlayerParameter value, string filePath) {
			// XML出力
			var xmlTask = XmlIO.WriteAsync(value, this.AddExtension(filePath, XmlIO.Extension));

			// JSON出力
			var jsonTask = JsonIO.WriteAsync(value, this.AddExtension(filePath, JsonIO.Extension));

			await Task.WhenAll(xmlTask, jsonTask);
		}
		#endregion

		#region private methods
		/// <summary>
		/// ファイルパスに拡張子を付与する。
		/// </summary>
		/// <param name="filePath">ファイルパス</param>
		/// <param name="extention">拡張子</param>
		/// <returns>拡張子が付与されたファイルパス</returns>
		private string AddExtension(string filePath, string extention) {
			return Path.ChangeExtension(filePath, extention);
		}
		#endregion

	}
}
