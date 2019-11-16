namespace WinFormSample.Domain.DomainObjects.Entities {
	/// <summary>
	/// 敵のパラメータ格納用データクラス。
	/// </summary>
	public class EnemyParameter {

		/// <summary>
		/// 名前。
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// HP.
		/// </summary>
		public int Hp { get; set; }

		/// <summary>
		/// ボスかどうか。
		/// </summary>
		public bool IsBoss { get; set; }

	}
}
