using System.IO;
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
		public PlayerParameter Load(string filePath) {
			// 拡張子で判断してデシリアライズ
			PlayerParameter ret = null;
			switch (Path.GetExtension(filePath)?.ToLower()) {
				case XmlIO.Extension:
					ret = XmlIO.Read<PlayerParameter>(filePath);
					break;
				case JsonIO.Extension:
					ret = JsonIO.Read<PlayerParameter>(filePath);
					break;
			}

			return ret;
		}

		/// <summary>
		/// プレイヤー情報をファイルに保存する。
		/// </summary>
		/// <param name="value">保存する情報</param>
		/// <param name="filePath">保存先ファイルパス</param>
		public void Save(PlayerParameter value, string filePath) {
			// XML出力
			XmlIO.Write(value, this.AddExtension(filePath, XmlIO.Extension));

			// JSON出力
			JsonIO.Write(value, this.AddExtension(filePath, JsonIO.Extension));
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
