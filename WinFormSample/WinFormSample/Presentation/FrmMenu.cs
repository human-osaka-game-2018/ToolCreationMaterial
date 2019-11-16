using System;
using System.Windows.Forms;

namespace WinFormSample.Presentation {
	/// <summary>
	/// メニュー画面クラス。
	/// </summary>
	public partial class FrmMenu : Form {

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		public FrmMenu() {
			InitializeComponent();
		}

		/// <summary>
		/// プレイヤーボタンクリックイベント。
		/// </summary>
		/// <param name="sender">イベント発行元</param>
		/// <param name="e">イベントパラメータ</param>
		private void BtnPlyayer_Click(object sender, EventArgs e) {
			// プレイヤー画面をモードレスで開く
			var frmPlayer = new FrmPlayer();
			frmPlayer.Show();
		}

		/// <summary>
		/// 敵ボタンクリックイベント。
		/// </summary>
		/// <param name="sender">イベント発行元</param>
		/// <param name="e">イベントパラメータ</param>
		private void BtnEnemy_Click(object sender, EventArgs e) {
			// 敵画面をモーダルで開く
			var frmEnemy = new FrmEnemy();
			frmEnemy.ShowDialog();
		}

	}
}
