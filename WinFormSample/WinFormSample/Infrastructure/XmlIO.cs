using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WinFormSample.Infrastructures {
	/// <summary>
	/// XML入出力クラス。
	/// </summary>
	public static class XmlIO {

		#region constants
		/// <summary>
		/// 拡張子。
		/// </summary>
		public const string Extension = ".xml";
		#endregion

		#region public methods
		/// <summary>
		/// XMLファイルを読み込む。
		/// </summary>
		/// <typeparam name="T">読み込んだデータを格納する型</typeparam>
		/// <param name="filePath">読み込むファイルパス</param>
		/// <returns>読み込んだデータを<typeparamref name="T"/>型のオブジェクトに変換したもの</returns>
		public static async Task<T?> ReadAsync<T>(string filePath) where T : class {
			T? ret = default;
			var serializer = new XmlSerializer(typeof(T));
			using (var reader = new StreamReader(filePath)) {
				await Task.Run(() => ret = serializer.Deserialize(reader) as T);
			}

			return ret;
		}

		/// <summary>
		/// XMLファイルに書き出す。
		/// </summary>
		/// <typeparam name="T">書き出すオブジェクトの型</typeparam>
		/// <param name="target">出力対象のオブジェクト</param>
		/// <param name="filePath">出力先ファイルパス</param>
		public static async Task WriteAsync<T>(T target, string filePath) {
			var serializer = new XmlSerializer(typeof(T));

			await using (var writer = new StreamWriter(filePath, false, Encoding.UTF8)) {
				await Task.Run(() => serializer.Serialize(writer, target));
				await writer.FlushAsync();
			}
		}
		#endregion

	}
}
