using System.IO;
using System.Text;
using System.Web.Script.Serialization;

namespace WinFormSample.Infrastructures {
	/// <summary>
	/// JSON入出力クラス。
	/// </summary>
	public static class JsonIO {

		#region constants
		/// <summary>
		/// 拡張子。
		/// </summary>
		public const string Extension = ".json";
		#endregion

		#region public methods
		/// <summary>
		/// JSONファイルを読み込む。
		/// </summary>
		/// <typeparam name="T">読み込んだデータを格納する型</typeparam>
		/// <param name="filePath">読み込むファイルパス</param>
		/// <returns>読み込んだデータを<typeparamref name="T"/>型のオブジェクトに変換したもの</returns>
		public static T Read<T>(string filePath) {
			// ファイル読込
			var serializer = new JavaScriptSerializer();
			string jsonText = null;
			using (var reader = new StreamReader(filePath)) {
				jsonText = reader.ReadToEnd();
			}

			// JSON形式のファイルをオブジェクトに変換
			var ret = serializer.Deserialize<T>(jsonText);

			return ret;
		}

		/// <summary>
		/// JSONファイルに書き出す。
		/// </summary>
		/// <typeparam name="T">書き出すオブジェクトの型</typeparam>
		/// <param name="target">出力対象のオブジェクト</param>
		/// <param name="filePath">出力先ファイルパス</param>
		public static void Write<T>(T target, string filePath) {
			// JSON形式に変換
			var serializer = new JavaScriptSerializer();
			var json = serializer.Serialize(target);

			// ファイルに書き出し
			using (var writer = new StreamWriter(filePath, false, Encoding.UTF8)) {
				writer.Write(json);
			}
		}
		#endregion

	}
}
