using System;

namespace WinFormSample.Domain.DomainObjects.Entities {
	/// <summary>
	/// プレイヤーのパラメータ格納用データクラス。
	/// </summary>
	[Serializable]
	public partial class PlayerParameter {

		#region enums
		/// <summary>
		/// 職業の種類。
		/// </summary>
		public enum JobType {
			/// <summary>剣士。</summary>
			Knight = 10,
			/// <summary>魔法使い。</summary>
			Witch = 20,
			/// <summary>忍者。</summary>
			Ninja = 30
		}
		#endregion

		#region properties
		/// <summary>
		/// 名前。
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 性別。
		/// </summary>
		/// <remarks><c>true</c>: 男性 <c>false</c>: 女性</remarks>
		public bool IsMale { get; set; }

		/// <summary>
		/// 初回プレイから使用可能かどうか。
		/// </summary>
		public bool IsAvailableOnFirstPlay { get; set; }

		/// <summary>
		/// 能力のタイプ。
		/// </summary>
		public PlayerParameterType ParameterType { get; set; }

		/// <summary>
		/// 職業。
		/// </summary>
		public JobType Job { get; set; }
		#endregion

	}
}
