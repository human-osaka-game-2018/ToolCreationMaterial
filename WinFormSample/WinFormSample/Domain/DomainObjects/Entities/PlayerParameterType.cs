using System;

namespace WinFormSample.Domain.DomainObjects.Entities {
	/// <summary>
	/// プレイヤーのパラメータ格納用データクラス。
	/// </summary>
	public partial class PlayerParameter {
		/// <summary>
		/// プレイヤーの能力のタイプ。
		/// </summary>
		public enum PlayerParameterType {
			/// <summary>パワー重視。</summary>
			Power,
			/// <summary>スピード重視。</summary>
			Speed,
			/// <summary>HP大。</summary>
			Hp,
		}
	}

	/// <summary>
	/// <see cref="PlayerParameter.PlayerParameterType"/> の拡張クラス。
	/// </summary>
	public static class PlayerParameterTypeExtention {
		/// <summary>
		/// 表示名を取得する。
		/// </summary>
		/// <param name="type">列挙子</param>
		/// <returns>表示名</returns>
		public static string GetDisplayName(this PlayerParameter.PlayerParameterType type) {
			return type switch {
				PlayerParameter.PlayerParameterType.Power => "パワー重視",
				PlayerParameter.PlayerParameterType.Speed => "スピード重視",
				PlayerParameter.PlayerParameterType.Hp => "HP大",
				_ => throw new NotImplementedException("${type}は未実装です。")
			};
		}
	}

}
